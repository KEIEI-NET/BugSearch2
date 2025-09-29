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

namespace Broadleaf.Application.Remoting
{

    /// <summary>
    /// ���i���擾DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i���擾�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.07.14</br>
    /// <br></br>
    /// <br>Update Note: 2009.03.17 22018 ��� ���b</br>
    /// <br>             �@���i�̎擾���C��</br>
    /// <br>               ���i�K�p�����p�����[�^�ɒǉ��B</br>
    /// <br></br>
    /// <br>Update Note: 2009.07.24 22018 ��� ���b</br>
    /// <br>             �@���i�����̃\�[�g����ύX����ׁA���o�N�G�����ꕔ�ύX�B</br>
    /// <br>               �Ȃ��A�ŏI�I�Ƀ\�[�g����PMKEN08060U�Ō��肷��B</br>
    /// <br></br>
    /// <br>Update Note: 2009.07.27 22018 ��� ���b</br>
    /// <br>             �@QTY�̎擾���t�B�[���h��ύX�B�u�c�i�����p�j�v���g�p����B</br>
    /// <br>�@�@�@�@�@�@�@�@�iPartsQtyRF��PartsQtyForRpRF�j</br>
    /// <br></br>
    /// <br>Update Note: �������i���̃}�X�^�̑S���[�J�[�p�̑Ή�</br>
    /// <br>Programmer : 21024�@���X�� ��</br>
    /// <br>Date       : 2009/10/23</br>
    /// <br></br>
    /// <br>Update Note: BL�������̕��i���k���@�̏C��(MANTIS[0014498])</br>
    /// <br>Programmer : 21024�@���X�� ��</br>
    /// <br>Date       : 2009/11/09</br>
    /// <br></br>
    /// <br>Update Note: �������x�̃`���[�j���O(MANTIS[0014934])</br>
    /// <br>             �@���q�̌����\�a�k�R�[�h�̌����N�G���̏C��</br>
    /// <br>             �ABL�R�[�h�����̃��C���N�G���̏C��</br>
    /// <br>Programmer : 21024�@���X�� ��</br>
    /// <br>Date       : 2010/01/25</br>
    /// <br></br>
    /// <br>Update Note: �������x�̃`���[�j���O</br>
    /// <br>Programmer : 22008�@���� ���n</br>
    /// <br>Date       : 2010/04/19</br>
    /// <br></br>
    /// <br>Update Note: ���R�����I�v�V�����Ή�</br>
    /// <br>Programmer : 22018�@��� ���b</br>
    /// <br>Date       : 2010/04/28</br>
    /// <br></br>
    /// <br>Update Note: ���ʕ�����</br>
    /// <br>               ���R���� 2010/04/28 �̑g��</br>
    /// <br>               �i��2010/04/19���Ƃ̓����ɂ�菈�������������Ă���ׁA2010/06/04�̃R�����g�j</br>
    /// <br>Programmer : 22018�@��� ���b</br>
    /// <br>Date       : 2010/06/04</br>
    /// <br></br>
    /// <br>Update Note: ��DB�����Ή�</br>
    /// <br>Programmer : 22008�@���� ���n</br>
    /// <br>Date       : 2010/06/14</br>
    /// <br></br>
    /// <br>Update Note: �a�k�R�[�h�������x�`���[�j���O</br>
    /// <br>Programmer : 22008�@���� ���n</br>
    /// <br>Date       : 2010/11/02</br>
    /// <br></br>
    /// <br>Update Note: �D�ǌ����A�g�}�X�^��UNION��UNION ALL�ɕύX</br>
    /// <br>Programmer : 21024�@���X�� ��</br>
    /// <br>Date       : 2010/11/22</br>
    /// <br></br>
    /// <br>Update Note: �ԑ�ԍ��̒��o�������C��(�N����else if�ɂ��Ȃ�)</br>
    /// <br>Programmer : 22018�@��� ���b</br>
    /// <br>Date       : 2011/03/07</br>
    /// <br></br>
    /// <br>Update Note: SCM�Ή�</br>
    /// <br>               BL�R�[�h�������̌������ʂɁA�������ϕ��i�R�[�h�ABL�R�[�h�}�ԗp���i���̂�ǉ�</br>
    /// <br>Programmer : 22018�@��� ���b</br>
    /// <br>Date       : 2011/05/18</br>
    /// <br></br>
    /// <br>Update Note: ��Q�Ή�</br>
    /// <br>               ���i�݌Ɉꊇ�o�^�C���̐V�K�o�^���ɁA�񋟂̏������i����������Ȃ��s����C��</br>
    /// <br>Programmer : 22008�@���� ���n</br>
    /// <br>Date       : 2011/06/23</br>
    /// <br></br>
    /// <br>Update Note: ���x����</br>
    /// <br>             ���x���ǋy�ѓ��ꕔ�i���k�������N�G�������ōs���悤�ɕύX</br>
    /// <br>Programmer : 20073�@�� �B</br>
    /// <br>Date       : 2012/01/24</br>
    /// <br>Update Note: �d�|�ꗗ�Ή� No.1742</br>
    /// <br>             ���i�݌Ƀ}�X�^�i�ꊇ�o�^�E�C���j�ɂăZ���N�g�R�[�h����̗D�Ǖ��i����������Ȃ���Q�̏C��</br>
    /// <br>Programmer : 22013 �v�� ����</br>
    /// <br>Date       : 2013/02/15</br>
    /// <br></br>
    /// <br>Update Note: SCM����</br>
    /// <br>             �D�ǌ����A�g�t���O�ǉ�(�_�~�[�i�Ԕ��ʗp)</br>
    /// <br>Programmer : 20056 ���n ���</br>
    /// <br>Date       : 2013/02/12</br>
    /// <br></br>
    /// <br>Update Note: 10900269-00 SPK�ԑ�ԍ�������Ή�</br>
    /// <br>             VIN�R�[�h�ɂ��i�������ǉ�</br>
    /// <br>             VIN���YNo.(�n��)�EVIN���YNo.(�I��)�̎擾�����ǉ�</br>
    /// <br>Programmer : FSI�֓� �a�G</br>
    /// <br>Date       : 2013/03/27</br>
    /// <br></br>
    /// <br>Update Note: �Ǘ��ԍ�  11070076-00  PM-SCM���x���� �t�F�[�Y�Q�Ή�</br>
    /// <br>                                    13.�t���^���Œ�ԍ�����̂a�k�R�[�h�����񐔉��ǑΉ�</br>
    /// <br>                                    14.���׎捞�敪�̍X�V���@�����ǑΉ�</br>
    /// <br>                                    15.SCM�󔭒��f�[�^�i�ԗ����j�擾���@���ǑΉ�</br>
    /// <br>                                    16.�����i�������ǑΉ�</br>
    /// <br>                                    17.�D�Ǖi�������ǑΉ�</br>
    /// <br>Programmer : 30744 ���� ����q</br>
    /// <br>Date       : 2014/05/13</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class OfferPartsInfDB : RemoteDB, IOfferPartsInfo
    {
        #region �����ϐ���`

        /// <summary>
        /// �J���[�p���[�N�N���X
        /// </summary>
        private class colorwk
        {
            #region
            public int FULLMODELFIXEDNORF;
            public int TBSPARTSCODERF;
            public int TBSPARTSCDDERIVEDNORF;
            public string FIGSHAPENORF = "";
            //public int SHAPENOINSIDEROWNORF;
            #endregion
        }
        /// <summary>
        /// �g�����p���[�N�N���X
        /// </summary>
        private class trimwk
        {
            #region
            public int FULLMODELFIXEDNORF;
            public int TBSPARTSCODERF;
            public int TBSPARTSCDDERIVEDNORF;
            public string FIGSHAPENORF = "";
            //public int SHAPENOINSIDEROWNORF;
            #endregion
        }
        /// <summary>
        /// �����p���[�N�N���X
        /// </summary>
        private class equipwk
        {
            #region
            public int FULLMODELFIXEDNORF;
            public int TBSPARTSCODERF;
            public int TBSPARTSCDDERIVEDNORF;
            public string FIGSHAPENORF = "";
            //public int SHAPENOINSIDEROWNORF;
            #endregion
        }

        private ArrayList alcolorwk;
        private ArrayList altrimwk;
        private ArrayList alequipwk;
        private int PartsNarrowingCode;
        #endregion

        #region [ �R���X�g���N�^ ]
        /// <summary>
        ///�@��Ə��擾DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : 99033�@��{�@�E</br>
        /// <br>Date       : 2005.04.14</br>
        /// </remarks>
        public OfferPartsInfDB()
            :
            base("PMTKD06163D", "Broadleaf.Application.Remoting.OfferPartsInfDB", "OFFERPARTSINFRF")
        {
        }
        #endregion

        #region [ ���i���̎擾 ]
        /// <summary>
        /// �i���擾(�S�p)
        /// </summary>
        /// <param name="makerCd">���[�J�R�[�h</param>
        /// <param name="partsNo">�n�C�t���t�i��</param>
        /// <param name="name">�i��</param>
        /// <returns></returns>
        public int GetPartsName(int makerCd, string partsNo, out string name)
        {
            return GetPartsNameProc(makerCd, partsNo, out name, 0);
        }

        /// <summary>
        /// �i���擾(���p)
        /// </summary>
        /// <param name="makerCd">���[�J�R�[�h</param>
        /// <param name="partsNo">�n�C�t���t�i��</param>
        /// <param name="name">�i��</param>
        /// <returns></returns>
        public int GetPartsNameKana(int makerCd, string partsNo, out string name)
        {
            return GetPartsNameProc(makerCd, partsNo, out name, 1);
        }

        private int GetPartsNameProc(int makerCd, string partsNo, out string name, int mode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            string nameString = "";
            if (mode == 0)
            {
                nameString = "MAKEROFFERPARTSNAMERF";
            }
            else
            {
                nameString = "MAKEROFFERPARTSKANARF";
            }

            // -- UPD 2010/06/14 ----------------------------------------->>>
            //string query = "SELECT " + nameString + " MAKEROFFERPARTSNAMERF FROM PTMKRPRICERF "
            string query = "SELECT " + nameString + " MAKEROFFERPARTSNAMERF FROM PTMKRPRICEPMRF AS PTMKRPRICERF "
            // -- UPD 2010/06/14 -----------------------------------------<<<
                         + "WHERE NEWPRTSNOWITHHYPHENRF = @PARTSNO AND MAKERCODERF = @MAKERCODE ";
            name = string.Empty;

            SqlConnection sqlConnection = CreateSqlConnection();
            if (sqlConnection == null)
            {
                return 99;
            }
            sqlConnection.Open();

            SqlCommand sqlCommand = null;
            try
            {
                sqlCommand = new SqlCommand(query, sqlConnection);
                ((SqlParameter)sqlCommand.Parameters.Add("@PARTSNO", SqlDbType.NVarChar)).Value = partsNo;
                ((SqlParameter)sqlCommand.Parameters.Add("@MAKERCODE", SqlDbType.Int)).Value = makerCd;
                object ret = sqlCommand.ExecuteScalar();
                if (ret != null)
                {
                    name = ret.ToString();
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null)
                    sqlCommand.Dispose();
                if (sqlConnection != null)
                    sqlConnection.Dispose();
            }

            return status;
        }
        #endregion

        #region [ GetPartsInf(�������i����) ]
        /// <summary>
        /// PM.NS�p���i����
        /// </summary>
        /// <param name="InPara">�����p�����[�^</param>		
        /// <param name="RetParts"></param>
        /// <param name="color"></param>
        /// <param name="trim"></param>
        /// <param name="equip"></param>
        /// <param name="prtsubst"></param>
        /// <param name="partsModelLnkWork"></param>
        /// <param name="RetCnt"></param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �p�����[�^�Ŏw�肳�ꂽ���i�̏����������܂��B</br>
        /// <br>Programmer : 99033�@��{�@�E</br>
        /// <br>Date       : 2006.11.14</br>
        public int GetPartsInf(GetPartsInfPara InPara, ref object RetParts, ref object color,
            ref object trim, ref object equip, ref object prtsubst, out List<PartsModelLnkWork> partsModelLnkWork, out long RetCnt)
        {
            int status = 0;
            SqlConnection sqlConnection = null;

            //�߂菉����
            RetCnt = 0;
            partsModelLnkWork = new List<PartsModelLnkWork>();

            ArrayList alRetParts = new ArrayList();
            ArrayList alcolor = new ArrayList();
            ArrayList altrim = new ArrayList();
            ArrayList alequip = new ArrayList();
            ArrayList alprtsubst = new ArrayList();

            CustomSerializeArrayList RetPartsCustomSerializeArrayList = new CustomSerializeArrayList();//���i���
            CustomSerializeArrayList colorCustomSerializeArrayList = new CustomSerializeArrayList();//�J���[���
            CustomSerializeArrayList trimCustomSerializeArrayList = new CustomSerializeArrayList();//�g�������
            CustomSerializeArrayList equipCustomSerializeArrayList = new CustomSerializeArrayList();//�������
            CustomSerializeArrayList prtsubstCustomSerializeArrayList = new CustomSerializeArrayList();//���i��֏��

            RetParts = RetPartsCustomSerializeArrayList;
            color = colorCustomSerializeArrayList;
            trim = trimCustomSerializeArrayList;
            equip = equipCustomSerializeArrayList;
            prtsubst = prtsubstCustomSerializeArrayList;

            try
            {
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null)
                {
                    return 99;
                }
                sqlConnection.Open();

                //���i�i��@0:���Y�N��,1;�ԑ�ԍ�
                //int PartsNarrowingCode = 0;
                //if ((InPara.MakerCode != 0) && (InPara.ModelCode != 0))
                //    ReadModelNameRF(InPara.MakerCode, InPara.ModelCode, InPara.ModelSubCode, ref PartsNarrowingCode, ref sqlConnection);

                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

                //�������������i�������C��
                status = SearchPartsInf(InPara, ref alRetParts, ref partsModelLnkWork, ref sqlConnection);

                if (status == 0)
                {
                    //�J���[���o
                    ExtrColorAll(null, ref alRetParts, ref alcolor, ref sqlConnection);
                    //Trim���o
                    ExtrTrimAll(null, ref alRetParts, ref altrim, ref sqlConnection);
                    //�������o
                    ExtrEquipAll(null, ref alRetParts, ref alequip, ref sqlConnection);

                    //���i��֒��o
                    if (InPara.NoSubst == 0)
                        ExtrPrtsubstAll(InPara, ref alRetParts, ref alprtsubst, ref sqlConnection);
                    if (InPara.TbsPartsCode != 0) // BL������
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 DEL
                        //SearchNewPartsInf(alRetParts, ref alprtsubst, ref sqlConnection);
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 ADD
                        SearchNewPartsInf( InPara, alRetParts, ref alprtsubst, ref sqlConnection );
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 ADD
                }

            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            //======���ʂ�CustomSerializeArrayList�ɑ��
            RetPartsCustomSerializeArrayList.Add(alRetParts);           //���i���
            colorCustomSerializeArrayList.Add(alcolor);                 //�J���[���
            trimCustomSerializeArrayList.Add(altrim);                   //�g�������
            equipCustomSerializeArrayList.Add(alequip);                 //�������
            prtsubstCustomSerializeArrayList.Add(alprtsubst);           //���i��֏��


            RetCnt = alRetParts.Count;

            return status;
        }

        // --- ADD m.suzuki 2010/04/28 ---------->>>>>
        /// <summary>
        /// PM.NS�p���i�����i���R�����ł̋@�\�ǉ��܂ށj
        /// </summary>
        /// <param name="InPara">�����p�����[�^</param>		
        /// <param name="RetParts"></param>
        /// <param name="color"></param>
        /// <param name="trim"></param>
        /// <param name="equip"></param>
        /// <param name="prtsubst"></param>
        /// <param name="partsModelLnkWork"></param>
        /// <param name="retPartsFreeSearch"></param>
        /// <param name="prtsubstFreeSearch"></param>
        /// <param name="retPrimParts"></param>
        /// <param name="retPrimPrice"></param>
        /// <param name="retPrimSet"></param>
        /// <param name="retPrimSetPrice"></param>
        /// <param name="RetCnt"></param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �p�����[�^�Ŏw�肳�ꂽ���i�̏����������܂��B</br>
        /// <br>Programmer : 22018�@��� ���b</br>
        /// <br>Date       : 2010/04/27</br>
        public int GetPartsInf( GetPartsInfPara InPara, ref object RetParts, ref object color,
            ref object trim, ref object equip, ref object prtsubst, out List<PartsModelLnkWork> partsModelLnkWork,
            ref object retPartsFreeSearch, ref object prtsubstFreeSearch,
            ref object retPrimParts, ref object retPrimPrice, ref object retPrimSet, ref object retPrimSetPrice,
            out long RetCnt )
        {
            int status = 0;
            SqlConnection sqlConnection = null;

            //�߂菉����
            RetCnt = 0;
            partsModelLnkWork = new List<PartsModelLnkWork>();

            ArrayList alRetParts = new ArrayList();
            ArrayList alcolor = new ArrayList();
            ArrayList altrim = new ArrayList();
            ArrayList alequip = new ArrayList();
            ArrayList alprtsubst = new ArrayList();
            ArrayList alRetPartsFS = new ArrayList();
            ArrayList alprtsubstFS = new ArrayList();
            ArrayList alPrimPartsFS = new ArrayList();
            ArrayList alPrimPriceFS = new ArrayList();
            ArrayList alPrimSetFS = new ArrayList();
            ArrayList alPrimSetPriceFS = new ArrayList();

            CustomSerializeArrayList RetPartsCustomSerializeArrayList = new CustomSerializeArrayList();//���i���
            CustomSerializeArrayList colorCustomSerializeArrayList = new CustomSerializeArrayList();//�J���[���
            CustomSerializeArrayList trimCustomSerializeArrayList = new CustomSerializeArrayList();//�g�������
            CustomSerializeArrayList equipCustomSerializeArrayList = new CustomSerializeArrayList();//�������
            CustomSerializeArrayList prtsubstCustomSerializeArrayList = new CustomSerializeArrayList();//���i��֏��
            CustomSerializeArrayList RetPartsCustomSerializeArrayListFS = new CustomSerializeArrayList();//���i���(���R�����p)
            CustomSerializeArrayList prtsubstCustomSerializeArrayListFS = new CustomSerializeArrayList();//���i��֏��(���R�����p)
            CustomSerializeArrayList retPrimePartsCustomSerializeArrayListFS = new CustomSerializeArrayList();//�D�Ǖ��i(���R�����p)
            CustomSerializeArrayList retPrimePriceCustomSerializeArrayListFS = new CustomSerializeArrayList();//�D�Ǖ��i���i(���R�����p)
            CustomSerializeArrayList retPrimeSetCustomSerializeArrayListFS = new CustomSerializeArrayList();//�D�ǃZ�b�g(���R�����p)
            CustomSerializeArrayList retPrimeSetPriceCustomSerializeArrayListFS = new CustomSerializeArrayList();//�D�ǃZ�b�g���i(���R�����p)

            RetParts = RetPartsCustomSerializeArrayList;
            color = colorCustomSerializeArrayList;
            trim = trimCustomSerializeArrayList;
            equip = equipCustomSerializeArrayList;
            prtsubst = prtsubstCustomSerializeArrayList;
            // ���R�����p�i�����j
            retPartsFreeSearch = RetPartsCustomSerializeArrayListFS;
            prtsubstFreeSearch = prtsubstCustomSerializeArrayListFS;
            // ���R�����p�i�D�ǁj
            retPrimParts = retPrimePartsCustomSerializeArrayListFS;
            retPrimPrice = retPrimePriceCustomSerializeArrayListFS;
            retPrimSet = retPrimeSetCustomSerializeArrayListFS;
            retPrimSetPrice = retPrimeSetPriceCustomSerializeArrayListFS;

            try
            {
                sqlConnection = CreateSqlConnection();
                if ( sqlConnection == null )
                {
                    return 99;
                }
                sqlConnection.Open();

                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

                //�������������i�������C��
                if ( !InPara.NormalSearchExclude )
                {
                    status = SearchPartsInf( InPara, ref alRetParts, ref partsModelLnkWork, ref sqlConnection );

                    if ( status == 0 )
                    {
                        //�J���[���o
                        ExtrColorAll( null, ref alRetParts, ref alcolor, ref sqlConnection );
                        //Trim���o
                        ExtrTrimAll( null, ref alRetParts, ref altrim, ref sqlConnection );
                        //�������o
                        ExtrEquipAll( null, ref alRetParts, ref alequip, ref sqlConnection );

                        //���i��֒��o
                        if ( InPara.NoSubst == 0 )
                            ExtrPrtsubstAll( InPara, ref alRetParts, ref alprtsubst, ref sqlConnection );
                        if ( InPara.TbsPartsCode != 0 ) // BL������
                            SearchNewPartsInf( InPara, alRetParts, ref alprtsubst, ref sqlConnection );
                    }
                }

                //�����������ȉ��A���R�����p
                if ( InPara.SearchKeyList != null && InPara.SearchKeyList.Count > 0 )
                {
                    //----------------------------------------
                    // ���� �����i�Ԍ���
                    //----------------------------------------
                    // ���R�������i(InPara.SearchKeyList�Ŏw��)�ɕR�t���񋟏����̌���
                    int fsStatus = GetGenuinePartsInfForFreeSearch( InPara, alRetPartsFS, sqlConnection );
                    if ( fsStatus == 0 && alRetPartsFS != null && alRetPartsFS.Count > 0 )
                    {
                        //���i��֒��o
                        if ( InPara.NoSubst == 0 )
                            ExtrPrtsubstAll( InPara, ref alRetPartsFS, ref alprtsubstFS, ref sqlConnection );
                        if ( InPara.TbsPartsCode != 0 ) // BL������
                            SearchNewPartsInf( InPara, alRetPartsFS, ref alprtsubstFS, ref sqlConnection );
                    }
                    //----------------------------------------
                    // �D�� �����i�Ԍ���
                    //----------------------------------------
                    // ���R�������i(InPara.SearchKeyList�Ŏw��)�ɕR�t���񋟗D�ǂ̌���
                    GetPrimePartsInfWithSetProc( InPara.TbsPartsCode, InPara.SearchKeyList, ref alPrimPartsFS, ref alPrimPriceFS, ref alPrimSetFS, ref alPrimSetPriceFS, ref sqlConnection );

                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if ( sqlConnection != null )
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            //======���ʂ�CustomSerializeArrayList�ɑ��
            RetPartsCustomSerializeArrayList.Add( alRetParts );           //���i���
            colorCustomSerializeArrayList.Add( alcolor );                 //�J���[���
            trimCustomSerializeArrayList.Add( altrim );                   //�g�������
            equipCustomSerializeArrayList.Add( alequip );                 //�������
            prtsubstCustomSerializeArrayList.Add( alprtsubst );           //���i��֏��

            // ���R�����p�i�����j
            RetPartsCustomSerializeArrayListFS.Add( alRetPartsFS );       //���i���(���R�����p)
            prtsubstCustomSerializeArrayListFS.Add( alprtsubstFS );       //���i��֏��(���R�����p)
            // ���R�����p�i�D�ǁj
            retPrimePartsCustomSerializeArrayListFS.Add( alPrimPartsFS );       //�D�Ǖ��i(���R�����p)
            retPrimePriceCustomSerializeArrayListFS.Add( alPrimPriceFS );       //�D�Ǖ��i���i(���R�����p)
            retPrimeSetCustomSerializeArrayListFS.Add( alPrimSetFS );           //�D�ǃZ�b�g(���R�����p)
            retPrimeSetPriceCustomSerializeArrayListFS.Add( alPrimSetPriceFS ); //�D�ǃZ�b�g���i(���R�����p)

            RetCnt = alRetParts.Count;

            return status;
        }

        // ADD 2014/05/13 PM-SCM���x���� �t�F�[�Y�Q��16.�����i�������ǑΉ� ---------------------------------->>>>>
        /// <summary>
        /// PM.NS�p���i�����i���R�����ł̋@�\�ǉ��܂ށj�i�����񓚏�����p�j
        /// </summary>
        /// <param name="InPara">�����p�����[�^</param>		
        /// <param name="RetParts"></param>
        /// <param name="color"></param>
        /// <param name="trim"></param>
        /// <param name="equip"></param>
        /// <param name="prtsubst"></param>
        /// <param name="partsModelLnkWork"></param>
        /// <param name="retPartsFreeSearch"></param>
        /// <param name="prtsubstFreeSearch"></param>
        /// <param name="retPrimParts"></param>
        /// <param name="retPrimPrice"></param>
        /// <param name="retPrimSet"></param>
        /// <param name="retPrimSetPrice"></param>
        /// <param name="RetCnt"></param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �p�����[�^�Ŏw�肳�ꂽ���i�̏����������܂��B</br>
        /// <br>Programmer : </br>
        /// <br>Date       : </br>
        public int GetPartsInf(ArrayList InParaList, ref object RetParts, ref object color,
            ref object trim, ref object equip, ref object prtsubst, out List<PartsModelLnkWork> partsModelLnkWork,
            ref object retPartsFreeSearch, ref object prtsubstFreeSearch,
            ref object retPrimParts, ref object retPrimPrice, ref object retPrimSet, ref object retPrimSetPrice,
            out long RetCnt)
        {
            int status = 0;
            SqlConnection sqlConnection = null;

            List<GetPartsInfPara> InParaListWork = new List<GetPartsInfPara>((GetPartsInfPara[])InParaList.ToArray(typeof(GetPartsInfPara)));
            //�߂菉����
            RetCnt = 0;
            partsModelLnkWork = new List<PartsModelLnkWork>();

            ArrayList alRetParts = new ArrayList();
            ArrayList alcolor = new ArrayList();
            ArrayList altrim = new ArrayList();
            ArrayList alequip = new ArrayList();
            ArrayList alprtsubst = new ArrayList();
            ArrayList alRetPartsFS = new ArrayList();
            ArrayList alprtsubstFS = new ArrayList();
            ArrayList alPrimPartsFS = new ArrayList();
            ArrayList alPrimPriceFS = new ArrayList();
            ArrayList alPrimSetFS = new ArrayList();
            ArrayList alPrimSetPriceFS = new ArrayList();

            CustomSerializeArrayList RetPartsCustomSerializeArrayList = new CustomSerializeArrayList();//���i���
            CustomSerializeArrayList colorCustomSerializeArrayList = new CustomSerializeArrayList();//�J���[���
            CustomSerializeArrayList trimCustomSerializeArrayList = new CustomSerializeArrayList();//�g�������
            CustomSerializeArrayList equipCustomSerializeArrayList = new CustomSerializeArrayList();//�������
            CustomSerializeArrayList prtsubstCustomSerializeArrayList = new CustomSerializeArrayList();//���i��֏��
            CustomSerializeArrayList RetPartsCustomSerializeArrayListFS = new CustomSerializeArrayList();//���i���(���R�����p)
            CustomSerializeArrayList prtsubstCustomSerializeArrayListFS = new CustomSerializeArrayList();//���i��֏��(���R�����p)
            CustomSerializeArrayList retPrimePartsCustomSerializeArrayListFS = new CustomSerializeArrayList();//�D�Ǖ��i(���R�����p)
            CustomSerializeArrayList retPrimePriceCustomSerializeArrayListFS = new CustomSerializeArrayList();//�D�Ǖ��i���i(���R�����p)
            CustomSerializeArrayList retPrimeSetCustomSerializeArrayListFS = new CustomSerializeArrayList();//�D�ǃZ�b�g(���R�����p)
            CustomSerializeArrayList retPrimeSetPriceCustomSerializeArrayListFS = new CustomSerializeArrayList();//�D�ǃZ�b�g���i(���R�����p)

            RetParts = RetPartsCustomSerializeArrayList;
            color = colorCustomSerializeArrayList;
            trim = trimCustomSerializeArrayList;
            equip = equipCustomSerializeArrayList;
            prtsubst = prtsubstCustomSerializeArrayList;
            // ���R�����p�i�����j
            retPartsFreeSearch = RetPartsCustomSerializeArrayListFS;
            prtsubstFreeSearch = prtsubstCustomSerializeArrayListFS;
            // ���R�����p�i�D�ǁj
            retPrimParts = retPrimePartsCustomSerializeArrayListFS;
            retPrimPrice = retPrimePriceCustomSerializeArrayListFS;
            retPrimSet = retPrimeSetCustomSerializeArrayListFS;
            retPrimSetPrice = retPrimeSetPriceCustomSerializeArrayListFS;

            try
            {
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null)
                {
                    return 99;
                }
                sqlConnection.Open();

                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

                foreach (GetPartsInfPara inPara in InParaListWork)
                {
                    alRetParts = new ArrayList();
                    alcolor = new ArrayList();
                    altrim = new ArrayList();
                    alequip = new ArrayList();
                    alprtsubst = new ArrayList();
                    alRetPartsFS = new ArrayList();
                    alprtsubstFS = new ArrayList();
                    alPrimPartsFS = new ArrayList();
                    alPrimPriceFS = new ArrayList();
                    alPrimSetFS = new ArrayList();
                    alPrimSetPriceFS = new ArrayList();

                    //�������������i�������C��
                    if (!inPara.NormalSearchExclude)
                    {
                        status = SearchPartsInf(inPara, ref alRetParts, ref partsModelLnkWork, ref sqlConnection);

                        if (status == 0)
                        {
                            //�J���[���o
                            ExtrColorAll(null, ref alRetParts, ref alcolor, ref sqlConnection);
                            //Trim���o
                            ExtrTrimAll(null, ref alRetParts, ref altrim, ref sqlConnection);
                            //�������o
                            ExtrEquipAll(null, ref alRetParts, ref alequip, ref sqlConnection);

                            //���i��֒��o
                            if (inPara.NoSubst == 0)
                                ExtrPrtsubstAll(inPara, ref alRetParts, ref alprtsubst, ref sqlConnection);
                            if (inPara.TbsPartsCode != 0) // BL������
                                SearchNewPartsInf(inPara, alRetParts, ref alprtsubst, ref sqlConnection);
                        }
                    }

                    //�����������ȉ��A���R�����p
                    if (inPara.SearchKeyList != null && inPara.SearchKeyList.Count > 0)
                    {
                        //----------------------------------------
                        // ���� �����i�Ԍ���
                        //----------------------------------------
                        // ���R�������i(InPara.SearchKeyList�Ŏw��)�ɕR�t���񋟏����̌���
                        int fsStatus = GetGenuinePartsInfForFreeSearch(inPara, alRetPartsFS, sqlConnection);
                        if (fsStatus == 0 && alRetPartsFS != null && alRetPartsFS.Count > 0)
                        {
                            //���i��֒��o
                            if (inPara.NoSubst == 0)
                                ExtrPrtsubstAll(inPara, ref alRetPartsFS, ref alprtsubstFS, ref sqlConnection);
                            if (inPara.TbsPartsCode != 0) // BL������
                                SearchNewPartsInf(inPara, alRetPartsFS, ref alprtsubstFS, ref sqlConnection);
                        }
                        //----------------------------------------
                        // �D�� �����i�Ԍ���
                        //----------------------------------------
                        // ���R�������i(InPara.SearchKeyList�Ŏw��)�ɕR�t���񋟗D�ǂ̌���
                        GetPrimePartsInfWithSetProc(inPara.TbsPartsCode, inPara.SearchKeyList, ref alPrimPartsFS, ref alPrimPriceFS, ref alPrimSetFS, ref alPrimSetPriceFS, ref sqlConnection);

                    }

                    //======���ʂ�CustomSerializeArrayList�ɑ��
                    //======���ʂ��[���̎��͋�̃f�[�^���쐬���Ēǉ��i�������Ή��̂��߁j
                    if (alRetParts.Count == 0) SetalRetParts(ref alRetParts);
                    RetPartsCustomSerializeArrayList.Add(alRetParts);           //���i���
                    if (alcolor.Count == 0) Setalcolor(ref alcolor);
                    colorCustomSerializeArrayList.Add(alcolor);                 //�J���[���
                    if (altrim.Count == 0) Setaltrim(ref altrim);
                    trimCustomSerializeArrayList.Add(altrim);                   //�g�������
                    if (alequip.Count == 0) Setalequip(ref alequip);
                    equipCustomSerializeArrayList.Add(alequip);                 //�������
                    if (alprtsubst.Count == 0) Setalprtsubst(ref alprtsubst);
                    prtsubstCustomSerializeArrayList.Add(alprtsubst);           //���i��֏��

                    // ���R�����p�i�����j
                    if (alRetPartsFS.Count == 0) SetalRetPartsFS(ref alRetPartsFS);
                    RetPartsCustomSerializeArrayListFS.Add(alRetPartsFS);       //���i���(���R�����p)
                    if (alprtsubstFS.Count == 0) SetalprtsubstFS(ref alprtsubstFS);
                    prtsubstCustomSerializeArrayListFS.Add(alprtsubstFS);       //���i��֏��(���R�����p)
                    // ���R�����p�i�D�ǁj
                    if (alPrimPartsFS.Count == 0) SetalPrimPartsFS(ref alPrimPartsFS);
                    retPrimePartsCustomSerializeArrayListFS.Add(alPrimPartsFS);       //�D�Ǖ��i(���R�����p)
                    if (alPrimPriceFS.Count == 0) SetalPrimPriceFS(ref alPrimPriceFS);
                    retPrimePriceCustomSerializeArrayListFS.Add(alPrimPriceFS);       //�D�Ǖ��i���i(���R�����p)
                    if (alPrimSetFS.Count == 0) SetalPrimSetFS(ref alPrimSetFS);
                    retPrimeSetCustomSerializeArrayListFS.Add(alPrimSetFS);           //�D�ǃZ�b�g(���R�����p)
                    if (alPrimSetPriceFS.Count == 0) SetalPrimSetPriceFS(ref alPrimSetPriceFS);
                    retPrimeSetPriceCustomSerializeArrayListFS.Add(alPrimSetPriceFS); //�D�ǃZ�b�g���i(���R�����p)

                    RetCnt = RetCnt + alRetParts.Count;

                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            if (RetCnt != 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            return status;
        }

        #region ��񏉊����ݒ� 
        /// <summary>
        ///  ���i��񏉊����ݒ�
        /// </summary>
        /// <param name="alRetParts"></param>
        private void SetalRetParts(ref ArrayList alRetParts)
        {
            RetPartsInf mf = new RetPartsInf();

            mf.AutoEstimatePartsCd = string.Empty;
            mf.CatalogPartsMakerCd = 0;
            mf.CategorySignModel = string.Empty;
            mf.ClgPrtsNoWithHyphen = string.Empty;
            mf.ColdDistrictsFlag = 0;
            mf.ColorNarrowingFlag = 0;
            mf.EquipNarrowingFlag = 0;
            mf.ExhaustGasSign = string.Empty;
            mf.FigShapeNo = string.Empty;
            mf.FullModelFixedNo = 0;
            mf.MakerOfferPartsKana = string.Empty;
            mf.MakerOfferPartsName = string.Empty;
            mf.ModelPrtsAblsFrameNo = 0;
            mf.ModelPrtsAblsYm = 0;
            mf.ModelPrtsAdptFrameNo = 0;
            mf.ModelPrtsAdptYm = 0;
            mf.NewPrtsNoNoneHyphen = string.Empty;
            mf.NewPrtsNoWithHyphen = string.Empty;
            mf.OfferDate = DateTime.MinValue;
            mf.OpenPriceDiv = 0;
            mf.PartsCode = 0;
            mf.PartsLayerCd = string.Empty;
            mf.PartsName = string.Empty;
            mf.PartsNameKana = string.Empty;
            mf.PartsNarrowingCode = 0;
            mf.PartsOpNm = string.Empty;
            mf.PartsPrice = 0;
            mf.PartsPriceStDate = DateTime.MinValue;
            mf.PartsQty = 0;
            mf.PartsSearchCode = 0;
            mf.PartsUniqueNo = 0;
            mf.PriceOfferDate = DateTime.MinValue;
            mf.PrimeJoinLnkFlg = 0;
            mf.SeriesModel = string.Empty;
            mf.SrchPNmAcqrCarMkrCd = 0;
            mf.StandardName = string.Empty;
            mf.TbsPartsCdDerivedNm = string.Empty;
            mf.TbsPartsCdDerivedNo = 0;
            mf.TbsPartsCode = 0;
            mf.TrimNarrowingFlag = 0;
            mf.VinProduceEndNo = 0;
            mf.VinProduceStartNo = 0;
            mf.WorkOrPartsDivNm = string.Empty;

            alRetParts.Add(mf);
        }
        /// <summary>
        ///  �J���[��񏉊����ݒ�
        /// </summary>
        /// <param name="alcolor"></param>
        private void Setalcolor(ref ArrayList alcolor)
        {
            PartsColorWork mf = new PartsColorWork();

            mf.ColorCdInfoNo = string.Empty;
            mf.PartsProperNo = 0;

            alcolor.Add(mf);

        }
        /// <summary>
        ///  �g������񏉊����ݒ�
        /// </summary>
        /// <param name="altrim"></param>
        private void Setaltrim(ref ArrayList altrim)
        {
            PartsTrimWork mf = new PartsTrimWork();

            mf.PartsProperNo = 0;
            mf.TrimCode = string.Empty;

            altrim.Add(mf);
        }
        /// <summary>
        ///  ������񏉊����ݒ�
        /// </summary>
        /// <param name="alequip"></param>
        private void Setalequip(ref ArrayList alequip)
        {
            PartsEquipWork mf = new PartsEquipWork();

            mf.EquipmentCode = 0;
            mf.EquipmentGenreCd = 0;
            mf.PartsProperNo = 0;

            alequip.Add(mf);
        }
        /// <summary>
        ///  ���i��֏�񏉊����ݒ�
        /// </summary>
        /// <param name="alprtsubst"></param>
        private void Setalprtsubst(ref ArrayList alprtsubst)
        {
            PartsSubstWork mf = new PartsSubstWork();

            mf.CatalogPartsMakerCd = 0;
            mf.MainOrSubPartsDivCd = 0;
            mf.MakerOfferPartsKana = string.Empty;
            mf.MakerOfferPartsName = string.Empty;
            mf.NewPartsNoWithHyphen = string.Empty;
            mf.NewPrtsNoNoneHyphen = string.Empty;
            mf.NPrtNoWithHypnDspOdr = 0;
            mf.OfferDate = DateTime.MinValue;
            mf.OldPartsNoWithHyphen = string.Empty;
            mf.OpenPriceDiv = 0;
            mf.PartsCode = 0;
            mf.PartsInfoCtrlFlg = 0;
            mf.PartsLayerCd = string.Empty;
            mf.PartsName = string.Empty;
            mf.PartsPluralSubstCmnt = string.Empty;
            mf.PartsPluralSubstFlg = 0;
            mf.PartsPrice = 0;
            mf.PartsPriceStDate = DateTime.MinValue;
            mf.PartsQty = 0;
            mf.PartsSearchCode = 0;
            mf.PlrlSubNewPrtNoHypn = string.Empty;
            mf.PriceOfferDate = DateTime.MinValue;
            mf.TbsPartsCdDerivedNo = 0;
            mf.TbsPartsCode = 0;

            alprtsubst.Add(mf);
        }
        /// <summary>
        ///  ���i���(���R�����p)�������ݒ�
        /// </summary>
        /// <param name="alRetPartsFS"></param>
        private void SetalRetPartsFS(ref ArrayList alRetPartsFS)
        {
            RetPartsInf mf = new RetPartsInf();

            mf.AutoEstimatePartsCd = string.Empty;
            mf.CatalogPartsMakerCd = 0;
            mf.CategorySignModel = string.Empty;
            mf.ClgPrtsNoWithHyphen = string.Empty;
            mf.ColdDistrictsFlag = 0;
            mf.ColorNarrowingFlag = 0;
            mf.EquipNarrowingFlag = 0;
            mf.ExhaustGasSign = string.Empty;
            mf.FigShapeNo = string.Empty;
            mf.FullModelFixedNo = 0;
            mf.MakerOfferPartsKana = string.Empty;
            mf.MakerOfferPartsName = string.Empty;
            mf.ModelPrtsAblsFrameNo = 0;
            mf.ModelPrtsAblsYm = 0;
            mf.ModelPrtsAdptFrameNo = 0;
            mf.ModelPrtsAdptYm = 0;
            mf.NewPrtsNoNoneHyphen = string.Empty;
            mf.NewPrtsNoWithHyphen = string.Empty;
            mf.OfferDate = DateTime.MinValue;
            mf.OpenPriceDiv = 0;
            mf.PartsCode = 0;
            mf.PartsLayerCd = string.Empty;
            mf.PartsName = string.Empty;
            mf.PartsNameKana = string.Empty;
            mf.PartsNarrowingCode = 0;
            mf.PartsOpNm = string.Empty;
            mf.PartsPrice = 0;
            mf.PartsPriceStDate = DateTime.MinValue;
            mf.PartsQty = 0;
            mf.PartsSearchCode = 0;
            mf.PartsUniqueNo = 0;
            mf.PriceOfferDate = DateTime.MinValue;
            mf.PrimeJoinLnkFlg = 0;
            mf.SeriesModel = string.Empty;
            mf.SrchPNmAcqrCarMkrCd = 0;
            mf.StandardName = string.Empty;
            mf.TbsPartsCdDerivedNm = string.Empty;
            mf.TbsPartsCdDerivedNo = 0;
            mf.TbsPartsCode = 0;
            mf.TrimNarrowingFlag = 0;
            mf.VinProduceEndNo = 0;
            mf.VinProduceStartNo = 0;
            mf.WorkOrPartsDivNm = string.Empty;

            alRetPartsFS.Add(mf);
        }
        /// <summary>
        ///  ���i��֏��(���R�����p)�������ݒ�
        /// </summary>
        /// <param name="alprtsubstFS"></param>
        private void SetalprtsubstFS(ref ArrayList alprtsubstFS)
        {
            PartsSubstWork mf = new PartsSubstWork();

            mf.CatalogPartsMakerCd = 0;
            mf.MainOrSubPartsDivCd = 0;
            mf.MakerOfferPartsKana = string.Empty;
            mf.MakerOfferPartsName = string.Empty;
            mf.NewPartsNoWithHyphen = string.Empty;
            mf.NewPrtsNoNoneHyphen = string.Empty;
            mf.NPrtNoWithHypnDspOdr = 0;
            mf.OfferDate = DateTime.MinValue;
            mf.OldPartsNoWithHyphen = string.Empty;
            mf.OpenPriceDiv = 0;
            mf.PartsCode = 0;
            mf.PartsInfoCtrlFlg = 0;
            mf.PartsLayerCd = string.Empty;
            mf.PartsName = string.Empty;
            mf.PartsPluralSubstCmnt = string.Empty;
            mf.PartsPluralSubstFlg = 0;
            mf.PartsPrice = 0;
            mf.PartsPriceStDate = DateTime.MinValue;
            mf.PartsQty = 0;
            mf.PartsSearchCode = 0;
            mf.PlrlSubNewPrtNoHypn = string.Empty;
            mf.PriceOfferDate = DateTime.MinValue;
            mf.TbsPartsCdDerivedNo = 0;
            mf.TbsPartsCode = 0;

            alprtsubstFS.Add(mf);
        }
        /// <summary>
        ///  �D�Ǖ��i(���R�����p)�������ݒ�
        /// </summary>
        /// <param name="alPrimPartsFS"></param>
        private void SetalPrimPartsFS(ref ArrayList alPrimPartsFS)
        {
            OfferJoinPartsRetWork mf = new OfferJoinPartsRetWork();

            mf.CatalogDeleteFlag = 0;
            mf.GoodsMGroup = 0;
            mf.JoinDestMakerCd = 0;
            mf.JoinDestPartsNo = string.Empty;
            mf.JoinDispOrder = 0;
            mf.JoinQty = 0;
            mf.JoinSourceMakerCode = 0;
            mf.JoinSourPartsNoNoneH = string.Empty;
            mf.JoinSourPartsNoWithH = string.Empty;
            mf.JoinSpecialNote = string.Empty;
            mf.OfferDate = DateTime.MinValue;
            mf.PartsAttribute = 0;
            mf.PartsLayerCd = string.Empty;
            mf.PrimePartsKanaName = string.Empty;
            mf.PrimePartsName = string.Empty;
            mf.PrimePartsSpecialNote = string.Empty;
            mf.PrmPartsIllustC = string.Empty;
            mf.PrmSetDtlNo1 = 0;
            mf.PrmSetDtlNo2 = 0;
            mf.SearchPartsFullName = string.Empty;
            mf.SearchPartsHalfName = string.Empty;
            mf.SetPartsFlg = 0;
            mf.SubstKubun = 0;
            mf.TbsPartsCdDerivedNo = 0;
            mf.TbsPartsCode = 0;

            alPrimPartsFS.Add(mf);

        }
        /// <summary>
        ///  �D�Ǖ��i���i(���R�����p)�������ݒ�
        /// </summary>
        /// <param name="alPrimPriceFS"></param>
        private void SetalPrimPriceFS(ref ArrayList alPrimPriceFS)
        {
            OfferJoinPriceRetWork mf = new OfferJoinPriceRetWork();

            mf.NewPrice = 0;
            mf.OfferDate = DateTime.MinValue;
            mf.OpenPriceDiv = 0;
            mf.PartsMakerCd = 0;
            mf.PriceStartDate = DateTime.MinValue;
            mf.PrimePartsNoWithH = string.Empty;
            mf.PrmSetDtlNo1 = 0;

            alPrimPriceFS.Add(mf);
        }
        /// <summary>
        ///  �D�ǃZ�b�g(���R�����p)�������ݒ�
        /// </summary>
        /// <param name="alPrimSetFS"></param>
        private void SetalPrimSetFS(ref ArrayList alPrimSetFS)
        {
            OfferSetPartsRetWork mf = new OfferSetPartsRetWork();

            mf.CatalogDeleteFlag = 0;
            mf.CatalogShapeNo = string.Empty;
            mf.GoodsMGroup = 0;
            mf.OfferDate = DateTime.MinValue;
            mf.PartsAttribute = 0;
            mf.PartsLayerCd = string.Empty;
            mf.PrimePartsKanaName = string.Empty;
            mf.PrimePartsName = string.Empty;
            mf.PrimePartsSpecialNote = string.Empty;
            mf.PrmPartsIllustC = string.Empty;
            mf.PrmPrtTbsPrtCd = 0;
            mf.PrmPrtTbsPrtCdDerivNo = 0;
            mf.SearchPartsFullName = string.Empty;
            mf.SearchPartsHalfName = string.Empty;
            mf.SetDispOrder = 0;
            mf.SetMainMakerCd = 0;
            mf.SetMainPartsNo = string.Empty;
            mf.SetName = string.Empty;
            mf.SetQty = 0;
            mf.SetSpecialNote = string.Empty;
            mf.SetSubMakerCd = 0;
            mf.SetSubPartsNo = string.Empty;
            mf.SubstKubun = 0;
            mf.TbsPartsCdDerivedNo = 0;
            mf.TbsPartsCode = 0;

            alPrimSetFS.Add(mf);
        }
        /// <summary>
        ///  �D�ǃZ�b�g���i(���R�����p)�������ݒ�
        /// </summary>
        /// <param name="alPrimSetPriceFS"></param>
        private void SetalPrimSetPriceFS(ref ArrayList alPrimSetPriceFS)
        {
            OfferJoinPriceRetWork mf = new OfferJoinPriceRetWork();

            mf.NewPrice = 0;
            mf.OfferDate = DateTime.MinValue;
            mf.OpenPriceDiv = 0;
            mf.PartsMakerCd = 0;
            mf.PriceStartDate = DateTime.MinValue;
            mf.PrimePartsNoWithH = string.Empty;
            mf.PrmSetDtlNo1 = 0;

            alPrimSetPriceFS.Add(mf);
        }
        #endregion //��񏉊����ݒ�

        // ADD 2014/05/13 PM-SCM���x���� �t�F�[�Y�Q��16.�����i�������ǑΉ� ----------------------------------<<<<<

        // ���x���P�e�X�g -------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// PM.NS�p���i�����i���R�����ł̋@�\�ǉ��܂ށj
        /// </summary>
        /// <param name="InPara">�����p�����[�^</param>		
        /// <param name="RetParts"></param>
        /// <param name="color"></param>
        /// <param name="trim"></param>
        /// <param name="equip"></param>
        /// <param name="prtsubst"></param>
        /// <param name="partsModelLnkWork"></param>
        /// <param name="retPartsFreeSearch"></param>
        /// <param name="prtsubstFreeSearch"></param>
        /// <param name="retPrimParts"></param>
        /// <param name="retPrimPrice"></param>
        /// <param name="retPrimSet"></param>
        /// <param name="retPrimSetPrice"></param>
        /// <param name="RetCnt"></param>
        /// <returns>STATUS</returns>
        public int GetPartsInfYYYY(GetPartsInfPara InPara, ref object RetParts, ref object color,
            ref object trim, ref object equip, ref object prtsubst, out List<PartsModelLnkWork> partsModelLnkWork,
            ref object retPartsFreeSearch, ref object prtsubstFreeSearch,
            ref object retPrimParts, ref object retPrimPrice, ref object retPrimSet, ref object retPrimSetPrice,
            out long RetCnt
            , List<object> foundAutoAnsItemStList)
        {
            int status = 0;
            SqlConnection sqlConnection = null;

            List<AutoAnsItemStForOffer> wkFoundAutoAnsItemStList = new List<AutoAnsItemStForOffer>();
            foreach (List<object> tgt in foundAutoAnsItemStList)
            {
                AutoAnsItemStForOffer wk = new AutoAnsItemStForOffer();
                wk.SectionCode = tgt[0].ToString().Trim();	// ���_�R�[�h
                wk.CustomerCode = (int)tgt[1];      // ���Ӑ�R�[�h
                wk.GoodsMGroup = (int)tgt[2];		// ���i�����ރR�[�h
                wk.BLGoodsCode = (int)tgt[3];       // BL���i�R�[�h
                wk.GoodsMakerCd = (int)tgt[4];      // ���i���[�J�[�R�[�h
                wk.PrmSetDtlNo2 = (int)tgt[5];      // �D�ǐݒ�ڍ׃R�[�h�Q
                wk.AutoAnswerDiv = (int)tgt[6];     // �����񓚋敪
                wk.PriorityOrder = (int)tgt[7];     // �D�揇��

                wkFoundAutoAnsItemStList.Add(wk);
            }

            //�߂菉����
            RetCnt = 0;
            partsModelLnkWork = new List<PartsModelLnkWork>();

            ArrayList alRetParts = new ArrayList();
            ArrayList alcolor = new ArrayList();
            ArrayList altrim = new ArrayList();
            ArrayList alequip = new ArrayList();
            ArrayList alprtsubst = new ArrayList();
            ArrayList alRetPartsFS = new ArrayList();
            ArrayList alprtsubstFS = new ArrayList();
            ArrayList alPrimPartsFS = new ArrayList();
            ArrayList alPrimPriceFS = new ArrayList();
            ArrayList alPrimSetFS = new ArrayList();
            ArrayList alPrimSetPriceFS = new ArrayList();

            CustomSerializeArrayList RetPartsCustomSerializeArrayList = new CustomSerializeArrayList();//���i���
            CustomSerializeArrayList colorCustomSerializeArrayList = new CustomSerializeArrayList();//�J���[���
            CustomSerializeArrayList trimCustomSerializeArrayList = new CustomSerializeArrayList();//�g�������
            CustomSerializeArrayList equipCustomSerializeArrayList = new CustomSerializeArrayList();//�������
            CustomSerializeArrayList prtsubstCustomSerializeArrayList = new CustomSerializeArrayList();//���i��֏��
            CustomSerializeArrayList RetPartsCustomSerializeArrayListFS = new CustomSerializeArrayList();//���i���(���R�����p)
            CustomSerializeArrayList prtsubstCustomSerializeArrayListFS = new CustomSerializeArrayList();//���i��֏��(���R�����p)
            CustomSerializeArrayList retPrimePartsCustomSerializeArrayListFS = new CustomSerializeArrayList();//�D�Ǖ��i(���R�����p)
            CustomSerializeArrayList retPrimePriceCustomSerializeArrayListFS = new CustomSerializeArrayList();//�D�Ǖ��i���i(���R�����p)
            CustomSerializeArrayList retPrimeSetCustomSerializeArrayListFS = new CustomSerializeArrayList();//�D�ǃZ�b�g(���R�����p)
            CustomSerializeArrayList retPrimeSetPriceCustomSerializeArrayListFS = new CustomSerializeArrayList();//�D�ǃZ�b�g���i(���R�����p)

            RetParts = RetPartsCustomSerializeArrayList;
            color = colorCustomSerializeArrayList;
            trim = trimCustomSerializeArrayList;
            equip = equipCustomSerializeArrayList;
            prtsubst = prtsubstCustomSerializeArrayList;
            // ���R�����p�i�����j
            retPartsFreeSearch = RetPartsCustomSerializeArrayListFS;
            prtsubstFreeSearch = prtsubstCustomSerializeArrayListFS;
            // ���R�����p�i�D�ǁj
            retPrimParts = retPrimePartsCustomSerializeArrayListFS;
            retPrimPrice = retPrimePriceCustomSerializeArrayListFS;
            retPrimSet = retPrimeSetCustomSerializeArrayListFS;
            retPrimSetPrice = retPrimeSetPriceCustomSerializeArrayListFS;

            try
            {
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null)
                {
                    return 99;
                }
                sqlConnection.Open();

                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

                //�������������i�������C��
                if (!InPara.NormalSearchExclude)
                {
                    status = SearchPartsInfYYYY(InPara, ref alRetParts, ref partsModelLnkWork, ref sqlConnection, wkFoundAutoAnsItemStList);

                    if (status == 0)
                    {
                        //�J���[���o
                        ExtrColorAll(null, ref alRetParts, ref alcolor, ref sqlConnection);
                        //Trim���o
                        ExtrTrimAll(null, ref alRetParts, ref altrim, ref sqlConnection);
                        //�������o
                        ExtrEquipAll(null, ref alRetParts, ref alequip, ref sqlConnection);

                        //���i��֒��o
                        if (InPara.NoSubst == 0)
                            ExtrPrtsubstAll(InPara, ref alRetParts, ref alprtsubst, ref sqlConnection);
                        if (InPara.TbsPartsCode != 0) // BL������
                            SearchNewPartsInf(InPara, alRetParts, ref alprtsubst, ref sqlConnection);
                    }
                }

                //�����������ȉ��A���R�����p
                if (InPara.SearchKeyList != null && InPara.SearchKeyList.Count > 0)
                {
                    //----------------------------------------
                    // ���� �����i�Ԍ���
                    //----------------------------------------
                    // ���R�������i(InPara.SearchKeyList�Ŏw��)�ɕR�t���񋟏����̌���
                    int fsStatus = GetGenuinePartsInfForFreeSearch(InPara, alRetPartsFS, sqlConnection);
                    if (fsStatus == 0 && alRetPartsFS != null && alRetPartsFS.Count > 0)
                    {
                        //���i��֒��o
                        if (InPara.NoSubst == 0)
                            ExtrPrtsubstAll(InPara, ref alRetPartsFS, ref alprtsubstFS, ref sqlConnection);
                        if (InPara.TbsPartsCode != 0) // BL������
                            SearchNewPartsInf(InPara, alRetPartsFS, ref alprtsubstFS, ref sqlConnection);
                    }
                    //----------------------------------------
                    // �D�� �����i�Ԍ���
                    //----------------------------------------
                    // ���R�������i(InPara.SearchKeyList�Ŏw��)�ɕR�t���񋟗D�ǂ̌���
                    GetPrimePartsInfWithSetProc(InPara.TbsPartsCode, InPara.SearchKeyList, ref alPrimPartsFS, ref alPrimPriceFS, ref alPrimSetFS, ref alPrimSetPriceFS, ref sqlConnection);

                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            //======���ʂ�CustomSerializeArrayList�ɑ��
            RetPartsCustomSerializeArrayList.Add(alRetParts);           //���i���
            colorCustomSerializeArrayList.Add(alcolor);                 //�J���[���
            trimCustomSerializeArrayList.Add(altrim);                   //�g�������
            equipCustomSerializeArrayList.Add(alequip);                 //�������
            prtsubstCustomSerializeArrayList.Add(alprtsubst);           //���i��֏��

            // ���R�����p�i�����j
            RetPartsCustomSerializeArrayListFS.Add(alRetPartsFS);       //���i���(���R�����p)
            prtsubstCustomSerializeArrayListFS.Add(alprtsubstFS);       //���i��֏��(���R�����p)
            // ���R�����p�i�D�ǁj
            retPrimePartsCustomSerializeArrayListFS.Add(alPrimPartsFS);       //�D�Ǖ��i(���R�����p)
            retPrimePriceCustomSerializeArrayListFS.Add(alPrimPriceFS);       //�D�Ǖ��i���i(���R�����p)
            retPrimeSetCustomSerializeArrayListFS.Add(alPrimSetFS);           //�D�ǃZ�b�g(���R�����p)
            retPrimeSetPriceCustomSerializeArrayListFS.Add(alPrimSetPriceFS); //�D�ǃZ�b�g���i(���R�����p)

            RetCnt = alRetParts.Count;

            return status;
        }
        // ���x���P�e�X�g --------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// �D�� �����i�Ԍ��� �Ăяo��
        /// </summary>
        /// <param name="blGoodsCode"></param>
        /// <param name="arrayList"></param>
        /// <param name="alPrimPartsFS"></param>
        /// <param name="alPrimPriceFS"></param>
        /// <param name="alPrimSetFS"></param>
        /// <param name="alPrimSetPriceFS"></param>
        /// <param name="sqlConnection"></param>
        /// <remarks>���p�����[�^�ݒ肵�A�ʃ����[�g�o�f���Ăяo���B</remarks>
        private int GetPrimePartsInfWithSetProc( int blGoodsCode, ArrayList arrayList, ref ArrayList alPrimPartsFS, ref ArrayList alPrimPriceFS, ref ArrayList alPrimSetFS, ref ArrayList alPrimSetPriceFS, ref SqlConnection sqlConnection )
        {
            PrimePartsInfDB primePartsInfDB = new PrimePartsInfDB();

            ArrayList paraWorkList = new ArrayList();

            # region [���o�������X�g�̐ݒ�]
            // �i�ԁE���[�J�[���X�g
            foreach ( OfrPrtsSrchCndWork cndWork in arrayList )
            {
                OfrPartsCondWork ofrPartsCondWork = new OfrPartsCondWork();
                ofrPartsCondWork.MakerCode = cndWork.MakerCode;
                ofrPartsCondWork.PrtsNo = cndWork.PrtsNo;
                paraWorkList.Add( ofrPartsCondWork );
            }
            # endregion

            return primePartsInfDB.GetPrimePartsInfForFreeSearch( blGoodsCode, paraWorkList, out alPrimPartsFS, out alPrimPriceFS, out alPrimSetFS, out alPrimSetPriceFS, sqlConnection );
        }
        // --- ADD m.suzuki 2010/04/28 ----------<<<<<

        /// <summary>
        /// ���i�̌���(PM.NS)
        /// </summary>
        /// <param name="InPara"></param>
        /// <param name="alRetParts"></param>
        /// <param name="partsModelLnkWork"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        /// <br>Programmer : 99033�@��{�@�E</br>
        /// <br>Date       : 2006.11.14</br>
        private int SearchPartsInf(GetPartsInfPara InPara, ref ArrayList alRetParts, ref List<PartsModelLnkWork> partsModelLnkWork, ref SqlConnection sqlConnection)
        {

            ArrayList RetInf = new ArrayList();
            ArrayList RetEquip = new ArrayList();

            alcolorwk = new ArrayList();
            altrimwk = new ArrayList();
            alequipwk = new ArrayList();

            //���i�i��@0:���Y�N��,1;�ԑ�ԍ�
            PartsNarrowingCode = 0;
            // --- UPD m.suzuki 2010/04/28 ---------->>>>>
            try
            {
                if ( (InPara.MakerCode != 0) && (InPara.ModelCode != 0) )
                    ReadModelNameRF( InPara, ref sqlConnection );
            }
            catch
            {
                // ReadModelNameRF�ŗ�O���������ꍇ�́A���R�����^���Ƃ݂Ȃ��B
                // ����BL�R�[�h�����̊Y���͖����Ƃ��邪��O�G���[�ɂ����ɑ��s����B
                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }
            // --- UPD m.suzuki 2010/04/28 ----------<<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            //���ʂ̏�����
            RetInf = new ArrayList();

            try
            {
                //���i����
                status = SearchPartsInfProc(InPara, ref RetInf, ref sqlConnection);

                if (status == 0)
                {
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/16 ADD
                    if ( InPara.PrtsNoWithHyphen == string.Empty && InPara.PrtsNoNoneHyphen == string.Empty )
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/16 ADD
                    {
                        //BL�R�[�h�̌����̏ꍇ�݈̂��k���|����
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 DEL
                        //CompressPartsRec( ref RetInf, ref partsModelLnkWork );
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 ADD
                        CompressPartsRec( InPara, ref RetInf, ref partsModelLnkWork );
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 ADD
                    }
                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = -1;
            }

            alRetParts = RetInf;

            return status;
        }

        // ���x���P�e�X�g -------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// ���i�̌���(PM.NS)
        /// </summary>
        /// <param name="InPara"></param>
        /// <param name="alRetParts"></param>
        /// <param name="partsModelLnkWork"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int SearchPartsInfYYYY(GetPartsInfPara InPara, ref ArrayList alRetParts, ref List<PartsModelLnkWork> partsModelLnkWork, ref SqlConnection sqlConnection, List<AutoAnsItemStForOffer> foundAutoAnsItemStList)
        {

            ArrayList RetInf = new ArrayList();
            ArrayList RetEquip = new ArrayList();

            alcolorwk = new ArrayList();
            altrimwk = new ArrayList();
            alequipwk = new ArrayList();

            //���i�i��@0:���Y�N��,1;�ԑ�ԍ�
            PartsNarrowingCode = 0;
            // --- UPD m.suzuki 2010/04/28 ---------->>>>>
            try
            {
                if ((InPara.MakerCode != 0) && (InPara.ModelCode != 0))
                    ReadModelNameRF(InPara, ref sqlConnection);
            }
            catch
            {
                // ReadModelNameRF�ŗ�O���������ꍇ�́A���R�����^���Ƃ݂Ȃ��B
                // ����BL�R�[�h�����̊Y���͖����Ƃ��邪��O�G���[�ɂ����ɑ��s����B
                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }
            // --- UPD m.suzuki 2010/04/28 ----------<<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            //���ʂ̏�����
            RetInf = new ArrayList();

            try
            {
                //���i����
                status = SearchPartsInfProcYYYY(InPara, ref RetInf, ref sqlConnection,foundAutoAnsItemStList);

                if (status == 0)
                {
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/16 ADD
                    if (InPara.PrtsNoWithHyphen == string.Empty && InPara.PrtsNoNoneHyphen == string.Empty)
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/16 ADD
                    {
                        //BL�R�[�h�̌����̏ꍇ�݈̂��k���|����
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 DEL
                        //CompressPartsRec( ref RetInf, ref partsModelLnkWork );
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 ADD
                        CompressPartsRec(InPara, ref RetInf, ref partsModelLnkWork);
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 ADD
                    }
                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = -1;
            }

            alRetParts = RetInf;

            return status;
        }
        // ���x���P�e�X�g --------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<


        #region [ Query ]
        private const string ctQryBLSearch =
            // --- UPD T.Nishi 2012/01/24 ---------->>>>>
            //       "SELECT "
            //     + "CLGPNOINFORF.OFFERDATERF, "
            //     + "CLGPNOINFORF.TBSPARTSCODERF, "
            //     + "CLGPNOINFORF.TBSPARTSCDDERIVEDNORF, "
            //     + "FIGSHAPENORF, "
            //     + "MODELPRTSADPTYMRF, "
            //     + "MODELPRTSABLSYMRF, "
            //     + "MODELPRTSADPTFRAMENORF, "
            //     + "MODELPRTSABLSFRAMENORF, "
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.27 DEL
            //     //+ "PARTSQTYRF, "
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.27 DEL
            //     + "CLGPNOINFORF.PARTSOPNMRF, "
            //     + "CLGPNOINFORF.STANDARDNAMERF, "
            //     + "CLGPNOINFORF.CATALOGPARTSMAKERCDRF, "
            //     + "CLGPNOINFORF.CLGPRTSNOWITHHYPHENRF, "
            //     + "PARTSMAINSUBGROUPENORF, "
            //     + "COLDDISTRICTSFLAGRF, "
            //     + "COLORNARROWINGFLAGRF, "
            //     + "TRIMNARROWINGFLAGRF, "
            //     + "EQUIPNARROWINGFLAGRF, "
            //     + "PTMKRPRICERF.OFFERDATERF AS PRICEOFFERDATE , "
            //     + "CLGPTNOEXCRF.NEWPRTSNOWITHHYPHENRF, "
            //     + "MAKEROFFERPARTSNAMERF, "
            //     + "PARTSPRICERF, "
            //     + "PARTSLAYERCDRF,"
            //     + "PARTSPRICESTDATERF,"
            //     + "MAKEROFFERPARTSKANARF,"
            //     + "OPENPRICEDIVRF,"
            //     + "CLGPNOINFORF.PARTSQTYFORRPRF, "
            //     + "CLGPNOINFORF.PARTSPROPERNORF, "
            //   // --- ADD m.suzuki 2011/05/18 ---------->>>>>
            //     + "CLGPNOINFORF.AUTOESTIMATEPARTSCDRF, "
            //     + "CLGPNOINFORF.TBSPARTSCDDERIVEDNMRF, "
            //   // --- ADD m.suzuki 2011/05/18 ----------<<<<<
            //     + "CLGPNOINDXRF.FULLMODELFIXEDNORF, "
            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.23 ADD
            //     + "CARMODELRF.SERIESMODELRF, "
            //     + "CARMODELRF.CATEGORYSIGNMODELRF, "
            //     + "CARMODELRF.EXHAUSTGASSIGNRF, "
            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.23 ADD
            //     + "SEARCHPRTNMRF.CARMAKERCODERF AS SRCHPNMACQRCARMKRCD ,"    // 2009/10/23 Add
            //     + "SEARCHPRTNMRF.SEARCHPARTSFULLNAMERF, "
            //     + "SEARCHPRTNMRF.SEARCHPARTSHALFNAMERF ";
                   "SELECT "
                 + "CLGPNOINFORF.OFFERDATERF, "
                 + "CLGPNOINFORF.TBSPARTSCODERF, "
                 + "CLGPNOINFORF.TBSPARTSCDDERIVEDNORF, "
                 + "CLGPNOINFORF.FIGSHAPENORF, "
                 + "CLGPNOINFORF.MODELPRTSADPTYMRF, "
                 + "CLGPNOINFORF.MODELPRTSABLSYMRF, "
                 + "CLGPNOINFORF.MODELPRTSADPTFRAMENORF, "
                 + "CLGPNOINFORF.MODELPRTSABLSFRAMENORF, "
                 + "CLGPNOINFORF.PARTSOPNMRF, "
                 + "CLGPNOINFORF.STANDARDNAMERF, "
                 + "CLGPNOINFORF.CATALOGPARTSMAKERCDRF, "
                 + "CLGPNOINFORF.CLGPRTSNOWITHHYPHENRF, "
                 + "CLGPNOINFORF.PARTSMAINSUBGROUPENORF, "
                 + "CLGPNOINFORF.COLDDISTRICTSFLAGRF, "
                 + "CLGPNOINFORF.COLORNARROWINGFLAGRF, "
                 + "CLGPNOINFORF.TRIMNARROWINGFLAGRF, "
                 + "CLGPNOINFORF.EQUIPNARROWINGFLAGRF, "
                 + "CLGPNOINFORF.PARTSQTYFORRPRF, "
                 + "CLGPNOINFORF.PARTSPROPERNORF, "
                 + "CLGPNOINFORF.AUTOESTIMATEPARTSCDRF, "
                 + "CLGPNOINFORF.TBSPARTSCDDERIVEDNMRF, "
                 + "CLGPNOINFORF.PRIMEJOINLNKFLGRF, " // �D�ǌ����A�g�t���O // 2013/02/12
                 + "CLGPNOINDXRF.FULLMODELFIXEDNORF ,"
                 + "CARMODELRF.SERIESMODELRF, "
                 + "CARMODELRF.CATEGORYSIGNMODELRF, "
                 + "CARMODELRF.EXHAUSTGASSIGNRF, "
                 // --- ADD 2013/03/27 ---------->>>>>
                 + "CLGPNOINFORF.VINPRODUCESTARTNORF ,"       // VIN���Y��(�n��)
                 + "CLGPNOINFORF.VINPRODUCEENDNORF ,"         // VIN���Y��(�I��)
                 // --- ADD 2013/03/27 ----------<<<<<
                 + "ROW_NUMBER() OVER(PARTITION BY "
                   + "CLGPNOINFORF.CATALOGPARTSMAKERCDRF, "   //�J�^���O���i���[�J�[�R�[�h
                   + "CLGPNOINFORF.CLGPRTSNOWITHHYPHENRF, "   //�n�C�t���t�J�^���O���i�i��
                   + "CLGPNOINFORF.PARTSQTYFORRPRF, "         //���i�p�s�x
                   + "CLGPNOINFORF.STANDARDNAMERF, "          //�K�i����
                   + "CLGPNOINFORF.PARTSOPNMRF, "             //���i�I�v�V��������
                   + "CLGPNOINFORF.MODELPRTSADPTYMRF, "       //�^���ʕ��i�̗p�N��
                   + "CLGPNOINFORF.MODELPRTSABLSYMRF, "       //�^���ʕ��i�p�~�N��
                   + "CLGPNOINFORF.MODELPRTSADPTFRAMENORF, "  //�^���ʕ��i�̗p�ԑ�ԍ�
                   + "CLGPNOINFORF.MODELPRTSABLSFRAMENORF  "  //�^���ʕ��i�p�~�ԑ�ԍ�
                   + "ORDER BY "
                   + "CARMODELRF.SERIESMODELRF, "
                   + "CARMODELRF.CATEGORYSIGNMODELRF, "
                   + "CARMODELRF.EXHAUSTGASSIGNRF, "
                   + "CLGPNOINFORF.CLGPRTSNOWITHHYPHENRF, "
                   + "CLGPNOINFORF.CATALOGPARTSMAKERCDRF, "
                   + "CLGPNOINFORF.MODELPRTSADPTYMRF "
                 + ") AS ROWNUM ";  
            // --- UPD T.Nishi 2012/01/24 ----------<<<<<

        private const string ctQryPartsNo =
                   "PTMKRPRICERF.OFFERDATERF, "
                 + "PTMKRPRICERF.TBSPARTSCODERF, "
                 + "PTMKRPRICERF.TBSPARTSCDDERIVEDNORF, "
                 + "PTMKRPRICERF.OFFERDATERF AS PRICEOFFERDATE , "
                 + "PTMKRPRICERF.MAKERCODERF, "
                 + "PTMKRPRICERF.NEWPRTSNOWITHHYPHENRF, "
                 + "PTMKRPRICERF.MAKEROFFERPARTSNAMERF, "
                 + "PTMKRPRICERF.PARTSPRICERF, "
                 + "PTMKRPRICERF.PARTSLAYERCDRF, "
                 + "PTMKRPRICERF.PARTSPRICESTDATERF, "
                 + "PTMKRPRICERF.MAKEROFFERPARTSKANARF,"
                 + "PTMKRPRICERF.OPENPRICEDIVRF,"
                 + "SEARCHPRTNMRF.SEARCHPARTSFULLNAMERF, "
                 + "SEARCHPRTNMRF.SEARCHPARTSHALFNAMERF ";
        // --- ADD m.suzuki 2010/04/28 ---------->>>>>
        private const string ctQryPartsNoForFreeSearch =
                   "PTMKRPRICERF.OFFERDATERF, "
                 + "PTMKRPRICERF.TBSPARTSCODERF, "
                 + "PTMKRPRICERF.TBSPARTSCDDERIVEDNORF, "
                 + "PTMKRPRICERF.OFFERDATERF AS PRICEOFFERDATE , "
                 + "PTMKRPRICERF.MAKERCODERF, "
                 + "PTMKRPRICERF.NEWPRTSNOWITHHYPHENRF, "
                 + "PTMKRPRICERF.MAKEROFFERPARTSNAMERF, "
                 + "PTMKRPRICERF.PARTSPRICERF, "
                 + "PTMKRPRICERF.PARTSLAYERCDRF, "
                 + "PTMKRPRICERF.PARTSPRICESTDATERF, "
                 + "PTMKRPRICERF.MAKEROFFERPARTSKANARF,"
                 + "PTMKRPRICERF.OPENPRICEDIVRF,"
                 + "SEARCHPRTNMRF.SEARCHPARTSFULLNAMERF, "
                 + "SEARCHPRTNMRF.SEARCHPARTSHALFNAMERF, "
                 + "SEARCHPRTNMRF.CARMAKERCODERF AS SRCHPNMACQRCARMKRCD ";
        // --- ADD m.suzuki 2010/04/28 ----------<<<<<
        #endregion

        /// <summary>
        /// �o�l�p���i�������W�b�N
        /// </summary>
        /// <param name="InPara">�����p�����[�^</param>
        /// <param name="RetInf">���o�������i���R�[�h</param>
        /// <param name="sqlConnection">�R�l�N�V�����N���X</param>
        /// <returns></returns>
        private int SearchPartsInfProc(GetPartsInfPara InPara, ref ArrayList RetInf, ref SqlConnection sqlConnection)
        {

            SqlDataReader myReader = null;
            //SqlEncryptInfo sqlEncriptInfo = null;
            //���ʂ̏�����
            RetInf = new ArrayList();
            //���ʂ�ArrayList�ɂ�����Ə��N���X
            RetPartsInf mf = null;

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string selectstr = string.Empty;
            string fromstr = string.Empty;
            string wherestr = string.Empty;
            string orderstring = string.Empty;
            string queryCol = string.Empty;
            string originalPartsNo = string.Empty;
            string partsNo = string.Empty;

            //�����t���O��`
            int BLorPrtsNoflg = 0;//0:�a�k�R�[�h�����@1:�i�Ԍ��� 2:�i�ԞB������
            bool fullmodelfixExists;

            //====BL�������i�Ԍ������̔���
            if (InPara.PrtsNoWithHyphen != string.Empty)
            {
                originalPartsNo = InPara.PrtsNoWithHyphen;
                queryCol = "NEWPRTSNOWITHHYPHENRF";
                BLorPrtsNoflg = 1;
            }
            else if (InPara.PrtsNoNoneHyphen != string.Empty)
            {
                originalPartsNo = InPara.PrtsNoNoneHyphen;
                queryCol = "NEWPRTSNONONEHYPHENRF";
                BLorPrtsNoflg = 1;
            }
            else if (InPara.TbsPartsCode != 0)
            {
                BLorPrtsNoflg = 0;
            }
            else
            {
                return 99;//�p�����[�^�s��
            }

            //====�t���^�w��ԍ������邩�Ȃ����̔���
            int[] full = null;
            if (InPara.FullModelFixedNo != null)
            {
                full = InPara.FullModelFixedNo;
                fullmodelfixExists = true;
            }
            else
            {
                fullmodelfixExists = false;
            }


            // -- DEL 2010/04/19 ���ɖ߂�------------------------------->>>
            // 2010/01/25 Add >>>
            // BL�R�[�h�����͕ʃ��\�b�h�ŏ�������
            //if (BLorPrtsNoflg == 0) return this.SearchPartsInfProc_BLSearch(InPara, ref RetInf, ref sqlConnection);
            // 2010/01/25 Add <<<
            // -- DEL 2010/04/19 ---------------------------------------<<<

            try
            {
                //���Í������i��������
                //sqlEncriptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB, new string[] { "PARTSNAMERF", "CLGPNOINFORF" });
                //�Í����L�[OPEN�iSQLException�̉\���L��j
                //sqlEncriptInfo.OpenSymKey(ref sqlConnection);                

                if (BLorPrtsNoflg == 0) //BL�R�[�h�����̏ꍇ
                {
                    // --- UPD T.Nishi 2012/01/24 ---------->>>>>
                    /*
                    // Select�R�}���h����(�i�ԁA�ϊ��A���i�}�X�^��JOIN���[�h)
                    selectstr = ctQryBLSearch;

                    // -- UPD 2010/11/02 ------------------------------->>>
                    //// --  UPD 2010/06/14 ------------------------------->>>
                    ////fromstr = "FROM CLGPNOINFORF ";
                    //fromstr = "FROM (SELECT * FROM CLGPNOINFORF UNION SELECT * FROM PRIMEJOINLNKRF) AS CLGPNOINFORF ";
                    //// --  UPD 2010/06/14 -------------------------------<<<

                    if (PrmblCodeCheck(InPara.TbsPartsCode, ref sqlConnection))
                    {
                        //�D�ǌ����A�g�}�X�^�̎Q�Ƃ��K�v����ꍇ
                        // 2010/11/22 >>>
                        //fromstr = "FROM (SELECT * FROM CLGPNOINFORF UNION SELECT * FROM PRIMEJOINLNKRF) AS CLGPNOINFORF ";
                        fromstr = "FROM (SELECT * FROM CLGPNOINFORF UNION ALL SELECT * FROM PRIMEJOINLNKRF) AS CLGPNOINFORF ";
                        // 2010/11/22 <<<
                    }
                    else
                    {
                        fromstr = "FROM CLGPNOINFORF ";
                    }
                    // -- UPD 2010/11/02 -------------------------------<<<
                    fromstr += "LEFT OUTER JOIN CLGPTNOEXCRF ON ( CLGPNOINFORF.CATALOGPARTSMAKERCDRF = CLGPTNOEXCRF.CATALOGPARTSMAKERCDRF ";
                    fromstr += "AND CLGPNOINFORF.CLGPRTSNOWITHHYPHENRF=CLGPTNOEXCRF.CLGPRTSNOWITHHYPHENRF ) ";
                    // -- UPD 2010/06/14 -------------------------------------------->>>
                    //fromstr += "LEFT OUTER JOIN PTMKRPRICERF ON ( CLGPTNOEXCRF.CLGPRTSNOWITHHYPHENRF = PTMKRPRICERF.NEWPRTSNOWITHHYPHENRF ";
                    fromstr += "LEFT OUTER JOIN PTMKRPRICEPMRF AS PTMKRPRICERF ON ( CLGPTNOEXCRF.CLGPRTSNOWITHHYPHENRF = PTMKRPRICERF.NEWPRTSNOWITHHYPHENRF ";
                    // -- UPD 2010/06/14 --------------------------------------------<<<
                    fromstr += "AND CLGPTNOEXCRF.CATALOGPARTSMAKERCDRF=PTMKRPRICERF.MAKERCODERF ) ";
                    fromstr += "LEFT OUTER JOIN SEARCHPRTNMRF ON (CLGPNOINFORF.TBSPARTSCODERF = SEARCHPRTNMRF.TBSPARTSCODERF ";
                    // 2009/10/23 >>>
                    //fromstr += "AND CLGPNOINFORF.CATALOGPARTSMAKERCDRF = SEARCHPRTNMRF.CARMAKERCODERF) ";
                    fromstr += "AND ( CLGPNOINFORF.CATALOGPARTSMAKERCDRF = SEARCHPRTNMRF.CARMAKERCODERF OR SEARCHPRTNMRF.CARMAKERCODERF = 0 )) ";
                    // 2009/10/23 <<<

                    if (fullmodelfixExists)//�t���^�Œ�̎w���������Index��Join����
                        fromstr += " LEFT OUTER JOIN CLGPNOINDXRF ON ( CLGPNOINDXRF.PARTSPROPERNORF=CLGPNOINFORF.PARTSPROPERNORF) ";

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.23 ADD
                    fromstr += "LEFT OUTER JOIN CARMODELRF ON ( CLGPNOINDXRF.FULLMODELFIXEDNORF=CARMODELRF.FULLMODELFIXEDNORF) ";
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.23 ADD

                    wherestr = " WHERE CLGPNOINFORF.TBSPARTSCODERF = @TBSPARTSCODE ";

                    if (fullmodelfixExists)//�t���^���̍i�肪����Ȃ��
                    {
                        StringBuilder sb = new StringBuilder(1000);

                        //sb.Append(" AND CLGPNOINDXRF.FULLMODELFIXEDNORF IN (");

                        int cnt = full.GetLength(0);
                        for (int lpcnt = 0; lpcnt < cnt; lpcnt++)
                        {
                            sb.Append(",");
                            sb.Append(full[lpcnt]);
                        }

                        sb.Append(") ");
                        if (sb.Length > 2)
                        {
                            sb.Remove(0, 1).Insert(0, " AND CLGPNOINDXRF.FULLMODELFIXEDNORF IN (");
                        }
                        wherestr += sb.ToString();
                    }
                    if (InPara.ProduceTypeOfYear != 0)
                    {
                        wherestr += string.Format(" AND (MODELPRTSADPTYMRF = 0 OR MODELPRTSADPTYMRF <= {0}) ", InPara.ProduceTypeOfYear);
                        wherestr += string.Format(" AND (MODELPRTSABLSYMRF = 0 OR MODELPRTSABLSYMRF >= {0}) ", InPara.ProduceTypeOfYear);
                    }
                    // --- UPD m.suzuki 2011/03/07 ---------->>>>>
                    //else if (string.IsNullOrEmpty(InPara.ChassisNo) == false)
                    if (string.IsNullOrEmpty(InPara.ChassisNo) == false)
                    // --- UPD m.suzuki 2011/03/07 ----------<<<<<
                    {
                        int frameNo = Convert.ToInt32(InPara.ChassisNo);
                        wherestr += string.Format(" AND (MODELPRTSADPTFRAMENORF = 0 OR MODELPRTSADPTFRAMENORF <= {0}) ", frameNo);
                        wherestr += string.Format(" AND (MODELPRTSABLSFRAMENORF = 0 OR MODELPRTSABLSFRAMENORF >= {0}) ", frameNo);
                    }

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 DEL
                    //orderstring = " ORDER BY CLGPNOINFORF.TBSPARTSCODERF, CLGPNOINFORF.FIGSHAPENORF";
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.23 DEL
                    //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 ADD
                    //orderstring = " ORDER BY CLGPNOINFORF.CLGPRTSNOWITHHYPHENRF, CLGPNOINFORF.CATALOGPARTSMAKERCDRF , CLGPNOINFORF.MODELPRTSADPTYMRF, PTMKRPRICERF.PARTSPRICESTDATERF ";
                    //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 ADD
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.23 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.23 ADD
                    orderstring = " ORDER BY CARMODELRF.SERIESMODELRF, CARMODELRF.CATEGORYSIGNMODELRF, CARMODELRF.EXHAUSTGASSIGNRF, CLGPNOINFORF.CLGPRTSNOWITHHYPHENRF, CLGPNOINFORF.CATALOGPARTSMAKERCDRF , CLGPNOINFORF.MODELPRTSADPTYMRF, PTMKRPRICERF.PARTSPRICESTDATERF ";
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.23 ADD
                    */

                    // Select�R�}���h����(�i�ԁA�ϊ��A���i�}�X�^��JOIN���[�h)
                    selectstr = "SELECT * FROM (";
                    selectstr += ctQryBLSearch;

                    if (PrmblCodeCheck(InPara.TbsPartsCode, ref sqlConnection))
                    {
                        // --- DEL 2013/03/27 ---------->>>>>
                        //>>>2013/02/12
                        ////�D�ǌ����A�g�}�X�^�̎Q�Ƃ��K�v����ꍇ
                        //fromstr = "FROM (SELECT * FROM CLGPNOINFORF UNION ALL SELECT * FROM PRIMEJOINLNKRF) AS CLGPNOINFORF ";
                        //�D�ǌ����A�g�}�X�^�̎Q�Ƃ��K�v����ꍇ
                        //fromstr = "FROM (SELECT * , 0 AS PRIMEJOINLNKFLGRF FROM CLGPNOINFORF UNION ALL SELECT * , 1 AS PRIMEJOINLNKFLGRF FROM PRIMEJOINLNKRF) AS CLGPNOINFORF ";
                        //<<<2013/02/12
                        // --- DEL 2013/03/27 ----------<<<<<
                        // --- ADD 2013/03/27 ---------->>>>>
                        //�D�ǌ����A�g�}�X�^�̎Q�Ƃ��K�v����ꍇ
                        //�J�^���O���i�i�ԏ��}�X�^�ɕs�����Ă������_�~�[�Ƃ��Ēǉ����A�D�ǌ����A�g�}�X�^��UNION����
                        //���񏇔Ԃ����킹�Ȃ��ƃN�G�����s�G���[�ɂȂ�ׁA
                        // ����������(�D�ǌ����A�g�}�X�^)�@UNION ALL (�J�^���O���i�i�ԏ��}�X�^)�ɏC��
                        fromstr = "FROM (SELECT * , 1 AS PRIMEJOINLNKFLGRF ";
                        fromstr += "FROM PRIMEJOINLNKRF UNION ALL SELECT * , ";
                        fromstr += "NULL AS PRODUCEFACTORYCDRF, ";
                        fromstr += "0 AS VINPRODUCESTARTNORF, ";
                        fromstr += "0 AS VINPRODUCEENDNORF, ";
                        fromstr += "0 AS PRIMEJOINLNKFLGRF ";
                        fromstr += "FROM CLGPNOINFORF ) AS CLGPNOINFORF ";
                        // --- ADD 2013/03/27 ----------<<<<<
                    }
                    else
                    {
                        // --- DEL 2013/03/27 ---------->>>>>
                        //>>>2013/02/12
                        //fromstr = "FROM CLGPNOINFORF ";
                        //fromstr = "FROM (SELECT *, 0 AS PRIMEJOINLNKFLGRF FROM CLGPNOINFORF) AS CLGPNOINFORF ";
                        //<<2013/02/12
                        // --- DEL 2013/03/27 ----------<<<<<
                        // --- ADD 2013/03/27 ---------->>>>>
                        //�D�ǌ����A�g�}�X�^�̎Q�Ƃ��K�v�Ȃ��ꍇ��
                        //�J�^���O���i�i�ԏ��}�X�^�ɕs�����Ă������_�~�[�Ƃ��Ēǉ�����
                        fromstr = "FROM (SELECT *, ";
                        fromstr += "NULL AS PRODUCEFACTORYCDRF, ";
                        fromstr += "0 AS VINPRODUCESTARTNORF, ";
                        fromstr += "0 AS VINPRODUCEENDNORF, ";
                        fromstr += "0 AS PRIMEJOINLNKFLGRF ";
                        fromstr += " FROM CLGPNOINFORF) AS CLGPNOINFORF ";
                        // --- ADD 2013/03/27 ----------<<<<<
                    }

                    fromstr += " LEFT OUTER JOIN CLGPNOINDXRF ON ( CLGPNOINDXRF.PARTSPROPERNORF=CLGPNOINFORF.PARTSPROPERNORF) ";
                    fromstr += " LEFT OUTER JOIN CARMODELRF ON ( CLGPNOINDXRF.FULLMODELFIXEDNORF=CARMODELRF.FULLMODELFIXEDNORF) ";
                    wherestr = " WHERE CLGPNOINFORF.TBSPARTSCODERF = @TBSPARTSCODE ";

                    if (fullmodelfixExists)//�t���^���̍i�肪����Ȃ��
                    {
                        StringBuilder sb = new StringBuilder(1000);

                        int cnt = full.GetLength(0);
                        for (int lpcnt = 0; lpcnt < cnt; lpcnt++)
                        {
                            sb.Append(",");
                            sb.Append(full[lpcnt]);
                        }

                        sb.Append(") ");
                        if (sb.Length > 2)
                        {
                            sb.Remove(0, 1).Insert(0, " AND CLGPNOINDXRF.FULLMODELFIXEDNORF IN (");
                        }
                        wherestr += sb.ToString();
                    }
                    // --- ADD 2013/03/27 ---------->>>>>
                    if (InPara.VinCode != 0)
                    {
                        // VIN�R�[�h�i���s���ꍇ
                        if (InPara.MakerCode == 80)         // BENZ�̏ꍇ
                        {
                            // �n���h���ʒu���𔽉f
                            // -1�̏ꍇ�͍i�����s��Ȃ�
                            if (InPara.HandleInfoCd != -1)
                            {
                                wherestr += string.Format(" AND (CARMODELRF.HANDLEINFOCDRF = {0}) ", InPara.HandleInfoCd);
                            }
                            // VIN���YNo.�͈͂𔽉f
                            wherestr += string.Format(" AND (CLGPNOINFORF.VINPRODUCESTARTNORF = 0 OR CLGPNOINFORF.VINPRODUCESTARTNORF <= {0}) ", InPara.VinCode);
                            wherestr += string.Format(" AND (CLGPNOINFORF.VINPRODUCEENDNORF = 0 OR CLGPNOINFORF.VINPRODUCEENDNORF >= {0}) ", InPara.VinCode);
                        }
                        else if (InPara.MakerCode == 81)    // VW�̏ꍇ
                        {
                            // ���Y�H��R�[�h��VIN���YNo.�͈͂𔽉f
                            wherestr += string.Format(" AND (CLGPNOINFORF.PRODUCEFACTORYCDRF IN ('{0}')) ", InPara.ProductionFactoryCd.Trim());
                            wherestr += string.Format(" AND (CLGPNOINFORF.VINPRODUCESTARTNORF = 0 OR CLGPNOINFORF.VINPRODUCESTARTNORF <= {0}) ", InPara.VinCode);
                            wherestr += string.Format(" AND (CLGPNOINFORF.VINPRODUCEENDNORF = 0 OR CLGPNOINFORF.VINPRODUCEENDNORF >= {0}) ", InPara.VinCode);
                        }
                    }
                    else
                    {
                        // VIN�R�[�h�i���s��Ȃ��ꍇ
                        if (InPara.ProduceTypeOfYear != 0)
                        {
                            wherestr += string.Format(" AND (MODELPRTSADPTYMRF = 0 OR MODELPRTSADPTYMRF <= {0}) ", InPara.ProduceTypeOfYear);
                            wherestr += string.Format(" AND (MODELPRTSABLSYMRF = 0 OR MODELPRTSABLSYMRF >= {0}) ", InPara.ProduceTypeOfYear);
                        }
                        if (string.IsNullOrEmpty(InPara.ChassisNo) == false)
                        {
                            int frameNo = Convert.ToInt32(InPara.ChassisNo);
                            wherestr += string.Format(" AND (MODELPRTSADPTFRAMENORF = 0 OR MODELPRTSADPTFRAMENORF <= {0}) ", frameNo);
                            wherestr += string.Format(" AND (MODELPRTSABLSFRAMENORF = 0 OR MODELPRTSABLSFRAMENORF >= {0}) ", frameNo);
                        }
                    }
                    // --- ADD 2013/03/27 ----------<<<<<

                    //PARTITION BY��ŏ��Ԃ��������R�[�h��ROWNUM=1�ň��k���鏈��
                    wherestr += ") AS SUBTABLE01 ";
                    wherestr += "WHERE ROWNUM = 1 ";

                    string strdum2 = selectstr + fromstr + wherestr ;


                    //��L�ō쐬�����N�G�����T�u�N�G���Ƃ��ĉ��e�[�u�����a�Ƃ���
                    // Select�R�}���h����(�i�ԁA�ϊ��A���i�}�X�^��JOIN���[�h)
                    //����ɏ�L�ō쐬�����N�G�����T�u�N�G���Ƃ��āA���̃e�[�u�����i�n�h�m����
                    selectstr =  "SELECT * FROM ( ";
                    selectstr += "SELECT SUBTABLE02.*, ";
                    selectstr += "CLGPTNOEXCRF.NEWPRTSNOWITHHYPHENRF, ";
                    selectstr += "PTMKRPRICERF.OFFERDATERF AS PRICEOFFERDATE , ";
                    selectstr += "PTMKRPRICERF.MAKEROFFERPARTSNAMERF, ";
                    selectstr += "PTMKRPRICERF.PARTSPRICERF, ";
                    selectstr += "PTMKRPRICERF.PARTSLAYERCDRF,";
                    selectstr += "PTMKRPRICERF.PARTSPRICESTDATERF,";
                    selectstr += "PTMKRPRICERF.MAKEROFFERPARTSKANARF,";
                    selectstr += "PTMKRPRICERF.OPENPRICEDIVRF,";
                    selectstr += "SEARCHPRTNMRF.CARMAKERCODERF AS SRCHPNMACQRCARMKRCD ,";
                    selectstr += "SEARCHPRTNMRF.SEARCHPARTSFULLNAMERF, ";
                    selectstr += "SEARCHPRTNMRF.SEARCHPARTSHALFNAMERF, ";
                    //���k�����Ɠ���������PARTITION BY���s��
                    selectstr += "ROW_NUMBER() OVER(PARTITION BY ";
                    selectstr += "SUBTABLE02.CATALOGPARTSMAKERCDRF, ";   //�J�^���O���i���[�J�[�R�[�h
                    selectstr += "SUBTABLE02.CLGPRTSNOWITHHYPHENRF, ";   //�n�C�t���t�J�^���O���i�i��
                    selectstr += "CLGPTNOEXCRF.NEWPRTSNOWITHHYPHENRF, ";   //�n�C�t���t�ŐV���i�i��
                    selectstr += "SUBTABLE02.PARTSQTYFORRPRF, ";         //���i�p�s�x
                    selectstr += "SUBTABLE02.STANDARDNAMERF, ";          //�K�i����
                    selectstr += "SUBTABLE02.PARTSOPNMRF, ";             //���i�I�v�V��������
                    selectstr += "SUBTABLE02.MODELPRTSADPTYMRF, ";       //�^���ʕ��i�̗p�N��
                    selectstr += "SUBTABLE02.MODELPRTSABLSYMRF, ";       //�^���ʕ��i�p�~�N��
                    selectstr += "SUBTABLE02.MODELPRTSADPTFRAMENORF, ";  //�^���ʕ��i�̗p�ԑ�ԍ�
                    selectstr += "SUBTABLE02.MODELPRTSABLSFRAMENORF  ";  //�^���ʕ��i�p�~�ԑ�ԍ�
                    selectstr += "ORDER BY ";
                    //�����͈��k�������̕��я�+���[�J�[+���t
                    selectstr += "SUBTABLE02.SERIESMODELRF, ";
                    selectstr += "SUBTABLE02.CATEGORYSIGNMODELRF, ";
                    selectstr += "SUBTABLE02.EXHAUSTGASSIGNRF, ";
                    selectstr += "SUBTABLE02.CLGPRTSNOWITHHYPHENRF, ";
                    selectstr += "SUBTABLE02.CATALOGPARTSMAKERCDRF, ";
                    selectstr += "SUBTABLE02.MODELPRTSADPTYMRF, ";
                    selectstr += "SEARCHPRTNMRF.CARMAKERCODERF DESC, ";          //���[�J�[�R�[�h
                    selectstr += "PTMKRPRICERF.PARTSPRICESTDATERF DESC";         //���i���i�K�p�J�n��
                    selectstr += ") AS ROWNUM2 ";
                    selectstr += "FROM (";
                    selectstr += strdum2;
                    selectstr += ") AS SUBTABLE02 ";

                    fromstr =  "LEFT OUTER JOIN CLGPTNOEXCRF ON ( SUBTABLE02.CATALOGPARTSMAKERCDRF = CLGPTNOEXCRF.CATALOGPARTSMAKERCDRF ";
                    fromstr += "AND SUBTABLE02.CLGPRTSNOWITHHYPHENRF=CLGPTNOEXCRF.CLGPRTSNOWITHHYPHENRF ) ";
                    fromstr += "LEFT OUTER JOIN PTMKRPRICEPMRF AS PTMKRPRICERF ";
                    fromstr += "ON ( PTMKRPRICERF.PARTSPRICEREVCDRF=0 ";  //���i���i����敪��0�Œ�Ȃ̂�0�Œ�Ŏw��
                    fromstr += "AND  PTMKRPRICERF.NEWPRTSNOWITHHYPHENRF = CLGPTNOEXCRF.CLGPRTSNOWITHHYPHENRF ";
                    fromstr += "AND  PTMKRPRICERF.MAKERCODERF = CLGPTNOEXCRF.CATALOGPARTSMAKERCDRF ";
                    fromstr += "AND  PTMKRPRICERF.PARTSPRICESTDATERF <= @PARTSPRICESTDATE) ";  //���t���v����ȑO�Ɏw��
                    fromstr += "LEFT OUTER JOIN SEARCHPRTNMRF ON (SUBTABLE02.TBSPARTSCODERF = SEARCHPRTNMRF.TBSPARTSCODERF ";
                    fromstr += "AND ( SUBTABLE02.CATALOGPARTSMAKERCDRF = SEARCHPRTNMRF.CARMAKERCODERF OR SEARCHPRTNMRF.CARMAKERCODERF = 0 )) ";


                    //PARTITION BY��ŏ��Ԃ��������R�[�h��ROWNUM=1�ň��k���鏈��
                    wherestr =  ") AS SUBTABLE03 ";
                    wherestr += "WHERE ROWNUM2 = 1 ";

                    orderstring = " ORDER BY SERIESMODELRF, CATEGORYSIGNMODELRF, EXHAUSTGASSIGNRF, CLGPRTSNOWITHHYPHENRF, CATALOGPARTSMAKERCDRF , MODELPRTSADPTYMRF, PARTSPRICESTDATERF ";
                    // --- UPD T.Nishi 2012/01/24 ----------<<<<<

                }
                else //>>>>>>�i�Ԍ����̏ꍇ
                {
                    // Select�R�}���h����(���i���̃}�X�^��JOIN���[�h)���i�Ԍ����̏ꍇ�͎ԗ��̍i��͂Ȃ�
                    //selectstr = "SELECT Cast(  DecryptByKey(PARTSNAMERF.PARTSNAMERF) AS NVARCHAR(60)  ) AS PARTSNAMERF,PARTSCODERF,PARTSSEARCHCODERF,MAKERCODERF,NEWPRTSNOWITHHYPHENRF,NEWPRTSNONONEHYPHENRF,PTMKRPRICERF.TBSPARTSCODERF,TBSPARTSCDDERIVEDNORF,MAKEROFFERPARTSNAMERF,PARTSPRICERF,PARTSLAYERCDRF,PARTSINFOCTRLFLGRF ";
                    selectstr = "SELECT ";
                    if (InPara.SearchType == 1 || InPara.SearchType == 2 || InPara.SearchType == 3)
                        selectstr += "TOP(300) ";

                    #region �i�Ԍ����N�G��
                    selectstr += ctQryPartsNo;

                    // -- UPD 2010/06/14 --------------------->>>
                    //fromstr = " FROM PTMKRPRICERF ";
                    fromstr = " FROM PTMKRPRICEPMRF AS PTMKRPRICERF ";
                    // -- UPD 2010/06/14 ---------------------<<<
                    fromstr += "LEFT OUTER JOIN SEARCHPRTNMRF ON (PTMKRPRICERF.TBSPARTSCODERF = SEARCHPRTNMRF.TBSPARTSCODERF ";
                    fromstr += "AND PTMKRPRICERF.MAKERCODERF = SEARCHPRTNMRF.CARMAKERCODERF) ";

                    #endregion
                    switch (InPara.SearchType)
                    {
                        case 0: // ���S��v
                            partsNo = originalPartsNo;
                            wherestr = " WHERE PTMKRPRICERF.NEWPRTSNOWITHHYPHENRF = @CLGPRTSNOWITHHYPHEN ";
                            break;
                        case 1: // �O����v
                            partsNo = originalPartsNo + "%";
                            wherestr = " WHERE PTMKRPRICERF." + queryCol + " LIKE @CLGPRTSNOWITHHYPHEN ";
                            break;
                        case 2: // �����v
                            partsNo = "%" + originalPartsNo;
                            wherestr = " WHERE PTMKRPRICERF." + queryCol + " LIKE @CLGPRTSNOWITHHYPHEN ";
                            break;
                        case 3: // �B������
                            partsNo = "%" + originalPartsNo + "%";
                            wherestr = " WHERE PTMKRPRICERF." + queryCol + " LIKE @CLGPRTSNOWITHHYPHEN ";
                            break;
                        case 4: // �n�C�t���������S��v
                            partsNo = originalPartsNo;
                            wherestr = " WHERE PTMKRPRICERF.NEWPRTSNONONEHYPHENRF = @CLGPRTSNOWITHHYPHEN ";
                            break;
                    }
                    if (InPara.MakerCode != 0)
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/24 DEL
                        //wherestr += " AND OFFERDATERF DESC, PTMKRPRICERF.MAKERCODERF = @MAKERCODE";
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/24 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/24 ADD
                        wherestr += " AND PTMKRPRICERF.MAKERCODERF = @MAKERCODE";
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/24 ADD

                    // --- ADD m.suzuki 2010/06/12 ---------->>>>>
                    // �Q�փ��[�J�[���O����
                    if ( InPara.TwoWheelerMakerExclude && InPara.TwoWheelerMakerCdSt != 0 && InPara.TwoWheelerMakerCdEd != 0 )
                    {
                        wherestr += " AND NOT ( PTMKRPRICERF.MAKERCODERF BETWEEN @TWOWHEELERMAKERCDST AND @TWOWHEELERMAKERCDED ) ";
                    }
                    // --- ADD m.suzuki 2010/06/12 ----------<<<<<

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 DEL
                    //orderstring = " ORDER BY PTMKRPRICERF.TBSPARTSCODERF";
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 ADD
                    //orderstring = " ORDER BY PTMKRPRICERF.MAKERCODERF, PTMKRPRICERF.NEWPRTSNOWITHHYPHENRF";
                    orderstring = " ORDER BY PTMKRPRICERF.NEWPRTSNOWITHHYPHENRF, PTMKRPRICERF.MAKERCODERF";
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 ADD
                }
                string strdum = selectstr + fromstr + wherestr + orderstring;

                SqlCommand sqlCommand = new SqlCommand(strdum, sqlConnection);

                SqlParameter findCLGPRTSNOWITHHYPHEN = null;
                SqlParameter findBLCODE = null;
                switch (BLorPrtsNoflg)
                {
                    case 0://BL�R�[�h
                        findBLCODE = sqlCommand.Parameters.Add("@TBSPARTSCODE", SqlDbType.Int);	//�t�����f���ԍ�
                        findBLCODE.Value = SqlDataMediator.SqlSetInt32(InPara.TbsPartsCode);
                        // --- ADD T.Nishi 2012/01/24 ---------->>>>>
                        ((SqlParameter)sqlCommand.Parameters.Add("@PARTSPRICESTDATE", SqlDbType.Int)).Value = SqlDataMediator.SqlSetInt(ToLongDate(InPara.PriceDate));
                        // --- ADD T.Nishi 2012/01/24 ----------<<<<<
                        break;
                    case 1://�i��
                        findCLGPRTSNOWITHHYPHEN = sqlCommand.Parameters.Add("@CLGPRTSNOWITHHYPHEN", SqlDbType.NVarChar);	//�t�����f���ԍ�
                        findCLGPRTSNOWITHHYPHEN.Value = SqlDataMediator.SqlSetString(partsNo);
                        if (InPara.MakerCode != 0)
                        {
                            ((SqlParameter)sqlCommand.Parameters.Add("@MAKERCODE", SqlDbType.Int)).Value = SqlDataMediator.SqlSetInt(InPara.MakerCode);
                        }
                        // --- ADD m.suzuki 2010/06/12 ---------->>>>>
                        if ( InPara.TwoWheelerMakerExclude && InPara.TwoWheelerMakerCdSt != 0 && InPara.TwoWheelerMakerCdEd != 0 )
                        {
                            ((SqlParameter)sqlCommand.Parameters.Add( "@TWOWHEELERMAKERCDST", SqlDbType.Int )).Value = SqlDataMediator.SqlSetInt( InPara.TwoWheelerMakerCdSt );
                            ((SqlParameter)sqlCommand.Parameters.Add( "@TWOWHEELERMAKERCDED", SqlDbType.Int )).Value = SqlDataMediator.SqlSetInt( InPara.TwoWheelerMakerCdEd );
                        }
                        // --- ADD m.suzuki 2010/06/12 ----------<<<<<
                        break;
                }

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    mf = new RetPartsInf();

                    if (BLorPrtsNoflg == 0) // BL����
                    {
                        mf.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                        mf.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                        mf.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
                        mf.CatalogPartsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATALOGPARTSMAKERCDRF"));
                        mf.PartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSFULLNAMERF"));
                        mf.PartsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSHALFNAMERF"));
                        mf.NewPrtsNoWithHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NEWPRTSNOWITHHYPHENRF"));
                        mf.NewPrtsNoNoneHyphen = mf.NewPrtsNoWithHyphen.Replace("-", "");//SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NEWPRTSNONONEHYPHENRF"));
                        mf.MakerOfferPartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKEROFFERPARTSNAMERF"));
                        mf.PriceOfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICEOFFERDATE"));
                        mf.PartsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PARTSPRICERF"));
                        mf.PartsLayerCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSLAYERCDRF"));
                        mf.PartsNarrowingCode = PartsNarrowingCode;
                        if (fullmodelfixExists)//�t���^�Œ�̎w��������΃t���^���Œ�ԍ��擾
                            mf.FullModelFixedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FULLMODELFIXEDNORF"));

                        mf.FigShapeNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FIGSHAPENORF"));
                        mf.PartsOpNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSOPNMRF"));
                        mf.StandardName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STANDARDNAMERF"));
                        mf.ClgPrtsNoWithHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLGPRTSNOWITHHYPHENRF"));
                        mf.ModelPrtsAdptYm = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELPRTSADPTYMRF"));
                        mf.ModelPrtsAblsYm = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELPRTSABLSYMRF"));
                        mf.ModelPrtsAdptFrameNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELPRTSADPTFRAMENORF"));
                        mf.ModelPrtsAblsFrameNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELPRTSABLSFRAMENORF"));
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.27 DEL
                        //mf.PartsQty = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PARTSQTYRF"));
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.27 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.27 ADD
                        mf.PartsQty = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PARTSQTYFORRPRF"));
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.27 ADD
                        mf.ColdDistrictsFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLDDISTRICTSFLAGRF"));
                        mf.ColorNarrowingFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLORNARROWINGFLAGRF"));
                        mf.TrimNarrowingFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TRIMNARROWINGFLAGRF"));
                        mf.EquipNarrowingFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EQUIPNARROWINGFLAGRF"));
                        mf.PartsUniqueNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PARTSPROPERNORF"));
                        mf.PartsPriceStDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PARTSPRICESTDATERF"));
                        mf.MakerOfferPartsKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKEROFFERPARTSKANARF"));
                        mf.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.23 ADD
                        mf.SeriesModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SERIESMODELRF"));
                        mf.CategorySignModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CATEGORYSIGNMODELRF"));
                        mf.ExhaustGasSign = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EXHAUSTGASSIGNRF"));
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.23 ADD
                        // 2009/10/23 Add >>>
                        mf.SrchPNmAcqrCarMkrCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SRCHPNMACQRCARMKRCD"));
                        // 2009/10/23 Add <<<
                        // --- ADD m.suzuki 2011/05/18 ---------->>>>>
                        mf.AutoEstimatePartsCd = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "AUTOESTIMATEPARTSCDRF" ) );
                        mf.TbsPartsCdDerivedNm = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "TBSPARTSCDDERIVEDNMRF" ) );
                        // --- ADD m.suzuki 2011/05/18 ----------<<<<<
                        //>>>2013/02/12
                        mf.PrimeJoinLnkFlg = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIMEJOINLNKFLGRF"));
                        //<<<2013/02/12

                        // --- ADD 2013/03/27 ---------->>>>>
                        // VIN�R�[�h�i���L���ɂ�����炸�A�uVIN���Y���i�n���j�v�E�uVIN���Y���i�I���j�v���擾
                        mf.VinProduceStartNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("VINPRODUCESTARTNORF"));
                        mf.VinProduceEndNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("VINPRODUCEENDNORF"));
                        // --- ADD 2013/03/27 ----------<<<<<
                    }
                    else
                    {
                        mf.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                        mf.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                        mf.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
                        mf.CatalogPartsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));
                        // 2009/10/23 >>>
                        //mf.PartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSFULLNAMERF"));
                        //mf.PartsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSHALFNAMERF"));
                        mf.PartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKEROFFERPARTSNAMERF"));
                        mf.PartsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKEROFFERPARTSKANARF"));
                        // 2009/10/23 <<<
                        mf.NewPrtsNoWithHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NEWPRTSNOWITHHYPHENRF"));
                        mf.NewPrtsNoNoneHyphen = mf.NewPrtsNoWithHyphen.Replace("-", "");//SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NEWPRTSNONONEHYPHENRF"));
                        mf.MakerOfferPartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKEROFFERPARTSNAMERF"));
                        mf.PartsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PARTSPRICERF"));
                        mf.PartsLayerCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSLAYERCDRF"));
                        mf.PriceOfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICEOFFERDATE"));
                        mf.PartsPriceStDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PARTSPRICESTDATERF"));
                        mf.PartsNarrowingCode = PartsNarrowingCode;
                        mf.ClgPrtsNoWithHyphen = mf.NewPrtsNoWithHyphen;// SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NEWPRTSNOWITHHYPHENRF"));
                        mf.MakerOfferPartsKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKEROFFERPARTSKANARF"));
                        mf.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));

                    }
                    RetInf.Add(mf);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                if (myReader != null && !myReader.IsClosed)
                    myReader.Close();

                // �Â����i[���i���̂Ȃ����i]�����Ή�
                //>>>>>>>>�i�Ԉ�v�����̏ꍇ�@���i��փ}�X�^������
                //�@�����܂������̏ꍇ�͌Â����i�͌����ΏۊO�Ƃ���B
                if ((BLorPrtsNoflg == 1) && (InPara.SearchType == 0 || InPara.SearchType == 4))// && (InPara.PrtsNoWithHyphen.Trim() != ""))
                {
                    // Select�R�}���h����(�i�ԁA�ϊ��A���i�}�X�^��JOIN���[�h)
                    selectstr = "SELECT CATALOGPARTSMAKERCDRF,OLDPARTSNOWITHHYPHENRF,PARTSQTYRF,PARTSSUBSTRF.OFFERDATERF, ";
                    selectstr += "PTMKRPRICERF.TBSPARTSCODERF,TBSPARTSCDDERIVEDNORF,MAKEROFFERPARTSNAMERF,PARTSPRICERF,PARTSLAYERCDRF,";
                    selectstr += "PTMKRPRICERF.OFFERDATERF AS PRICEOFFERDATE, PTMKRPRICERF.MAKEROFFERPARTSKANARF, PTMKRPRICERF.OPENPRICEDIVRF ";

                    fromstr = "FROM PARTSSUBSTRF ";
                    // -- UPD 2010/06/14 ------------------------------------->>>
                    //fromstr += " LEFT OUTER JOIN PTMKRPRICERF ON ( PARTSSUBSTRF.OLDPARTSNOWITHHYPHENRF=PTMKRPRICERF.NEWPRTSNOWITHHYPHENRF AND ";
                    fromstr += " LEFT OUTER JOIN PTMKRPRICEPMRF AS PTMKRPRICERF ON ( PARTSSUBSTRF.OLDPARTSNOWITHHYPHENRF=PTMKRPRICERF.NEWPRTSNOWITHHYPHENRF AND ";
                    // -- UPD 2010/06/14 -------------------------------------<<<
                    fromstr += "PARTSSUBSTRF.CATALOGPARTSMAKERCDRF=PTMKRPRICERF.MAKERCODERF ) ";
                    wherestr = " WHERE PARTSSUBSTRF.OLDPARTSNOWITHHYPHENRF = @CLGPRTSNOWITHHYPHEN ";

                    if (InPara.MakerCode != 0)
                        wherestr += "AND PARTSSUBSTRF.CATALOGPARTSMAKERCDRF = @MAKERCODE";
                    wherestr += " AND PARTSSUBSTRF.MAINORSUBPARTSDIVCDRF=0 ";

                    orderstring = " ORDER BY PARTSSUBSTRF.CATALOGPARTSMAKERCDRF,PARTSSUBSTRF.OLDPARTSNOWITHHYPHENRF,PARTSSUBSTRF.NPRTNOWITHHYPNDSPODRRF,";
                    orderstring += "PARTSSUBSTRF.MAINORSUBPARTSDIVCDRF ";
                    strdum = selectstr + " " + fromstr + " " + wherestr + " " + orderstring;

                    sqlCommand = new SqlCommand(strdum, sqlConnection);

                    findCLGPRTSNOWITHHYPHEN = sqlCommand.Parameters.Add("@CLGPRTSNOWITHHYPHEN", SqlDbType.NVarChar);	//�t�����f���ԍ�
                    findCLGPRTSNOWITHHYPHEN.Value = SqlDataMediator.SqlSetString(originalPartsNo.Trim());
                    if (InPara.MakerCode != 0)
                    {
                        ((SqlParameter)sqlCommand.Parameters.Add("@MAKERCODE", SqlDbType.Int)).Value = SqlDataMediator.SqlSetInt(InPara.MakerCode);
                    }

                    myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        mf = new RetPartsInf();

                        mf.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                        mf.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                        mf.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
                        mf.PartsQty = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "PARTSQTYRF" ) );
                        mf.CatalogPartsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATALOGPARTSMAKERCDRF"));
                        mf.NewPrtsNoWithHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OLDPARTSNOWITHHYPHENRF"));
                        mf.NewPrtsNoNoneHyphen = mf.NewPrtsNoWithHyphen.Replace("-", "");//SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NEWPRTSNONONEHYPHENRF"));
                        mf.MakerOfferPartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKEROFFERPARTSNAMERF"));
                        mf.PartsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PARTSPRICERF"));
                        mf.PartsLayerCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSLAYERCDRF"));
                        mf.PriceOfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICEOFFERDATE"));
                        mf.PartsNarrowingCode = PartsNarrowingCode;
                        mf.MakerOfferPartsKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKEROFFERPARTSKANARF"));
                        mf.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));

                        RetInf.Add(mf);

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        break;
                    }
                }

            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed)
                    myReader.Close();
            }
            //�Í����L�[�N���[�Y
            //if (sqlEncriptInfo != null && sqlEncriptInfo.IsOpen) sqlEncriptInfo.CloseSymKey(ref sqlConnection);

            return status;
        }

        // ���x���P�e�X�g -------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

        /// <summary>
        /// �o�l�p���i�������W�b�N
        /// </summary>
        /// <param name="InPara">�����p�����[�^</param>
        /// <param name="RetInf">���o�������i���R�[�h</param>
        /// <param name="sqlConnection">�R�l�N�V�����N���X</param>
        /// <returns></returns>
        private int SearchPartsInfProcYYYY(GetPartsInfPara InPara, ref ArrayList RetInf, ref SqlConnection sqlConnection, List<AutoAnsItemStForOffer> foundAutoAnsItemStList)
        {
            SqlDataReader myReader = null;
            //SqlEncryptInfo sqlEncriptInfo = null;
            //���ʂ̏�����
            RetInf = new ArrayList();
            //���ʂ�ArrayList�ɂ�����Ə��N���X
            RetPartsInf mf = null;

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string selectstr = string.Empty;
            string fromstr = string.Empty;
            string wherestr = string.Empty;
            string orderstring = string.Empty;
            string queryCol = string.Empty;
            string originalPartsNo = string.Empty;
            string partsNo = string.Empty;

            //�����t���O��`
            int BLorPrtsNoflg = 0;//0:�a�k�R�[�h�����@1:�i�Ԍ��� 2:�i�ԞB������
            bool fullmodelfixExists;

            //====BL�������i�Ԍ������̔���
            if (InPara.PrtsNoWithHyphen != string.Empty)
            {
                originalPartsNo = InPara.PrtsNoWithHyphen;
                queryCol = "NEWPRTSNOWITHHYPHENRF";
                BLorPrtsNoflg = 1;
            }
            else if (InPara.PrtsNoNoneHyphen != string.Empty)
            {
                originalPartsNo = InPara.PrtsNoNoneHyphen;
                queryCol = "NEWPRTSNONONEHYPHENRF";
                BLorPrtsNoflg = 1;
            }
            else if (InPara.TbsPartsCode != 0)
            {
                BLorPrtsNoflg = 0;
            }
            else
            {
                return 99;//�p�����[�^�s��
            }

            //====�t���^�w��ԍ������邩�Ȃ����̔���
            int[] full = null;
            if (InPara.FullModelFixedNo != null)
            {
                full = InPara.FullModelFixedNo;
                fullmodelfixExists = true;
            }
            else
            {
                fullmodelfixExists = false;
            }


            // -- DEL 2010/04/19 ���ɖ߂�------------------------------->>>
            // 2010/01/25 Add >>>
            // BL�R�[�h�����͕ʃ��\�b�h�ŏ�������
            //if (BLorPrtsNoflg == 0) return this.SearchPartsInfProc_BLSearch(InPara, ref RetInf, ref sqlConnection);
            // 2010/01/25 Add <<<
            // -- DEL 2010/04/19 ---------------------------------------<<<

            try
            {
                //���Í������i��������

                if (BLorPrtsNoflg == 0) //BL�R�[�h�����̏ꍇ
                {
                    // Select�R�}���h����(�i�ԁA�ϊ��A���i�}�X�^��JOIN���[�h)
                    selectstr = "SELECT * FROM (";
                    selectstr += ctQryBLSearch;

                    if (PrmblCodeCheck(InPara.TbsPartsCode, ref sqlConnection))
                    {
                        // --- DEL 2013/03/27 ---------->>>>>
                        //>>>2013/02/12
                        ////�D�ǌ����A�g�}�X�^�̎Q�Ƃ��K�v����ꍇ
                        //fromstr = "FROM (SELECT * FROM CLGPNOINFORF UNION ALL SELECT * FROM PRIMEJOINLNKRF) AS CLGPNOINFORF ";
                        //�D�ǌ����A�g�}�X�^�̎Q�Ƃ��K�v����ꍇ
                        //fromstr = "FROM (SELECT * , 0 AS PRIMEJOINLNKFLGRF FROM CLGPNOINFORF UNION ALL SELECT * , 1 AS PRIMEJOINLNKFLGRF FROM PRIMEJOINLNKRF) AS CLGPNOINFORF ";
                        //<<<2013/02/12
                        // --- DEL 2013/03/27 ----------<<<<<
                        // --- ADD 2013/03/27 ---------->>>>>
                        //�D�ǌ����A�g�}�X�^�̎Q�Ƃ��K�v����ꍇ
                        //�J�^���O���i�i�ԏ��}�X�^�ɕs�����Ă������_�~�[�Ƃ��Ēǉ����A�D�ǌ����A�g�}�X�^��UNION����
                        //���񏇔Ԃ����킹�Ȃ��ƃN�G�����s�G���[�ɂȂ�ׁA
                        // ����������(�D�ǌ����A�g�}�X�^)�@UNION ALL (�J�^���O���i�i�ԏ��}�X�^)�ɏC��
                        fromstr = "FROM (SELECT * , 1 AS PRIMEJOINLNKFLGRF ";
                        fromstr += "FROM PRIMEJOINLNKRF UNION ALL SELECT * , ";
                        fromstr += "NULL AS PRODUCEFACTORYCDRF, ";
                        fromstr += "0 AS VINPRODUCESTARTNORF, ";
                        fromstr += "0 AS VINPRODUCEENDNORF, ";
                        fromstr += "0 AS PRIMEJOINLNKFLGRF ";
                        fromstr += "FROM CLGPNOINFORF ) AS CLGPNOINFORF ";
                        // --- ADD 2013/03/27 ----------<<<<<
                    }
                    else
                    {
                        // --- DEL 2013/03/27 ---------->>>>>
                        //>>>2013/02/12
                        //fromstr = "FROM CLGPNOINFORF ";
                        //fromstr = "FROM (SELECT *, 0 AS PRIMEJOINLNKFLGRF FROM CLGPNOINFORF) AS CLGPNOINFORF ";
                        //<<2013/02/12
                        // --- DEL 2013/03/27 ----------<<<<<
                        // --- ADD 2013/03/27 ---------->>>>>
                        //�D�ǌ����A�g�}�X�^�̎Q�Ƃ��K�v�Ȃ��ꍇ��
                        //�J�^���O���i�i�ԏ��}�X�^�ɕs�����Ă������_�~�[�Ƃ��Ēǉ�����
                        fromstr = "FROM (SELECT *, ";
                        fromstr += "NULL AS PRODUCEFACTORYCDRF, ";
                        fromstr += "0 AS VINPRODUCESTARTNORF, ";
                        fromstr += "0 AS VINPRODUCEENDNORF, ";
                        fromstr += "0 AS PRIMEJOINLNKFLGRF ";
                        fromstr += " FROM CLGPNOINFORF) AS CLGPNOINFORF ";
                        // --- ADD 2013/03/27 ----------<<<<<
                    }

                    fromstr += " LEFT OUTER JOIN CLGPNOINDXRF ON ( CLGPNOINDXRF.PARTSPROPERNORF=CLGPNOINFORF.PARTSPROPERNORF) ";
                    fromstr += " LEFT OUTER JOIN CARMODELRF ON ( CLGPNOINDXRF.FULLMODELFIXEDNORF=CARMODELRF.FULLMODELFIXEDNORF) ";
                    wherestr = " WHERE CLGPNOINFORF.TBSPARTSCODERF = @TBSPARTSCODE ";

                    if (fullmodelfixExists)//�t���^���̍i�肪����Ȃ��
                    {
                        StringBuilder sb = new StringBuilder(1000);

                        int cnt = full.GetLength(0);
                        for (int lpcnt = 0; lpcnt < cnt; lpcnt++)
                        {
                            sb.Append(",");
                            sb.Append(full[lpcnt]);
                        }

                        sb.Append(") ");
                        if (sb.Length > 2)
                        {
                            sb.Remove(0, 1).Insert(0, " AND CLGPNOINDXRF.FULLMODELFIXEDNORF IN (");
                        }
                        wherestr += sb.ToString();
                    }
                    // --- ADD 2013/03/27 ---------->>>>>
                    if (InPara.VinCode != 0)
                    {
                        // VIN�R�[�h�i���s���ꍇ
                        if (InPara.MakerCode == 80)         // BENZ�̏ꍇ
                        {
                            // �n���h���ʒu���𔽉f
                            // -1�̏ꍇ�͍i�����s��Ȃ�
                            if (InPara.HandleInfoCd != -1)
                            {
                                wherestr += string.Format(" AND (CARMODELRF.HANDLEINFOCDRF = {0}) ", InPara.HandleInfoCd);
                            }
                            // VIN���YNo.�͈͂𔽉f
                            wherestr += string.Format(" AND (CLGPNOINFORF.VINPRODUCESTARTNORF = 0 OR CLGPNOINFORF.VINPRODUCESTARTNORF <= {0}) ", InPara.VinCode);
                            wherestr += string.Format(" AND (CLGPNOINFORF.VINPRODUCEENDNORF = 0 OR CLGPNOINFORF.VINPRODUCEENDNORF >= {0}) ", InPara.VinCode);
                        }
                        else if (InPara.MakerCode == 81)    // VW�̏ꍇ
                        {
                            // ���Y�H��R�[�h��VIN���YNo.�͈͂𔽉f
                            wherestr += string.Format(" AND (CLGPNOINFORF.PRODUCEFACTORYCDRF IN ('{0}')) ", InPara.ProductionFactoryCd.Trim());
                            wherestr += string.Format(" AND (CLGPNOINFORF.VINPRODUCESTARTNORF = 0 OR CLGPNOINFORF.VINPRODUCESTARTNORF <= {0}) ", InPara.VinCode);
                            wherestr += string.Format(" AND (CLGPNOINFORF.VINPRODUCEENDNORF = 0 OR CLGPNOINFORF.VINPRODUCEENDNORF >= {0}) ", InPara.VinCode);
                        }
                    }
                    else
                    {
                        // VIN�R�[�h�i���s��Ȃ��ꍇ
                        if (InPara.ProduceTypeOfYear != 0)
                        {
                            wherestr += string.Format(" AND (MODELPRTSADPTYMRF = 0 OR MODELPRTSADPTYMRF <= {0}) ", InPara.ProduceTypeOfYear);
                            wherestr += string.Format(" AND (MODELPRTSABLSYMRF = 0 OR MODELPRTSABLSYMRF >= {0}) ", InPara.ProduceTypeOfYear);
                        }
                        if (string.IsNullOrEmpty(InPara.ChassisNo) == false)
                        {
                            int frameNo = Convert.ToInt32(InPara.ChassisNo);
                            wherestr += string.Format(" AND (MODELPRTSADPTFRAMENORF = 0 OR MODELPRTSADPTFRAMENORF <= {0}) ", frameNo);
                            wherestr += string.Format(" AND (MODELPRTSABLSFRAMENORF = 0 OR MODELPRTSABLSFRAMENORF >= {0}) ", frameNo);
                        }
                    }
                    // --- ADD 2013/03/27 ----------<<<<<

                    //PARTITION BY��ŏ��Ԃ��������R�[�h��ROWNUM=1�ň��k���鏈��
                    wherestr += ") AS SUBTABLE01 ";
                    wherestr += "WHERE ROWNUM = 1 ";

                    string strdum2 = selectstr + fromstr + wherestr;


                    //��L�ō쐬�����N�G�����T�u�N�G���Ƃ��ĉ��e�[�u�����a�Ƃ���
                    // Select�R�}���h����(�i�ԁA�ϊ��A���i�}�X�^��JOIN���[�h)
                    //����ɏ�L�ō쐬�����N�G�����T�u�N�G���Ƃ��āA���̃e�[�u�����i�n�h�m����
                    selectstr = "SELECT * FROM ( ";
                    selectstr += "SELECT SUBTABLE02.*, ";
                    selectstr += "CLGPTNOEXCRF.NEWPRTSNOWITHHYPHENRF, ";
                    selectstr += "PTMKRPRICERF.OFFERDATERF AS PRICEOFFERDATE , ";
                    selectstr += "PTMKRPRICERF.MAKEROFFERPARTSNAMERF, ";
                    selectstr += "PTMKRPRICERF.PARTSPRICERF, ";
                    selectstr += "PTMKRPRICERF.PARTSLAYERCDRF,";
                    selectstr += "PTMKRPRICERF.PARTSPRICESTDATERF,";
                    selectstr += "PTMKRPRICERF.MAKEROFFERPARTSKANARF,";
                    selectstr += "PTMKRPRICERF.OPENPRICEDIVRF,";
                    selectstr += "SEARCHPRTNMRF.CARMAKERCODERF AS SRCHPNMACQRCARMKRCD ,";
                    selectstr += "SEARCHPRTNMRF.SEARCHPARTSFULLNAMERF, ";
                    selectstr += "SEARCHPRTNMRF.SEARCHPARTSHALFNAMERF, ";
                    //���k�����Ɠ���������PARTITION BY���s��
                    selectstr += "ROW_NUMBER() OVER(PARTITION BY ";
                    selectstr += "SUBTABLE02.CATALOGPARTSMAKERCDRF, ";   //�J�^���O���i���[�J�[�R�[�h
                    selectstr += "SUBTABLE02.CLGPRTSNOWITHHYPHENRF, ";   //�n�C�t���t�J�^���O���i�i��
                    selectstr += "CLGPTNOEXCRF.NEWPRTSNOWITHHYPHENRF, ";   //�n�C�t���t�ŐV���i�i��
                    selectstr += "SUBTABLE02.PARTSQTYFORRPRF, ";         //���i�p�s�x
                    selectstr += "SUBTABLE02.STANDARDNAMERF, ";          //�K�i����
                    selectstr += "SUBTABLE02.PARTSOPNMRF, ";             //���i�I�v�V��������
                    selectstr += "SUBTABLE02.MODELPRTSADPTYMRF, ";       //�^���ʕ��i�̗p�N��
                    selectstr += "SUBTABLE02.MODELPRTSABLSYMRF, ";       //�^���ʕ��i�p�~�N��
                    selectstr += "SUBTABLE02.MODELPRTSADPTFRAMENORF, ";  //�^���ʕ��i�̗p�ԑ�ԍ�
                    selectstr += "SUBTABLE02.MODELPRTSABLSFRAMENORF  ";  //�^���ʕ��i�p�~�ԑ�ԍ�
                    selectstr += "ORDER BY ";
                    //�����͈��k�������̕��я�+���[�J�[+���t
                    selectstr += "SUBTABLE02.SERIESMODELRF, ";
                    selectstr += "SUBTABLE02.CATEGORYSIGNMODELRF, ";
                    selectstr += "SUBTABLE02.EXHAUSTGASSIGNRF, ";
                    selectstr += "SUBTABLE02.CLGPRTSNOWITHHYPHENRF, ";
                    selectstr += "SUBTABLE02.CATALOGPARTSMAKERCDRF, ";
                    selectstr += "SUBTABLE02.MODELPRTSADPTYMRF, ";
                    selectstr += "SEARCHPRTNMRF.CARMAKERCODERF DESC, ";          //���[�J�[�R�[�h
                    selectstr += "PTMKRPRICERF.PARTSPRICESTDATERF DESC";         //���i���i�K�p�J�n��
                    selectstr += ") AS ROWNUM2 ";
                    selectstr += "FROM (";
                    selectstr += strdum2;
                    selectstr += ") AS SUBTABLE02 ";

                    fromstr = "LEFT OUTER JOIN CLGPTNOEXCRF ON ( SUBTABLE02.CATALOGPARTSMAKERCDRF = CLGPTNOEXCRF.CATALOGPARTSMAKERCDRF ";
                    fromstr += "AND SUBTABLE02.CLGPRTSNOWITHHYPHENRF=CLGPTNOEXCRF.CLGPRTSNOWITHHYPHENRF ) ";
                    fromstr += "LEFT OUTER JOIN PTMKRPRICEPMRF AS PTMKRPRICERF ";
                    fromstr += "ON ( PTMKRPRICERF.PARTSPRICEREVCDRF=0 ";  //���i���i����敪��0�Œ�Ȃ̂�0�Œ�Ŏw��
                    fromstr += "AND  PTMKRPRICERF.NEWPRTSNOWITHHYPHENRF = CLGPTNOEXCRF.CLGPRTSNOWITHHYPHENRF ";
                    fromstr += "AND  PTMKRPRICERF.MAKERCODERF = CLGPTNOEXCRF.CATALOGPARTSMAKERCDRF ";
                    fromstr += "AND  PTMKRPRICERF.PARTSPRICESTDATERF <= @PARTSPRICESTDATE) ";  //���t���v����ȑO�Ɏw��
                    fromstr += "LEFT OUTER JOIN SEARCHPRTNMRF ON (SUBTABLE02.TBSPARTSCODERF = SEARCHPRTNMRF.TBSPARTSCODERF ";
                    fromstr += "AND ( SUBTABLE02.CATALOGPARTSMAKERCDRF = SEARCHPRTNMRF.CARMAKERCODERF OR SEARCHPRTNMRF.CARMAKERCODERF = 0 )) ";


                    //PARTITION BY��ŏ��Ԃ��������R�[�h��ROWNUM=1�ň��k���鏈��
                    wherestr = ") AS SUBTABLE03 ";
                    wherestr += "WHERE ROWNUM2 = 1 ";

                    orderstring = " ORDER BY SERIESMODELRF, CATEGORYSIGNMODELRF, EXHAUSTGASSIGNRF, CLGPRTSNOWITHHYPHENRF, CATALOGPARTSMAKERCDRF , MODELPRTSADPTYMRF, PARTSPRICESTDATERF ";
                    // --- UPD T.Nishi 2012/01/24 ----------<<<<<

                }
                else //>>>>>>�i�Ԍ����̏ꍇ
                {
                    // Select�R�}���h����(���i���̃}�X�^��JOIN���[�h)���i�Ԍ����̏ꍇ�͎ԗ��̍i��͂Ȃ�
                    //selectstr = "SELECT Cast(  DecryptByKey(PARTSNAMERF.PARTSNAMERF) AS NVARCHAR(60)  ) AS PARTSNAMERF,PARTSCODERF,PARTSSEARCHCODERF,MAKERCODERF,NEWPRTSNOWITHHYPHENRF,NEWPRTSNONONEHYPHENRF,PTMKRPRICERF.TBSPARTSCODERF,TBSPARTSCDDERIVEDNORF,MAKEROFFERPARTSNAMERF,PARTSPRICERF,PARTSLAYERCDRF,PARTSINFOCTRLFLGRF ";
                    selectstr = "SELECT ";
                    if (InPara.SearchType == 1 || InPara.SearchType == 2 || InPara.SearchType == 3)
                        selectstr += "TOP(300) ";

                    #region �i�Ԍ����N�G��
                    selectstr += ctQryPartsNo;

                    // -- UPD 2010/06/14 --------------------->>>
                    //fromstr = " FROM PTMKRPRICERF ";
                    fromstr = " FROM PTMKRPRICEPMRF AS PTMKRPRICERF ";
                    // -- UPD 2010/06/14 ---------------------<<<
                    fromstr += "LEFT OUTER JOIN SEARCHPRTNMRF ON (PTMKRPRICERF.TBSPARTSCODERF = SEARCHPRTNMRF.TBSPARTSCODERF ";
                    fromstr += "AND PTMKRPRICERF.MAKERCODERF = SEARCHPRTNMRF.CARMAKERCODERF) ";

                    #endregion
                    switch (InPara.SearchType)
                    {
                        case 0: // ���S��v
                            partsNo = originalPartsNo;
                            wherestr = " WHERE PTMKRPRICERF.NEWPRTSNOWITHHYPHENRF = @CLGPRTSNOWITHHYPHEN ";
                            break;
                        case 1: // �O����v
                            partsNo = originalPartsNo + "%";
                            wherestr = " WHERE PTMKRPRICERF." + queryCol + " LIKE @CLGPRTSNOWITHHYPHEN ";
                            break;
                        case 2: // �����v
                            partsNo = "%" + originalPartsNo;
                            wherestr = " WHERE PTMKRPRICERF." + queryCol + " LIKE @CLGPRTSNOWITHHYPHEN ";
                            break;
                        case 3: // �B������
                            partsNo = "%" + originalPartsNo + "%";
                            wherestr = " WHERE PTMKRPRICERF." + queryCol + " LIKE @CLGPRTSNOWITHHYPHEN ";
                            break;
                        case 4: // �n�C�t���������S��v
                            partsNo = originalPartsNo;
                            wherestr = " WHERE PTMKRPRICERF.NEWPRTSNONONEHYPHENRF = @CLGPRTSNOWITHHYPHEN ";
                            break;
                    }
                    if (InPara.MakerCode != 0)
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/24 DEL
                        //wherestr += " AND OFFERDATERF DESC, PTMKRPRICERF.MAKERCODERF = @MAKERCODE";
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/24 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/24 ADD
                        wherestr += " AND PTMKRPRICERF.MAKERCODERF = @MAKERCODE";
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/24 ADD

                    // --- ADD m.suzuki 2010/06/12 ---------->>>>>
                    // �Q�փ��[�J�[���O����
                    if (InPara.TwoWheelerMakerExclude && InPara.TwoWheelerMakerCdSt != 0 && InPara.TwoWheelerMakerCdEd != 0)
                    {
                        wherestr += " AND NOT ( PTMKRPRICERF.MAKERCODERF BETWEEN @TWOWHEELERMAKERCDST AND @TWOWHEELERMAKERCDED ) ";
                    }
                    // --- ADD m.suzuki 2010/06/12 ----------<<<<<

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 DEL
                    //orderstring = " ORDER BY PTMKRPRICERF.TBSPARTSCODERF";
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 ADD
                    //orderstring = " ORDER BY PTMKRPRICERF.MAKERCODERF, PTMKRPRICERF.NEWPRTSNOWITHHYPHENRF";
                    orderstring = " ORDER BY PTMKRPRICERF.NEWPRTSNOWITHHYPHENRF, PTMKRPRICERF.MAKERCODERF";
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 ADD
                }
                string strdum = selectstr + fromstr + wherestr + orderstring;

                SqlCommand sqlCommand = new SqlCommand(strdum, sqlConnection);

                SqlParameter findCLGPRTSNOWITHHYPHEN = null;
                SqlParameter findBLCODE = null;
                switch (BLorPrtsNoflg)
                {
                    case 0://BL�R�[�h
                        findBLCODE = sqlCommand.Parameters.Add("@TBSPARTSCODE", SqlDbType.Int);	//�t�����f���ԍ�
                        findBLCODE.Value = SqlDataMediator.SqlSetInt32(InPara.TbsPartsCode);
                        // --- ADD T.Nishi 2012/01/24 ---------->>>>>
                        ((SqlParameter)sqlCommand.Parameters.Add("@PARTSPRICESTDATE", SqlDbType.Int)).Value = SqlDataMediator.SqlSetInt(ToLongDate(InPara.PriceDate));
                        // --- ADD T.Nishi 2012/01/24 ----------<<<<<
                        break;
                    case 1://�i��
                        findCLGPRTSNOWITHHYPHEN = sqlCommand.Parameters.Add("@CLGPRTSNOWITHHYPHEN", SqlDbType.NVarChar);	//�t�����f���ԍ�
                        findCLGPRTSNOWITHHYPHEN.Value = SqlDataMediator.SqlSetString(partsNo);
                        if (InPara.MakerCode != 0)
                        {
                            ((SqlParameter)sqlCommand.Parameters.Add("@MAKERCODE", SqlDbType.Int)).Value = SqlDataMediator.SqlSetInt(InPara.MakerCode);
                        }
                        // --- ADD m.suzuki 2010/06/12 ---------->>>>>
                        if (InPara.TwoWheelerMakerExclude && InPara.TwoWheelerMakerCdSt != 0 && InPara.TwoWheelerMakerCdEd != 0)
                        {
                            ((SqlParameter)sqlCommand.Parameters.Add("@TWOWHEELERMAKERCDST", SqlDbType.Int)).Value = SqlDataMediator.SqlSetInt(InPara.TwoWheelerMakerCdSt);
                            ((SqlParameter)sqlCommand.Parameters.Add("@TWOWHEELERMAKERCDED", SqlDbType.Int)).Value = SqlDataMediator.SqlSetInt(InPara.TwoWheelerMakerCdEd);
                        }
                        // --- ADD m.suzuki 2010/06/12 ----------<<<<<
                        break;
                }

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    mf = new RetPartsInf();

                    if (BLorPrtsNoflg == 0) // BL����
                    {
                        mf.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                        mf.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                        mf.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
                        mf.CatalogPartsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATALOGPARTSMAKERCDRF"));
                        mf.PartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSFULLNAMERF"));
                        mf.PartsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSHALFNAMERF"));
                        mf.NewPrtsNoWithHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NEWPRTSNOWITHHYPHENRF"));
                        mf.NewPrtsNoNoneHyphen = mf.NewPrtsNoWithHyphen.Replace("-", "");//SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NEWPRTSNONONEHYPHENRF"));
                        mf.MakerOfferPartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKEROFFERPARTSNAMERF"));
                        mf.PriceOfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICEOFFERDATE"));
                        mf.PartsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PARTSPRICERF"));
                        mf.PartsLayerCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSLAYERCDRF"));
                        mf.PartsNarrowingCode = PartsNarrowingCode;
                        if (fullmodelfixExists)//�t���^�Œ�̎w��������΃t���^���Œ�ԍ��擾
                            mf.FullModelFixedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FULLMODELFIXEDNORF"));

                        mf.FigShapeNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FIGSHAPENORF"));
                        mf.PartsOpNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSOPNMRF"));
                        mf.StandardName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STANDARDNAMERF"));
                        mf.ClgPrtsNoWithHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLGPRTSNOWITHHYPHENRF"));
                        mf.ModelPrtsAdptYm = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELPRTSADPTYMRF"));
                        mf.ModelPrtsAblsYm = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELPRTSABLSYMRF"));
                        mf.ModelPrtsAdptFrameNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELPRTSADPTFRAMENORF"));
                        mf.ModelPrtsAblsFrameNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELPRTSABLSFRAMENORF"));
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.27 DEL
                        //mf.PartsQty = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PARTSQTYRF"));
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.27 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.27 ADD
                        mf.PartsQty = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PARTSQTYFORRPRF"));
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.27 ADD
                        mf.ColdDistrictsFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLDDISTRICTSFLAGRF"));
                        mf.ColorNarrowingFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLORNARROWINGFLAGRF"));
                        mf.TrimNarrowingFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TRIMNARROWINGFLAGRF"));
                        mf.EquipNarrowingFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EQUIPNARROWINGFLAGRF"));
                        mf.PartsUniqueNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PARTSPROPERNORF"));
                        mf.PartsPriceStDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PARTSPRICESTDATERF"));
                        mf.MakerOfferPartsKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKEROFFERPARTSKANARF"));
                        mf.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.23 ADD
                        mf.SeriesModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SERIESMODELRF"));
                        mf.CategorySignModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CATEGORYSIGNMODELRF"));
                        mf.ExhaustGasSign = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EXHAUSTGASSIGNRF"));
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.23 ADD
                        // 2009/10/23 Add >>>
                        mf.SrchPNmAcqrCarMkrCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SRCHPNMACQRCARMKRCD"));
                        // 2009/10/23 Add <<<
                        // --- ADD m.suzuki 2011/05/18 ---------->>>>>
                        mf.AutoEstimatePartsCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AUTOESTIMATEPARTSCDRF"));
                        mf.TbsPartsCdDerivedNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNMRF"));
                        // --- ADD m.suzuki 2011/05/18 ----------<<<<<
                        //>>>2013/02/12
                        mf.PrimeJoinLnkFlg = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIMEJOINLNKFLGRF"));
                        //<<<2013/02/12

                        // --- ADD 2013/03/27 ---------->>>>>
                        // VIN�R�[�h�i���L���ɂ�����炸�A�uVIN���Y���i�n���j�v�E�uVIN���Y���i�I���j�v���擾
                        mf.VinProduceStartNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("VINPRODUCESTARTNORF"));
                        mf.VinProduceEndNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("VINPRODUCEENDNORF"));
                        // --- ADD 2013/03/27 ----------<<<<<
                    }
                    else
                    {
                        mf.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                        mf.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                        mf.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
                        mf.CatalogPartsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));
                        // 2009/10/23 >>>
                        //mf.PartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSFULLNAMERF"));
                        //mf.PartsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSHALFNAMERF"));
                        mf.PartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKEROFFERPARTSNAMERF"));
                        mf.PartsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKEROFFERPARTSKANARF"));
                        // 2009/10/23 <<<
                        mf.NewPrtsNoWithHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NEWPRTSNOWITHHYPHENRF"));
                        mf.NewPrtsNoNoneHyphen = mf.NewPrtsNoWithHyphen.Replace("-", "");//SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NEWPRTSNONONEHYPHENRF"));
                        mf.MakerOfferPartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKEROFFERPARTSNAMERF"));
                        mf.PartsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PARTSPRICERF"));
                        mf.PartsLayerCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSLAYERCDRF"));
                        mf.PriceOfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICEOFFERDATE"));
                        mf.PartsPriceStDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PARTSPRICESTDATERF"));
                        mf.PartsNarrowingCode = PartsNarrowingCode;
                        mf.ClgPrtsNoWithHyphen = mf.NewPrtsNoWithHyphen;// SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NEWPRTSNOWITHHYPHENRF"));
                        mf.MakerOfferPartsKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKEROFFERPARTSKANARF"));
                        mf.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));

                    }
                    RetInf.Add(mf);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                if (myReader != null && !myReader.IsClosed)
                    myReader.Close();

                // �Â����i[���i���̂Ȃ����i]�����Ή�
                //>>>>>>>>�i�Ԉ�v�����̏ꍇ�@���i��փ}�X�^������
                //�@�����܂������̏ꍇ�͌Â����i�͌����ΏۊO�Ƃ���B
                if ((BLorPrtsNoflg == 1) && (InPara.SearchType == 0 || InPara.SearchType == 4))// && (InPara.PrtsNoWithHyphen.Trim() != ""))
                {
                    // Select�R�}���h����(�i�ԁA�ϊ��A���i�}�X�^��JOIN���[�h)
                    selectstr = "SELECT CATALOGPARTSMAKERCDRF,OLDPARTSNOWITHHYPHENRF,PARTSQTYRF,PARTSSUBSTRF.OFFERDATERF, ";
                    selectstr += "PTMKRPRICERF.TBSPARTSCODERF,TBSPARTSCDDERIVEDNORF,MAKEROFFERPARTSNAMERF,PARTSPRICERF,PARTSLAYERCDRF,";
                    selectstr += "PTMKRPRICERF.OFFERDATERF AS PRICEOFFERDATE, PTMKRPRICERF.MAKEROFFERPARTSKANARF, PTMKRPRICERF.OPENPRICEDIVRF ";

                    fromstr = "FROM PARTSSUBSTRF ";
                    // -- UPD 2010/06/14 ------------------------------------->>>
                    //fromstr += " LEFT OUTER JOIN PTMKRPRICERF ON ( PARTSSUBSTRF.OLDPARTSNOWITHHYPHENRF=PTMKRPRICERF.NEWPRTSNOWITHHYPHENRF AND ";
                    fromstr += " LEFT OUTER JOIN PTMKRPRICEPMRF AS PTMKRPRICERF ON ( PARTSSUBSTRF.OLDPARTSNOWITHHYPHENRF=PTMKRPRICERF.NEWPRTSNOWITHHYPHENRF AND ";
                    // -- UPD 2010/06/14 -------------------------------------<<<
                    fromstr += "PARTSSUBSTRF.CATALOGPARTSMAKERCDRF=PTMKRPRICERF.MAKERCODERF ) ";
                    wherestr = " WHERE PARTSSUBSTRF.OLDPARTSNOWITHHYPHENRF = @CLGPRTSNOWITHHYPHEN ";

                    if (InPara.MakerCode != 0)
                        wherestr += "AND PARTSSUBSTRF.CATALOGPARTSMAKERCDRF = @MAKERCODE";
                    wherestr += " AND PARTSSUBSTRF.MAINORSUBPARTSDIVCDRF=0 ";

                    orderstring = " ORDER BY PARTSSUBSTRF.CATALOGPARTSMAKERCDRF,PARTSSUBSTRF.OLDPARTSNOWITHHYPHENRF,PARTSSUBSTRF.NPRTNOWITHHYPNDSPODRRF,";
                    orderstring += "PARTSSUBSTRF.MAINORSUBPARTSDIVCDRF ";
                    strdum = selectstr + " " + fromstr + " " + wherestr + " " + orderstring;

                    sqlCommand = new SqlCommand(strdum, sqlConnection);

                    findCLGPRTSNOWITHHYPHEN = sqlCommand.Parameters.Add("@CLGPRTSNOWITHHYPHEN", SqlDbType.NVarChar);	//�t�����f���ԍ�
                    findCLGPRTSNOWITHHYPHEN.Value = SqlDataMediator.SqlSetString(originalPartsNo.Trim());
                    if (InPara.MakerCode != 0)
                    {
                        ((SqlParameter)sqlCommand.Parameters.Add("@MAKERCODE", SqlDbType.Int)).Value = SqlDataMediator.SqlSetInt(InPara.MakerCode);
                    }

                    myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        mf = new RetPartsInf();

                        mf.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                        mf.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                        mf.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
                        mf.PartsQty = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PARTSQTYRF"));
                        mf.CatalogPartsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATALOGPARTSMAKERCDRF"));
                        mf.NewPrtsNoWithHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OLDPARTSNOWITHHYPHENRF"));
                        mf.NewPrtsNoNoneHyphen = mf.NewPrtsNoWithHyphen.Replace("-", "");//SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NEWPRTSNONONEHYPHENRF"));
                        mf.MakerOfferPartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKEROFFERPARTSNAMERF"));
                        mf.PartsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PARTSPRICERF"));
                        mf.PartsLayerCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSLAYERCDRF"));
                        mf.PriceOfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICEOFFERDATE"));
                        mf.PartsNarrowingCode = PartsNarrowingCode;
                        mf.MakerOfferPartsKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKEROFFERPARTSKANARF"));
                        mf.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));

                        RetInf.Add(mf);

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        break;
                    }
                }

            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed)
                    myReader.Close();
            }
            //�Í����L�[�N���[�Y
            //if (sqlEncriptInfo != null && sqlEncriptInfo.IsOpen) sqlEncriptInfo.CloseSymKey(ref sqlConnection);

            return status;
        }

        //private bool isAutoAnswer(List<AutoAnsItemStForOffer> foundAutoAnsItemStList)
        //{
        //    bool existNewGoodsNo = false;
        //    AutoAnsItemStForOffer selectAutoAnsItemSt = new AutoAnsItemStForOffer();

        //    foreach (GoodsUnitData goods in revisedGoodsUnitDataList)
        //    {
        //        if (goods.GoodsMakerCd == row.GoodsMakerCd &&
        //            goods.GoodsNo == row.NewGoodsNo)
        //        {
        //            existNewGoodsNo = true;
        //            // �����񓚕i�ڐݒ�}�X�^������
        //            selectAutoAnsItemSt = autoAnsItemStDB.Find(foundAutoAnsItemStList, goods, CurrentHeaderRecord.CustomerCode);
        //            break;
        //        }
        //    }
        //    // �V�i�ԂŌ�����Ȃ��ꍇ�A���i�ԂŌ���
        //    if (!existNewGoodsNo)
        //    {
        //        foreach (GoodsUnitData goods in revisedGoodsUnitDataList)
        //        {
        //            if (goods.GoodsMakerCd == row.GoodsMakerCd &&
        //                goods.GoodsNo == row.GoodsNo)
        //            {
        //                // �����񓚕i�ڐݒ�}�X�^������
        //                selectAutoAnsItemSt = autoAnsItemStDB.Find(foundAutoAnsItemStList, goods, CurrentHeaderRecord.CustomerCode);
        //                break;
        //            }
        //        }
        //    }

        //    // �����񓚕i�ڐݒ�}�X�^�ɓo�^���Ȃ��ꍇ�A���̕i�ڂ�
        //    if (selectAutoAnsItemSt == null)
        //    {
        //        continue;
        //    }

        //    // �����񓚕i�ڐݒ�}�X�^.�����񓚋敪�̔���
        //    bool autoAnswer = false;
        //    if (!selectAutoAnsItemSt.AutoAnswerDiv.Equals((int)AutoAnsItemStAgent.AutoAnswerDiv.None))
        //    {
        //        // �_�~�[�i�ԂłȂ���Ύ����񓚂���
        //        if (trow.PrimeJoinLnkFlg.Equals(0))
        //        {
        //            autoAnswer = true;
        //        }
        //    }

        //}
        // ���x���P�e�X�g --------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        // -- DEL 2010/11/02 ---------------------------->>>
        #region [���g�p�̂��ߍ폜]
        //// 2010/01/25 Add >>>
        ///// <summary>
        ///// �o�l�p���i�������W�b�N�i�a�k�R�[�h�����j
        ///// </summary>
        ///// <param name="InPara">�����p�����[�^</param>
        ///// <param name="RetInf">���o�������i���R�[�h</param>
        ///// <param name="sqlConnection">�R�l�N�V�����N���X</param>
        ///// <returns></returns>
        //private int SearchPartsInfProc_BLSearch(GetPartsInfPara InPara, ref ArrayList RetInf, ref SqlConnection sqlConnection)
        //{

        //    SqlDataReader myReader = null;
        //    //SqlEncryptInfo sqlEncriptInfo = null;
        //    //���ʂ̏�����
        //    RetInf = new ArrayList();
        //    //���ʂ�ArrayList�ɂ�����Ə��N���X
        //    RetPartsInf mf = null;

        //    int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
        //    string selectstr = string.Empty;
        //    string fromstr = string.Empty;
        //    string wherestr = string.Empty;
        //    string orderstring = string.Empty;

        //    //�����t���O��`
        //    bool fullmodelfixExists;

        //    //====�t���^�w��ԍ������邩�Ȃ����̔���
        //    int[] full = null;
        //    if (InPara.FullModelFixedNo != null)
        //    {
        //        full = InPara.FullModelFixedNo;
        //        fullmodelfixExists = true;
        //    }
        //    else
        //    {
        //        fullmodelfixExists = false;
        //    }

        //    const int readCnt = 30;

        //    ArrayList fullModelFixedNoList = new ArrayList();

        //    // �t���^���Œ�ԍ���readCnt���ɕ���
        //    if (fullmodelfixExists)//�t���^���̍i�肪����Ȃ��
        //    {
        //        StringBuilder sb = new StringBuilder(1000);
        //        int cnt = full.GetLength(0);
        //        for (int lpcnt = 1; lpcnt <= cnt; lpcnt++)
        //        {
        //            sb.Append(",");
        //            sb.Append(full[lpcnt - 1]);

        //            if (( lpcnt % readCnt == 0 ) || ( lpcnt == cnt ))
        //            {
        //                sb.Append(") ");
        //                if (sb.Length > 2)
        //                {
        //                    sb.Remove(0, 1).Insert(0, " AND CLGPNOINDXRF.FULLMODELFIXEDNORF IN (");
        //                }

        //                fullModelFixedNoList.Add(sb.ToString());

        //                sb = new StringBuilder(1000);
        //            }
        //        }
        //    }

        //    if (fullModelFixedNoList.Count == 0)
        //    {
        //        fullModelFixedNoList.Add(""); // �_�~�[
        //    }

        //    try
        //    {
        //        //���Í������i��������
        //        //sqlEncriptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB, new string[] { "PARTSNAMERF", "CLGPNOINFORF" });
        //        //�Í����L�[OPEN�iSQLException�̉\���L��j
        //        //sqlEncriptInfo.OpenSymKey(ref sqlConnection);

        //        for (int index = 0; index < fullModelFixedNoList.Count; index++)
        //        {
        //            // Select�R�}���h����(�i�ԁA�ϊ��A���i�}�X�^��JOIN���[�h)
        //            selectstr = ctQryBLSearch;

        //            // -- UPD 2010/06/14 ------------------------>>>
        //            //fromstr = "FROM CLGPNOINFORF ";
        //            fromstr = "FROM (SELECT * FROM CLGPNOINFORF UNION SELECT * FROM PRIMEJOINLNKRF) AS CLGPNOINFORF ";
        //            // -- UPD 2010/06/14 ------------------------<<<
        //            fromstr += "LEFT OUTER JOIN CLGPTNOEXCRF ON ( CLGPNOINFORF.CATALOGPARTSMAKERCDRF = CLGPTNOEXCRF.CATALOGPARTSMAKERCDRF ";
        //            fromstr += "AND CLGPNOINFORF.CLGPRTSNOWITHHYPHENRF=CLGPTNOEXCRF.CLGPRTSNOWITHHYPHENRF ) ";
        //            // -- UPD 2010/06/14 ----------------------------------------------->>>
        //            //fromstr += "LEFT OUTER JOIN PTMKRPRICERF ON ( CLGPTNOEXCRF.CLGPRTSNOWITHHYPHENRF = PTMKRPRICERF.NEWPRTSNOWITHHYPHENRF ";
        //            fromstr += "LEFT OUTER JOIN PTMKRPRICEPMRF AS PTMKRPRICERF ON ( CLGPTNOEXCRF.CLGPRTSNOWITHHYPHENRF = PTMKRPRICERF.NEWPRTSNOWITHHYPHENRF ";
        //            // -- UPD 2010/06/14 -----------------------------------------------<<<
        //            fromstr += "AND CLGPTNOEXCRF.CATALOGPARTSMAKERCDRF=PTMKRPRICERF.MAKERCODERF ) ";
        //            fromstr += "LEFT OUTER JOIN SEARCHPRTNMRF ON (CLGPNOINFORF.TBSPARTSCODERF = SEARCHPRTNMRF.TBSPARTSCODERF ";
        //            fromstr += "AND ( CLGPNOINFORF.CATALOGPARTSMAKERCDRF = SEARCHPRTNMRF.CARMAKERCODERF OR SEARCHPRTNMRF.CARMAKERCODERF = 0 )) ";

        //            if (fullmodelfixExists)//�t���^�Œ�̎w���������Index��Join����
        //                fromstr += " LEFT OUTER JOIN CLGPNOINDXRF ON ( CLGPNOINDXRF.PARTSPROPERNORF=CLGPNOINFORF.PARTSPROPERNORF) ";

        //            fromstr += "LEFT OUTER JOIN CARMODELRF ON ( CLGPNOINDXRF.FULLMODELFIXEDNORF=CARMODELRF.FULLMODELFIXEDNORF) ";

        //            wherestr = " WHERE CLGPNOINFORF.TBSPARTSCODERF = @TBSPARTSCODE ";

        //            wherestr += fullModelFixedNoList[index].ToString();

        //            if (InPara.ProduceTypeOfYear != 0)
        //            {
        //                wherestr += string.Format(" AND (MODELPRTSADPTYMRF = 0 OR MODELPRTSADPTYMRF <= {0}) ", InPara.ProduceTypeOfYear);
        //                wherestr += string.Format(" AND (MODELPRTSABLSYMRF = 0 OR MODELPRTSABLSYMRF >= {0}) ", InPara.ProduceTypeOfYear);
        //            }
        //            else if (string.IsNullOrEmpty(InPara.ChassisNo) == false)
        //            {
        //                int frameNo = Convert.ToInt32(InPara.ChassisNo);
        //                wherestr += string.Format(" AND (MODELPRTSADPTFRAMENORF = 0 OR MODELPRTSADPTFRAMENORF <= {0}) ", frameNo);
        //                wherestr += string.Format(" AND (MODELPRTSABLSFRAMENORF = 0 OR MODELPRTSABLSFRAMENORF >= {0}) ", frameNo);
        //            }

        //            orderstring = " ORDER BY CARMODELRF.SERIESMODELRF, CARMODELRF.CATEGORYSIGNMODELRF, CARMODELRF.EXHAUSTGASSIGNRF, CLGPNOINFORF.CLGPRTSNOWITHHYPHENRF, CLGPNOINFORF.CATALOGPARTSMAKERCDRF , CLGPNOINFORF.MODELPRTSADPTYMRF, PTMKRPRICERF.PARTSPRICESTDATERF ";

        //            string strdum = selectstr + fromstr + wherestr + orderstring;

        //            SqlCommand sqlCommand = new SqlCommand(strdum, sqlConnection);

        //            SqlParameter findBLCODE = null;

        //            findBLCODE = sqlCommand.Parameters.Add("@TBSPARTSCODE", SqlDbType.Int);	//�t�����f���ԍ�
        //            findBLCODE.Value = SqlDataMediator.SqlSetInt32(InPara.TbsPartsCode);

        //            myReader = sqlCommand.ExecuteReader();

        //            while (myReader.Read())
        //            {
        //                #region ���ʂ̃Z�b�g
        //                mf = new RetPartsInf();

        //                mf.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
        //                mf.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
        //                mf.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
        //                mf.CatalogPartsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATALOGPARTSMAKERCDRF"));
        //                mf.PartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSFULLNAMERF"));
        //                mf.PartsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSHALFNAMERF"));
        //                mf.NewPrtsNoWithHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NEWPRTSNOWITHHYPHENRF"));
        //                mf.NewPrtsNoNoneHyphen = mf.NewPrtsNoWithHyphen.Replace("-", "");//SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NEWPRTSNONONEHYPHENRF"));
        //                mf.MakerOfferPartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKEROFFERPARTSNAMERF"));
        //                mf.PriceOfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICEOFFERDATE"));
        //                mf.PartsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PARTSPRICERF"));
        //                mf.PartsLayerCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSLAYERCDRF"));
        //                mf.PartsNarrowingCode = PartsNarrowingCode;
        //                if (fullmodelfixExists)//�t���^�Œ�̎w��������΃t���^���Œ�ԍ��擾
        //                    mf.FullModelFixedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FULLMODELFIXEDNORF"));

        //                mf.FigShapeNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FIGSHAPENORF"));
        //                mf.PartsOpNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSOPNMRF"));
        //                mf.StandardName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STANDARDNAMERF"));
        //                mf.ClgPrtsNoWithHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLGPRTSNOWITHHYPHENRF"));
        //                mf.ModelPrtsAdptYm = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELPRTSADPTYMRF"));
        //                mf.ModelPrtsAblsYm = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELPRTSABLSYMRF"));
        //                mf.ModelPrtsAdptFrameNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELPRTSADPTFRAMENORF"));
        //                mf.ModelPrtsAblsFrameNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELPRTSABLSFRAMENORF"));
        //                mf.PartsQty = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PARTSQTYFORRPRF"));
        //                mf.ColdDistrictsFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLDDISTRICTSFLAGRF"));
        //                mf.ColorNarrowingFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLORNARROWINGFLAGRF"));
        //                mf.TrimNarrowingFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TRIMNARROWINGFLAGRF"));
        //                mf.EquipNarrowingFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EQUIPNARROWINGFLAGRF"));
        //                mf.PartsUniqueNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PARTSPROPERNORF"));
        //                mf.PartsPriceStDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PARTSPRICESTDATERF"));
        //                mf.MakerOfferPartsKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKEROFFERPARTSKANARF"));
        //                mf.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
        //                mf.SeriesModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SERIESMODELRF"));
        //                mf.CategorySignModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CATEGORYSIGNMODELRF"));
        //                mf.ExhaustGasSign = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EXHAUSTGASSIGNRF"));
        //                mf.SrchPNmAcqrCarMkrCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SRCHPNMACQRCARMKRCD"));
        //                RetInf.Add(mf);

        //                #endregion

        //                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //            }
        //            if (myReader != null && !myReader.IsClosed)
        //                myReader.Close();
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        //���N���X�ɗ�O��n���ď������Ă��炤
        //        status = base.WriteSQLErrorLog(ex);
        //    }
        //    finally
        //    {
        //        if (myReader != null && !myReader.IsClosed)
        //            myReader.Close();
        //    }
        //    //�Í����L�[�N���[�Y
        //    //if (sqlEncriptInfo != null && sqlEncriptInfo.IsOpen) sqlEncriptInfo.CloseSymKey(ref sqlConnection);

        //    return status;
        //}
        //// 2010/01/25 Add <<<
        #endregion
        // -- DEL 2010/11/02 ----------------------------<<<

        /// <summary>
        /// �ŐV�i�ԏ��擾�i��ւȂǂł��擾�o���Ȃ������ŐV�i�ԕ��i�̏����擾����j
        /// </summary>
        /// <param name="InPara"></param>
        /// <param name="alRetParts">�������i���X�g</param>
        /// <param name="alprtsubst">��֕��i���X�g</param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 DEL
        //private int SearchNewPartsInf(ArrayList alRetParts, ref ArrayList alprtsubst, ref SqlConnection sqlConnection)
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 ADD
        private int SearchNewPartsInf( GetPartsInfPara InPara, ArrayList alRetParts, ref ArrayList alprtsubst, ref SqlConnection sqlConnection )
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 ADD
        {
            int status = 0;
            // �ŐV�i�ԕ��i��񂪎擾���ꂽ���`�F�b�N
            List<string> lstClgParts = new List<string>();
            int makerCd = ((RetPartsInf)alRetParts[0]).CatalogPartsMakerCd;
            for (int i = 0; i < alRetParts.Count; i++)
            {
                RetPartsInf parts = alRetParts[i] as RetPartsInf;
                for (int j = 0; j < lstClgParts.Count; j++)
                {
                    if (lstClgParts[j] == parts.ClgPrtsNoWithHyphen)
                    {
                        lstClgParts.Remove(parts.ClgPrtsNoWithHyphen);
                        break;
                    }
                }
                if (parts.ClgPrtsNoWithHyphen != parts.NewPrtsNoWithHyphen
                    && lstClgParts.Contains(parts.NewPrtsNoWithHyphen) == false)
                {
                    lstClgParts.Add(parts.NewPrtsNoWithHyphen);
                }
            }
            for (int i = 0; i < alprtsubst.Count; i++)
            {
                for (int j = 0; j < lstClgParts.Count; j++)
                {
                    if (lstClgParts[j] == ((PartsSubstWork)alprtsubst[i]).NewPartsNoWithHyphen)
                    {
                        lstClgParts.RemoveAt(j);
                        break;
                    }
                }
            }
            if (lstClgParts.Count > 0)
            {
                SqlDataReader myReader = null;
                // -- UPD 2010/06/14 ------------------------------------------>>>
                //string query = "SELECT " + ctQryPartsNo + " FROM PTMKRPRICERF "
                string query = "SELECT " + ctQryPartsNo + " FROM PTMKRPRICEPMRF AS PTMKRPRICERF "
                // -- UPD 2010/06/14 ------------------------------------------<<<
                        + "LEFT OUTER JOIN SEARCHPRTNMRF ON (PTMKRPRICERF.TBSPARTSCODERF = SEARCHPRTNMRF.TBSPARTSCODERF "
                        + "AND PTMKRPRICERF.MAKERCODERF = SEARCHPRTNMRF.CARMAKERCODERF) "
                        + "WHERE PTMKRPRICERF.NEWPRTSNOWITHHYPHENRF = @CLGPRTSNOWITHHYPHEN "
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 DEL
                        //+ "AND PTMKRPRICERF.MAKERCODERF = @MAKERCODE";
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 ADD
                        + "AND PTMKRPRICERF.MAKERCODERF = @MAKERCODE "
                        + "AND PTMKRPRICERF.PARTSPRICESTDATERF <= @PRICEDATE "
                        + " ORDER BY PTMKRPRICERF.PARTSPRICESTDATERF DESC ";
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 ADD
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                SqlParameter findCLGPRTSNOWITHHYPHEN = sqlCommand.Parameters.Add("@CLGPRTSNOWITHHYPHEN", SqlDbType.NVarChar);
                SqlParameter findMAKERCODE = sqlCommand.Parameters.Add("@MAKERCODE", SqlDbType.Int);
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 ADD
                SqlParameter findPRICEDATE = sqlCommand.Parameters.Add( "@PRICEDATE", SqlDbType.Int );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 ADD
                try
                {
                    for (int i = 0; i < lstClgParts.Count; i++)
                    {
                        ArrayList RetInf = new ArrayList();
                        GetPartsInfPara search2 = new GetPartsInfPara();
                        findCLGPRTSNOWITHHYPHEN.Value = SqlDataMediator.SqlSetString(lstClgParts[i]);
                        findMAKERCODE.Value = SqlDataMediator.SqlSetInt(makerCd);
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 ADD
                        findPRICEDATE.Value = SqlDataMediator.SqlSetInt( ToLongDate( InPara.PriceDate ) );
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 ADD

                        myReader = sqlCommand.ExecuteReader();
                        if ( myReader.Read() )
                        {
                            PartsSubstWork mf = new PartsSubstWork();
                            mf.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                            mf.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                            mf.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
                            mf.CatalogPartsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));
                            mf.NewPartsNoWithHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NEWPRTSNOWITHHYPHENRF"));
                            mf.NewPrtsNoNoneHyphen = mf.NewPartsNoWithHyphen.Replace("-", "");//SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NEWPRTSNONONEHYPHENRF"));
                            mf.MakerOfferPartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKEROFFERPARTSNAMERF"));
                            mf.MakerOfferPartsKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKEROFFERPARTSKANARF"));
                            mf.PartsLayerCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSLAYERCDRF"));
                            mf.PartsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PARTSPRICERF"));
                            mf.PartsPriceStDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PARTSPRICESTDATERF"));
                            mf.PriceOfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICEOFFERDATE"));
                            mf.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));

                            alprtsubst.Add(mf);
                        }
                        myReader.Close();
                    }
                }
                catch (SqlException ex)
                {
                    //���N���X�ɗ�O��n���ď������Ă��炤
                    status = base.WriteSQLErrorLog(ex);
                }
                finally
                {
                    if (myReader != null && !myReader.IsClosed)
                        myReader.Close();
                    if (sqlCommand != null)
                        sqlCommand.Dispose();
                }
            }
            return status;
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 ADD
        /// <summary>
        /// ���tLongDate�擾�i�����p�j
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private int ToLongDate( DateTime date )
        {
            if ( date != DateTime.MinValue )
            {
                return (date.Year * 10000) + (date.Month * 100) + date.Day;
            }
            else
            {
                return 99991231; // 9999.12.31
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 ADD
        #endregion

        #region [ SearchTbsCodeInfo ]

        /// <summary>
        /// SearchTbsCodeInfo
        /// </summary>
        /// <param name="FullModelFixedNos">�t���^���Œ�ԍ��z��</param>
        /// <param name="PartsNameWorks"></param>
        /// <returns></returns>
        public int SearchTbsCodeInfo(int[] FullModelFixedNos, ref object PartsNameWorks)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            PartsNameWorks = new object();    //�߂茋�ʏ�����

            // --- UPD m.suzuki 2010/04/28 ---------->>>>>
            //status = SearchTbsCodeInfoProc(FullModelFixedNos, ref PartsNameWorks);  //���i�T�[�`
            status = SearchTbsCodeInfoProc( FullModelFixedNos, 0, ref PartsNameWorks );  //���i�T�[�`
            // --- UPD m.suzuki 2010/04/28 ----------<<<<<

            return status;
        }
        // --- ADD m.suzuki 2010/04/28 ---------->>>>>
        /// <summary>
        /// SearchTbsCodeInfo
        /// </summary>
        /// <param name="FullModelFixedNos">�t���^���Œ�ԍ��z��</param>
        /// <param name="blCode"></param>
        /// <param name="PartsNameWorks"></param>
        /// <returns></returns>
        public int SearchTbsCodeInfo( int[] FullModelFixedNos, int blCode, ref object PartsNameWorks )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            PartsNameWorks = new object();    //�߂茋�ʏ�����
            status = SearchTbsCodeInfoProc( FullModelFixedNos, blCode, ref PartsNameWorks );  //���i�T�[�`

            return status;
        }
        // --- ADD m.suzuki 2010/04/28 ----------<<<<<

        // ADD 2014/05/13 PM-SCM���x���� �t�F�[�Y�Q��13.�t���^���Œ�ԍ�����̂a�k�R�[�h�����񐔉��ǑΉ� ---------------------------------->>>>>
        /// <summary>
        /// SearchTbsCodeInfo
        /// </summary>
        /// <param name="FullModelFixedNos">�t���^���Œ�ԍ��z��</param>
        /// <param name="blCode"></param>
        /// <param name="PartsNameWorks"></param>
        /// <returns></returns>
        public int SearchTbsCodeInfo(int[] FullModelFixedNos, ArrayList paraList, ref object PartsNameWorks)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            PartsNameWorks = new object();    //�߂茋�ʏ�����
            status = SearchTbsCodeInfoProc(FullModelFixedNos, paraList, ref PartsNameWorks);  //���i�T�[�`

            return status;
        }
        // ADD 2014/05/13 PM-SCM���x���� �t�F�[�Y�Q��13.�t���^���Œ�ԍ�����̂a�k�R�[�h�����񐔉��ǑΉ� ----------------------------------<<<<<


        /// <summary>
        /// SearchTbsCodeInfoProc
        /// </summary>
        /// <param name="FullModelFixedNos"></param>
        /// <param name="blCode"></param>
        /// <param name="PartsNameWorks"></param>
        /// <returns></returns>
        // --- UPD m.suzuki 2010/04/28 ---------->>>>>
        //private int SearchTbsCodeInfoProc(int[] FullModelFixedNos, ref object PartsNameWorks)
        private int SearchTbsCodeInfoProc( int[] FullModelFixedNos, int blCode, ref object PartsNameWorks )
        // --- UPD m.suzuki 2010/04/28 ----------<<<<<
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            //SqlEncryptInfo sqlEncriptInfo = null;
            SqlConnectionInfo sqlConnectioninfo = null;
            SqlConnection sqlConnection = null;

            ArrayList al = new ArrayList();

            CustomSerializeArrayList RetPartsCustomSerializeArrayList = new CustomSerializeArrayList();//���i���
            PartsNameWorks = RetPartsCustomSerializeArrayList;

            try
            {
                sqlConnectioninfo = new SqlConnectionInfo();
                string connectionText = sqlConnectioninfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (string.IsNullOrEmpty(connectionText))
                {
                    return 99;
                }

                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                StringBuilder fullmodelstr = new StringBuilder();

                if (FullModelFixedNos.GetLength(0) == 0)//�p�����[�^�s��
                {
                    return 99;
                }

                // -- UPD 2010/04/19 -------------------------------------------->>>
                #region [�폜]
                //// 2010/01/25 >>>

                //#region �폜
                ////int cnt = FullModelFixedNos.GetLength(0);

                ////fullmodelstr.Append("(");
                ////for (int lpcnt = 0; lpcnt < cnt; lpcnt++)
                ////{
                ////    if (lpcnt != 0)
                ////        fullmodelstr.Append(",");

                ////    fullmodelstr.Append(FullModelFixedNos[lpcnt].ToString());

                ////}
                ////fullmodelstr.Append(")");

                ////// Select�R�}���h����(CLGPNOINDXRF,CLGPNOINFORF,offertbspartscoderf)
                ////string selectstr = "SELECT TBSPARTSCODERF, TBSPARTSFULLNAMERF, TBSPARTSHALFNAMERF, EQUIPGENRERF, PRIMESEARCHFLGRF ";
                ////selectstr += "FROM TBSPARTSCODERF WHERE TBSPARTSCODERF IN ";
                ////selectstr += "( SELECT TBSPARTSCODERF FROM CLGPNOINFORF LEFT OUTER JOIN CLGPNOINDXRF ON ";
                ////selectstr += "( CLGPNOINDXRF.PARTSPROPERNORF = CLGPNOINFORF.PARTSPROPERNORF ) ";
                ////selectstr += "WHERE CLGPNOINDXRF.FULLMODELFIXEDNORF IN " + fullmodelstr.ToString() + " GROUP BY TBSPARTSCODERF) ORDER BY TBSPARTSCODERF";

                ////SqlCommand sqlCommand = new SqlCommand(selectstr, sqlConnection);

                ////sqlCommand.CommandTimeout = 20;//�^�C���A�E�g�Q�O�b�ɐݒ�@�f�t�H���g�T�b

                ////myReader = sqlCommand.ExecuteReader();
                ////while (myReader.Read())
                ////{
                ////    RetTbsPartsCodeWork mf = new RetTbsPartsCodeWork();

                ////    mf.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                ////    mf.TbsPartsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TBSPARTSFULLNAMERF"));
                ////    mf.TbsPartsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TBSPARTSHALFNAMERF"));
                ////    mf.EquipGenre = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EQUIPGENRERF"));
                ////    mf.PrimeSearchFlg = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIMESEARCHFLGRF"));

                ////    al.Add(mf);

                ////    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                ////}
                //#endregion

                //List<RetTbsPartsCodeWork> searchList = new List<RetTbsPartsCodeWork>();
                //const int readCnt = 30;

                //ArrayList fullModelFixedNoList = new ArrayList();
                //// �t���^���Œ�ԍ���readCnt���ɕ���
                //StringBuilder sb = new StringBuilder(1000);
                //int cnt = FullModelFixedNos.GetLength(0);
                //for (int lpcnt = 1; lpcnt <= cnt; lpcnt++)
                //{
                //    sb.Append(",");
                //    sb.Append(FullModelFixedNos[lpcnt - 1]);

                //    if (( lpcnt % readCnt == 0 ) || ( lpcnt == cnt ))
                //    {
                //        sb.Append(") ");
                //        if (sb.Length > 2)
                //        {
                //            sb.Remove(0, 1).Insert(0, " (");
                //        }

                //        fullModelFixedNoList.Add(sb.ToString());

                //        sb = new StringBuilder(1000);
                //    }
                //}

                //for (int index = 0; index < fullModelFixedNoList.Count; index++)
                //{
                //    string selectstr = "SELECT TBSPARTSCODERF, TBSPARTSFULLNAMERF, TBSPARTSHALFNAMERF, EQUIPGENRERF, PRIMESEARCHFLGRF ";
                //    selectstr += "FROM TBSPARTSCODERF WHERE TBSPARTSCODERF IN ";
                //    selectstr += "( SELECT TBSPARTSCODERF FROM CLGPNOINFORF LEFT OUTER JOIN CLGPNOINDXRF ON ";
                //    selectstr += "( CLGPNOINDXRF.PARTSPROPERNORF = CLGPNOINFORF.PARTSPROPERNORF ) ";
                //    selectstr += "WHERE CLGPNOINDXRF.FULLMODELFIXEDNORF IN " + fullModelFixedNoList[index].ToString() + " GROUP BY TBSPARTSCODERF) ORDER BY TBSPARTSCODERF";

                //    SqlCommand sqlCommand = new SqlCommand(selectstr, sqlConnection);

                //    sqlCommand.CommandTimeout = 20;//�^�C���A�E�g�Q�O�b�ɐݒ�@�f�t�H���g�T�b

                //    myReader = sqlCommand.ExecuteReader();
                //    while (myReader.Read())
                //    {
                //        RetTbsPartsCodeWork mf = new RetTbsPartsCodeWork();

                //        mf.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                //        mf.TbsPartsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TBSPARTSFULLNAMERF"));
                //        mf.TbsPartsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TBSPARTSHALFNAMERF"));
                //        mf.EquipGenre = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EQUIPGENRERF"));
                //        mf.PrimeSearchFlg = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIMESEARCHFLGRF"));

                //        searchList.Add(mf);

                //        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                //    }
                //    if (myReader != null && !myReader.IsClosed)
                //        myReader.Close();       //���[�_�[�N���[�Y
                //}

                //// BL�R�[�h�̍i�荞��
                //List<int> blCodeList = new List<int>();
                //foreach (RetTbsPartsCodeWork mf in searchList)
                //{
                //    if (!blCodeList.Contains(mf.TbsPartsCode))
                //    {
                //        blCodeList.Add(mf.TbsPartsCode);
                //        al.Add(mf);
                //    }
                //}

                //// 2010/01/25 <<<
                #endregion

                int cnt = FullModelFixedNos.GetLength(0);

                fullmodelstr.Append("(");
                for (int lpcnt = 0; lpcnt < cnt; lpcnt++)
                {
                    if (lpcnt != 0)
                        fullmodelstr.Append(",");

                    fullmodelstr.Append(FullModelFixedNos[lpcnt].ToString());

                }
                fullmodelstr.Append(")");

                string selectstr = "";

                // --- ADD m.suzuki 2010/06/04 ---------->>>>>
                if ( blCode == 0 )
                {
                // --- ADD m.suzuki 2010/06/04 ----------<<<<<

                    //�ꎞ�e�[�u���쐬
                    selectstr += "SELECT PARTSPROPERNORF INTO #CLGPNOINDXRF_WORK ";
                    selectstr += "FROM CLGPNOINDXRF ";
                    selectstr += "WHERE CLGPNOINDXRF.FULLMODELFIXEDNORF IN " + fullmodelstr.ToString() + " ";
                    selectstr += "GROUP BY PARTSPROPERNORF ";

                    // Select�R�}���h����(CLGPNOINDXRF,CLGPNOINFORF,offertbspartscoderf)
                    selectstr += "SELECT TBSPARTSCODERF, TBSPARTSFULLNAMERF, TBSPARTSHALFNAMERF, EQUIPGENRERF, PRIMESEARCHFLGRF ";
                    selectstr += "FROM TBSPARTSCODERF WHERE TBSPARTSCODERF IN ( ";
                    selectstr += "SELECT TBSPARTSCODERF FROM #CLGPNOINDXRF_WORK ";
                    //-- UPD 2010/06/14 ------------------------------->>>
                    //selectstr += "LEFT OUTER JOIN CLGPNOINFORF ";
                    // -- UPD 2010/11/22 -------------------------------------->>>
                    //selectstr += "LEFT OUTER JOIN (SELECT * FROM CLGPNOINFORF UNION SELECT * FROM PRIMEJOINLNKRF) AS CLGPNOINFORF ";
                    // --- UPD 2013/03/27 ---------->>>>>
                    //selectstr += "LEFT OUTER JOIN (SELECT * FROM CLGPNOINFORF UNION ALL SELECT * FROM PRIMEJOINLNKRF) AS CLGPNOINFORF ";
                    //�J�^���O���i�i�ԏ��}�X�^�ɕs�����Ă������_�~�[�Ƃ���UNION ALL����
                    selectstr += "LEFT OUTER JOIN ( SELECT *, ";
                    selectstr += "NULL AS PRODUCEFACTORYCDRF, ";
                    selectstr += "0 AS VINPRODUCESTARTNORF, ";
                    selectstr += "0 AS VINPRODUCEENDNORF ";
                    selectstr += "FROM CLGPNOINFORF UNION ALL SELECT * FROM PRIMEJOINLNKRF) AS CLGPNOINFORF ";
                    // --- UPD 2013/03/27 ----------<<<<<
                    // -- UPD 2010/11/22 --------------------------------------<<<
                    //-- UPD 2010/06/14 -------------------------------<<<
                    selectstr += "ON ( #CLGPNOINDXRF_WORK.PARTSPROPERNORF = CLGPNOINFORF.PARTSPROPERNORF )  ";
                    selectstr += "GROUP BY TBSPARTSCODERF  ";

                    selectstr += ") ORDER BY TBSPARTSCODERF";

                // --- ADD m.suzuki 2010/06/04 ---------->>>>>
                }
                else
                {
                    // Select�R�}���h����(CLGPNOINDXRF,CLGPNOINFORF,offertbspartscoderf)
                    selectstr += "SELECT TBSPARTSCODERF, TBSPARTSFULLNAMERF, TBSPARTSHALFNAMERF, EQUIPGENRERF, PRIMESEARCHFLGRF ";
                    selectstr += "FROM TBSPARTSCODERF WHERE TBSPARTSCODERF = " + blCode.ToString() + " ";
                    selectstr += "ORDER BY TBSPARTSCODERF";
                }
                // --- ADD m.suzuki 2010/06/04 ----------<<<<<

                SqlCommand sqlCommand = new SqlCommand(selectstr, sqlConnection);

                sqlCommand.CommandTimeout = 20;//�^�C���A�E�g�Q�O�b�ɐݒ�@�f�t�H���g�T�b

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    RetTbsPartsCodeWork mf = new RetTbsPartsCodeWork();

                    mf.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                    mf.TbsPartsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TBSPARTSFULLNAMERF"));
                    mf.TbsPartsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TBSPARTSHALFNAMERF"));
                    mf.EquipGenre = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EQUIPGENRERF"));
                    mf.PrimeSearchFlg = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIMESEARCHFLGRF"));

                    al.Add(mf);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

                // -- UPD 2010/04/19 --------------------------------------------<<<
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed)
                    myReader.Close();       //���[�_�[�N���[�Y
                sqlConnection.Close();                          //�R�l�N�V�����N���[�Y
                sqlConnection.Dispose();                        //�R�l�N�V�����j��
            }

            RetPartsCustomSerializeArrayList.Add(al);           //���i���

            return status;
        }

        // ADD 2014/05/13 PM-SCM���x���� �t�F�[�Y�Q��13.�t���^���Œ�ԍ�����̂a�k�R�[�h�����񐔉��ǑΉ� ---------------------------------->>>>>
        /// <summary>
        /// SearchTbsCodeInfoProc
        /// </summary>
        /// <param name="FullModelFixedNos"></param>
        /// <param name="blCode"></param>
        /// <param name="PartsNameWorks"></param>
        /// <returns></returns>
        private int SearchTbsCodeInfoProc(int[] FullModelFixedNos, ArrayList paraList, ref object PartsNameWorks)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlConnectionInfo sqlConnectioninfo = null;
            SqlConnection sqlConnection = null;

            ArrayList al = new ArrayList();

            CustomSerializeArrayList RetPartsCustomSerializeArrayList = new CustomSerializeArrayList();//���i���
            PartsNameWorks = RetPartsCustomSerializeArrayList;

            List<int> paraListWrok = new List<int>((int[])paraList.ToArray(typeof(int)));

            try
            {
                sqlConnectioninfo = new SqlConnectionInfo();
                string connectionText = sqlConnectioninfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (string.IsNullOrEmpty(connectionText))
                {
                    return 99;
                }

                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                StringBuilder fullmodelstr = new StringBuilder();

                if (FullModelFixedNos.GetLength(0) == 0)//�p�����[�^�s��
                {
                    return 99;
                }

                int cnt = FullModelFixedNos.GetLength(0);

                fullmodelstr.Append("(");
                for (int lpcnt = 0; lpcnt < cnt; lpcnt++)
                {
                    if (lpcnt != 0)
                        fullmodelstr.Append(",");

                    fullmodelstr.Append(FullModelFixedNos[lpcnt].ToString());

                }
                fullmodelstr.Append(")");

                string selectstr = "";

                // Select�R�}���h����(CLGPNOINDXRF,CLGPNOINFORF,offertbspartscoderf)
                selectstr += "SELECT TBSPARTSCODERF, TBSPARTSFULLNAMERF, TBSPARTSHALFNAMERF, EQUIPGENRERF, PRIMESEARCHFLGRF ";
                selectstr += "FROM TBSPARTSCODERF ";

                for (int i = 0; i < paraListWrok.Count; i++)
                {
                    if (i == 0)
                        selectstr += " WHERE ";
                    else
                        selectstr += " OR ";

                    selectstr += " (TBSPARTSCODERF = " + paraListWrok[i].ToString() + ") ";
                }

                selectstr += "ORDER BY TBSPARTSCODERF";

                SqlCommand sqlCommand = new SqlCommand(selectstr, sqlConnection);

                sqlCommand.CommandTimeout = 20;//�^�C���A�E�g�Q�O�b�ɐݒ�@�f�t�H���g�T�b

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    RetTbsPartsCodeWork mf = new RetTbsPartsCodeWork();

                    mf.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                    mf.TbsPartsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TBSPARTSFULLNAMERF"));
                    mf.TbsPartsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TBSPARTSHALFNAMERF"));
                    mf.EquipGenre = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EQUIPGENRERF"));
                    mf.PrimeSearchFlg = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIMESEARCHFLGRF"));

                    al.Add(mf);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed)
                    myReader.Close();       //���[�_�[�N���[�Y
                sqlConnection.Close();                          //�R�l�N�V�����N���[�Y
                sqlConnection.Dispose();                        //�R�l�N�V�����j��
            }

            RetPartsCustomSerializeArrayList.Add(al);           //���i���

            return status;
        }
        // ADD 2014/05/13 PM-SCM���x���� �t�F�[�Y�Q��13.�t���^���Œ�ԍ�����̂a�k�R�[�h�����񐔉��ǑΉ� ----------------------------------<<<<<

        #endregion

        #region [ GetPartsInf(�������i����)�����p���\�b�h ]
        /// <summary>
        /// �p�����[�^�̐ݒ�ɂĕ��i�����擾���܂��B
        /// </summary>
        /// <param name="InPara"></param>		
        /// <param name="sqlConnection"></param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �p�����[�^�Ŏw�肳�ꂽ���i�̏����������܂��B</br>
        private int ReadModelNameRF(GetPartsInfPara InPara, ref SqlConnection sqlConnection)
        {
            //���ʂ̏�����
            ArrayList RetInf = new ArrayList();

            int status = 0;
            string selectstr = "";

            // Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter findfull = null;
            SqlParameter findparts = null;
            SqlParameter findpartsdiv = null;

            try
            {

                // Select�R�}���h����(�i�ԁA�ϊ��A���i�}�X�^��JOIN���[�h)
                selectstr = "SELECT PARTSNARROWINGCODERF FROM MODELNAMERF "
                        + " WHERE MAKERCODERF=@MAKERCODERF AND MODELCODERF=@MODELCODERF AND MODELSUBCODERF=@MODELSUBCODERF ";

                SqlCommand sqlCommand = new SqlCommand(selectstr, sqlConnection);

                // Prameter�I�u�W�F�N�g�̍쐬
                findfull = sqlCommand.Parameters.Add("@MAKERCODERF", SqlDbType.Int);
                findparts = sqlCommand.Parameters.Add("@MODELCODERF", SqlDbType.Int);
                findpartsdiv = sqlCommand.Parameters.Add("@MODELSUBCODERF", SqlDbType.Int);

                // Parameter�I�u�W�F�N�g�֒l�ݒ�
                findfull.Value = SqlDataMediator.SqlSetInt32(InPara.MakerCode);
                findparts.Value = SqlDataMediator.SqlSetInt32(InPara.ModelCode);
                findpartsdiv.Value = SqlDataMediator.SqlSetInt32(InPara.ModelSubCode);

                PartsNarrowingCode = (int)sqlCommand.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
            }

            return status;
        }

        /// <summary>
        /// �װ���ޏ����i��
        /// </summary>
        /// <param name="InPara">�����p�����[�^</param>
        /// <param name="RetInf">���i���X�g</param>
        /// <param name="wkColorWork"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private void ExtrColorAll(SerchPartsInfPara InPara, ref ArrayList RetInf, ref ArrayList wkColorWork, ref SqlConnection sqlConnection)
        {
            SqlDataReader myReader = null;

            int status = 0;
            string selectstr = "";
            string fromstr = "";
            string wherestr = "";


            PartsColorWork ptwk = null;
            try
            {
                ArrayList alwk = new ArrayList();

                foreach (RetPartsInf mf in RetInf)
                {
                    //�װ��������Ŋ��ԗ��I���Ŷװ�����͂���Ă���Ȃ�
                    if ((mf.ColorNarrowingFlag == 1))
                    {
                        alwk.Add(mf);
                    }
                }

                if (alwk.Count == 0) return;

                // Select�R�}���h����(�i�ԁA�ϊ��A���i�}�X�^��JOIN���[�h)
                selectstr = "SELECT COLORCDINFONORF,PARTSPROPERNORF ";

                fromstr = "FROM PRTSCLRINFRF ";

                wherestr = " WHERE PARTSPROPERNORF IN (";

                StringBuilder sb = new StringBuilder();

                List<long> lst = new List<long>();
                foreach (RetPartsInf mf in alwk)
                {
                    if (lst.Contains(mf.PartsUniqueNo) == false)
                    {
                        sb.Append(" , " + mf.PartsUniqueNo.ToString());
                        lst.Add(mf.PartsUniqueNo);
                    }
                }
                sb.Remove(0, 2);
                sb.Append(")");

                wherestr += sb.ToString();

                SqlCommand sqlCommand = new SqlCommand(selectstr + " " + fromstr + " " + wherestr, sqlConnection);

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    ptwk = new PartsColorWork();
                    ptwk.ColorCdInfoNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLORCDINFONORF"));
                    ptwk.PartsProperNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PARTSPROPERNORF"));

                    wkColorWork.Add(ptwk);

                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed)
                    myReader.Close();
            }

        }

        /// <summary>
        /// ��я����i��
        /// </summary>
        /// <param name="InPara">�����p�����[�^</param>
        /// <param name="RetInf">���i���X�g</param>
        /// <param name="wkTrimWork"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private void ExtrTrimAll(SerchPartsInfPara InPara, ref ArrayList RetInf, ref ArrayList wkTrimWork, ref SqlConnection sqlConnection)
        {

            SqlDataReader myReader = null;

            int status = 0;
            string selectstr = "";
            string fromstr = "";
            string wherestr = "";

            PartsTrimWork ptwk = null;
            try
            {
                ArrayList alwk = new ArrayList();

                foreach (RetPartsInf mf in RetInf)
                {
                    //��я�������Ŋ��ԗ��I������т����͂���Ă���Ȃ�
                    if (mf.TrimNarrowingFlag == 1)
                    {
                        alwk.Add(mf);
                    }
                }

                if (alwk.Count == 0) return;

                // Select�R�}���h����(�i�ԁA�ϊ��A���i�}�X�^��JOIN���[�h)
                selectstr = "SELECT TRIMCODERF, PARTSPROPERNORF ";

                fromstr = "FROM PRTSTRMINFRF ";

                //COL_PARTSUNIQUENO	= "";
                wherestr = " WHERE PARTSPROPERNORF IN (";

                StringBuilder sb = new StringBuilder();
                List<long> lst = new List<long>();
                foreach (RetPartsInf mf in alwk)
                {
                    if (lst.Contains(mf.PartsUniqueNo) == false)
                    {
                        sb.Append(" , " + mf.PartsUniqueNo.ToString());
                        lst.Add(mf.PartsUniqueNo);
                    }
                }
                sb.Remove(0, 2);
                sb.Append(")");

                wherestr += sb.ToString();

                SqlCommand sqlCommand = new SqlCommand(selectstr + " " + fromstr + " " + wherestr, sqlConnection);

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    ptwk = new PartsTrimWork();

                    ptwk.TrimCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRIMCODERF"));
                    ptwk.PartsProperNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PARTSPROPERNORF"));

                    wkTrimWork.Add(ptwk);
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed)
                    myReader.Close();
            }

        }

        /// <summary>
        /// �����i��
        /// </summary>
        /// <param name="InPara">�����p�����[�^</param>
        /// <param name="Retinf">�����i��</param>
        /// <param name="wkEquipWork"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private void ExtrEquipAll(SerchPartsInfPara InPara, ref ArrayList Retinf, ref ArrayList wkEquipWork, ref SqlConnection sqlConnection)
        {

            SqlDataReader myReader = null;

            int status = 0;
            string selectstr = "";
            string fromstr = "";
            string wherestr = "";

            PartsEquipWork ptwk = null;
            try
            {

                ArrayList alwk = new ArrayList();

                foreach (RetPartsInf mf in Retinf)
                {
                    //��я�������Ŋ��ԗ��I������т����͂���Ă���Ȃ�
                    if (mf.EquipNarrowingFlag == 1)
                    {
                        alwk.Add(mf);
                    }
                }

                if (alwk.Count == 0) return;

                // Select�R�}���h����(�i�ԁA�ϊ��A���i�}�X�^��JOIN���[�h)
                selectstr = "SELECT EQUIPMENTGENRECDRF,EQUIPMENTCODERF,PARTSPROPERNORF ";

                fromstr = "FROM PRTSEQPINFRF ";

                //COL_PARTSUNIQUENO
                wherestr = " WHERE PARTSPROPERNORF IN (";

                StringBuilder sb = new StringBuilder();
                List<long> lst = new List<long>();
                foreach (RetPartsInf mf in alwk)
                {
                    if (lst.Contains(mf.PartsUniqueNo) == false)
                    {
                        sb.Append(" , " + mf.PartsUniqueNo.ToString());
                        lst.Add(mf.PartsUniqueNo);
                    }
                }
                sb.Remove(0, 2);
                sb.Append(")");

                wherestr += sb.ToString();

                SqlCommand sqlCommand = new SqlCommand(selectstr + " " + fromstr + " " + wherestr, sqlConnection);

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    ptwk = new PartsEquipWork();

                    ptwk.EquipmentCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EQUIPMENTCODERF"));
                    ptwk.EquipmentGenreCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EQUIPMENTGENRECDRF"));
                    ptwk.PartsProperNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PARTSPROPERNORF"));

                    wkEquipWork.Add(ptwk);

                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed)
                    myReader.Close();
            }

        }

        /// <summary>
        /// ���i��֒��o
        /// </summary>
        /// <param name="InPara"></param>
        /// <param name="alRetParts"></param>
        /// <param name="alprtsubst"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int ExtrPrtsubstAll(GetPartsInfPara InPara, ref ArrayList alRetParts, ref ArrayList alprtsubst, ref SqlConnection sqlConnection)
        {
            int status = 0;

            if (alRetParts.Count == 0)
                return status;

            SqlDataReader myReader = null;

            string selectstr = "";
            string fromstr = "";
            string wherestr = "";
            StringBuilder sbstr = new StringBuilder();
            string orderstring = "";

            PartsSubstWork ptwk = null;
            try
            {
                //SqlEncryptInfo sqlEncriptInfo = null;

                //���Í������i��������
                //sqlEncriptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB, new string[] { "PARTSNAMERF", "CLGPNOINFORF" });
                //�Í����L�[OPEN�iSQLException�̉\���L��j
                //sqlEncriptInfo.OpenSymKey(ref sqlConnection);

                // Select�R�}���h����(���i��ցA���i�}�X�^��JOIN���[�h)
                // Select�R�}���h����(�i�ԁA�ϊ��A���i�}�X�^��JOIN���[�h)
                selectstr = "SELECT CATALOGPARTSMAKERCDRF,OLDPARTSNOWITHHYPHENRF,PARTSSUBSTRF.NEWPARTSNOWITHHYPHENRF,NPRTNOWITHHYPNDSPODRRF,";
                selectstr += "PARTSPLURALSUBSTFLGRF,MAINORSUBPARTSDIVCDRF,PARTSQTYRF,PARTSPLURALSUBSTCMNTRF,PLRLSUBNEWPRTNOHYPNRF ,NEWPRTSNONONEHYPHENRF,";
                selectstr += "PTMKRPRICERF.TBSPARTSCODERF,TBSPARTSCDDERIVEDNORF,MAKEROFFERPARTSNAMERF,PARTSPRICERF,PARTSPRICESTDATERF,PARTSLAYERCDRF,";
                selectstr += "PARTSSUBSTRF.OFFERDATERF, PTMKRPRICERF.OFFERDATERF AS PRICEOFFERDATERF, PTMKRPRICERF.MAKEROFFERPARTSKANARF, PTMKRPRICERF.OPENPRICEDIVRF ";
                //selectstr += "PARTSNAMERF.PARTSNAMERF,PARTSCODERF,PARTSSEARCHCODERF, PARTSNAMERF.OFFERDATERF, PTMKRPRICERF.OFFERDATERF AS PRICEOFFERDATERF ";

                fromstr = "FROM PARTSSUBSTRF ";
                // -- UPD 2010/06/14 ----------------------------------------->>>
                //fromstr += " LEFT OUTER JOIN PTMKRPRICERF ON ( PARTSSUBSTRF.NEWPARTSNOWITHHYPHENRF=PTMKRPRICERF.NEWPRTSNOWITHHYPHENRF AND ";
                fromstr += " LEFT OUTER JOIN PTMKRPRICEPMRF AS PTMKRPRICERF ON ( PARTSSUBSTRF.NEWPARTSNOWITHHYPHENRF=PTMKRPRICERF.NEWPRTSNOWITHHYPHENRF AND ";
                // -- UPD 2010/06/14 -----------------------------------------<<<
                fromstr += "PARTSSUBSTRF.CATALOGPARTSMAKERCDRF=PTMKRPRICERF.MAKERCODERF  ) ";
                //fromstr += " LEFT OUTER JOIN PARTSNAMERF ON ( PARTSNAMERF.TBSPARTSCODERF=PTMKRPRICERF.TBSPARTSCODERF) ";

                wherestr = " WHERE ";

                int firstflg = 0;
                foreach (RetPartsInf mf in alRetParts)
                {
                    if (firstflg != 0)
                        sbstr.Append(" OR ");

                    if (InPara.TbsPartsCode != 0)//BL�����̏ꍇ�̓J�^���O�i��
                        sbstr.Append(" (PARTSSUBSTRF.CATALOGPARTSMAKERCDRF=" + mf.CatalogPartsMakerCd.ToString() + " AND PARTSSUBSTRF.OLDPARTSNOWITHHYPHENRF='" + mf.ClgPrtsNoWithHyphen + "') ");
                    else//�i�Ԍ����̏ꍇ�͐V�i��
                        sbstr.Append(" (PARTSSUBSTRF.CATALOGPARTSMAKERCDRF=" + mf.CatalogPartsMakerCd.ToString() + " AND PARTSSUBSTRF.OLDPARTSNOWITHHYPHENRF='" + mf.NewPrtsNoWithHyphen + "') ");

                    firstflg++;
                }

                wherestr += sbstr.ToString();
                orderstring = " ORDER BY PARTSSUBSTRF.CATALOGPARTSMAKERCDRF,PARTSSUBSTRF.OLDPARTSNOWITHHYPHENRF,PARTSSUBSTRF.NPRTNOWITHHYPNDSPODRRF,PARTSSUBSTRF.MAINORSUBPARTSDIVCDRF ";

                SqlCommand sqlCommand = new SqlCommand(selectstr + " " + fromstr + " " + wherestr + orderstring, sqlConnection);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    ptwk = new PartsSubstWork();

                    ptwk.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    ptwk.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                    ptwk.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
                    ptwk.CatalogPartsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATALOGPARTSMAKERCDRF"));
                    ptwk.MainOrSubPartsDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAINORSUBPARTSDIVCDRF"));
                    ptwk.NewPartsNoWithHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NEWPARTSNOWITHHYPHENRF"));
                    ptwk.NewPrtsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NEWPRTSNONONEHYPHENRF"));
                    ptwk.MakerOfferPartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKEROFFERPARTSNAMERF"));
                    ptwk.MakerOfferPartsKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKEROFFERPARTSKANARF"));
                    ptwk.OldPartsNoWithHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OLDPARTSNOWITHHYPHENRF"));
                    ptwk.NPrtNoWithHypnDspOdr = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NPRTNOWITHHYPNDSPODRRF"));
                    //ptwk.PartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSCODERF"));
                    ptwk.PartsInfoCtrlFlg = 0;// SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSINFOCTRLFLGRF"));
                    ptwk.PartsLayerCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSLAYERCDRF"));
                    //ptwk.PartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSNAMERF"));
                    ptwk.PartsPluralSubstCmnt = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSPLURALSUBSTCMNTRF"));
                    ptwk.PartsPluralSubstFlg = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSPLURALSUBSTFLGRF"));
                    ptwk.PartsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PARTSPRICERF"));
                    ptwk.PartsPriceStDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PARTSPRICESTDATERF"));
                    ptwk.PartsQty = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "PARTSQTYRF" ) );
                    //ptwk.PartsSearchCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSSEARCHCODERF"));
                    ptwk.PlrlSubNewPrtNoHypn = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PLRLSUBNEWPRTNOHYPNRF"));
                    ptwk.PriceOfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICEOFFERDATERF"));
                    ptwk.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));

                    alprtsubst.Add(ptwk);
                }

                //�Í����L�[�N���[�Y
                //if (sqlEncriptInfo != null && sqlEncriptInfo.IsOpen) sqlEncriptInfo.CloseSymKey(ref sqlConnection);

            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed)
                    myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// ���ꕔ�i���k����
        /// </summary>
        /// <param name="RetInf">���o���ʕ��i���R�[�h</param>
        /// <param name="partsModelLnkWork"></param>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 DEL
        //private void CompressPartsRec(ref ArrayList RetInf, ref List<PartsModelLnkWork> partsModelLnkWork)
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 ADD
        private void CompressPartsRec( GetPartsInfPara InPara, ref ArrayList RetInf, ref List<PartsModelLnkWork> partsModelLnkWork)
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 ADD
        {
# if DEBUG
            int additionCnt = 0;
# endif

            ArrayList alwk = new ArrayList();
            RetPartsInf rtwk = new RetPartsInf();
            int ariflg = 0;

            foreach (RetPartsInf mf in RetInf)
            {
                if (mf != null)
                {
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 ADD
                    RetPartsInf currentInf = null;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 ADD
                    ariflg = 0;
                    foreach (RetPartsInf mf2 in alwk)
                    {
                        if (mf2 != null)
                        {
                            if ((mf.CatalogPartsMakerCd == mf2.CatalogPartsMakerCd) &&
                                (mf.ClgPrtsNoWithHyphen == mf2.ClgPrtsNoWithHyphen) &&
                                (mf.NewPrtsNoWithHyphen == mf2.NewPrtsNoWithHyphen) &&
                                // 2009/11/09 Add >>>
                                ( mf.PartsQty == mf2.PartsQty ) &&
                                ( mf.StandardName == mf2.StandardName ) &&
                                // 2009/11/09 Add <<<
                                (mf.PartsOpNm == mf2.PartsOpNm))
                            {
                                // 2009/11/09 >>>
                                //if (((mf.ModelPrtsAdptYm == mf2.ModelPrtsAdptYm) && (mf.ModelPrtsAblsYm == mf2.ModelPrtsAblsYm)) ||
                                //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/23 ADD
                                //    ((mf.ModelPrtsAdptYm <= mf2.ModelPrtsAdptYm) && (mf.ModelPrtsAblsYm >= mf2.ModelPrtsAblsYm)) ||
                                //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/23 ADD
                                //    ((mf.ModelPrtsAdptYm >= mf2.ModelPrtsAdptYm) && (mf.ModelPrtsAdptYm <= mf2.ModelPrtsAblsYm)) ||
                                //    ((mf.ModelPrtsAblsYm >= mf2.ModelPrtsAdptYm) && (mf.ModelPrtsAblsYm <= mf2.ModelPrtsAblsYm)))

                                if ((( ( mf.ModelPrtsAdptYm == mf2.ModelPrtsAdptYm ) && ( mf.ModelPrtsAblsYm == mf2.ModelPrtsAblsYm ) ) ||
                                     ( ( mf.ModelPrtsAdptYm <= mf2.ModelPrtsAdptYm ) && ( mf.ModelPrtsAblsYm >= mf2.ModelPrtsAblsYm ) ) ||
                                     ( ( mf.ModelPrtsAdptYm >= mf2.ModelPrtsAdptYm ) && ( mf.ModelPrtsAdptYm <= mf2.ModelPrtsAblsYm ) ) ||
                                     ( ( mf.ModelPrtsAblsYm >= mf2.ModelPrtsAdptYm ) && ( mf.ModelPrtsAblsYm <= mf2.ModelPrtsAblsYm ) )) &&
                                    (( ( mf.ModelPrtsAdptFrameNo <= mf2.ModelPrtsAdptFrameNo ) && ( mf.ModelPrtsAblsFrameNo >= mf2.ModelPrtsAblsFrameNo ) ) ||
                                       ( mf.ModelPrtsAdptFrameNo >= mf2.ModelPrtsAdptFrameNo ) && ( mf.ModelPrtsAblsFrameNo <= mf2.ModelPrtsAblsFrameNo ) ))
                               // 2009/11/09 <<<
                                {
                                    for (int lpcnt = 0; lpcnt < partsModelLnkWork.Count; lpcnt++)
                                    {
                                        if (partsModelLnkWork[lpcnt].PartsProperNo == mf2.PartsUniqueNo)
                                        {
                                            partsModelLnkWork[lpcnt].FullModelFixedNos.Add(mf.FullModelFixedNo);
                                            break;
                                        }
                                    }
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/23 ADD
                                    if ( (mf.ModelPrtsAdptYm <= mf2.ModelPrtsAdptYm) && (mf.ModelPrtsAblsYm >= mf2.ModelPrtsAblsYm) )
                                    {
                                        if ( mf.ModelPrtsAblsYm > mf2.ModelPrtsAblsYm )
                                            mf2.ModelPrtsAblsYm = mf.ModelPrtsAblsYm;
                                        if ( mf.ModelPrtsAdptYm < mf2.ModelPrtsAdptYm )
                                            mf2.ModelPrtsAdptYm = mf.ModelPrtsAdptYm;
                                    }
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/23 ADD
                                    if ((mf.ModelPrtsAdptYm >= mf2.ModelPrtsAdptYm) && (mf.ModelPrtsAdptYm <= mf2.ModelPrtsAblsYm))
                                    {
                                        if (mf.ModelPrtsAblsYm > mf2.ModelPrtsAblsYm)
                                            mf2.ModelPrtsAblsYm = mf.ModelPrtsAblsYm;
                                    }
                                    if ((mf.ModelPrtsAblsYm >= mf2.ModelPrtsAdptYm) && (mf.ModelPrtsAblsYm <= mf2.ModelPrtsAblsYm))
                                    {
                                        if (mf.ModelPrtsAdptYm < mf2.ModelPrtsAdptYm)
                                            mf2.ModelPrtsAdptYm = mf.ModelPrtsAdptYm;
                                    }

                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 ADD
                                    // ���i���̍X�V
                                    if ( (mf2.PartsPriceStDate < mf.PartsPriceStDate) &&
                                         (mf.PartsPriceStDate <= InPara.PriceDate) )
                                    {
                                        mf2.PartsPrice = mf.PartsPrice; // ���i���i
                                        mf2.PartsPriceStDate = mf.PartsPriceStDate; // ���i���i�J�n��
                                        mf2.OpenPriceDiv = mf.OpenPriceDiv; // �I�[�v�����i�敪
                                    }
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 ADD
                                    // 2009/10/23 Add >>>
                                    // �����i���̍X�V�i���[�J�[�R�[�h�L���D��
                                    if (mf2.SrchPNmAcqrCarMkrCd == 0 && mf2.SrchPNmAcqrCarMkrCd != mf.SrchPNmAcqrCarMkrCd)
                                    {
                                        mf2.SrchPNmAcqrCarMkrCd = mf.SrchPNmAcqrCarMkrCd;
                                        mf2.PartsName = mf.PartsName;
                                        mf2.PartsNameKana = mf.PartsNameKana;
                                    }
                                    // 2009/10/23 Add <<<

                                    // 2009/11/09 Add >>>
                                    if (( mf.ModelPrtsAdptFrameNo <= mf2.ModelPrtsAdptFrameNo ) && ( mf.ModelPrtsAblsFrameNo >= mf2.ModelPrtsAblsFrameNo ))
                                    {
                                        if (mf.ModelPrtsAdptFrameNo < mf2.ModelPrtsAdptFrameNo)
                                            mf2.ModelPrtsAdptFrameNo = mf.ModelPrtsAdptFrameNo;
                                        if (mf.ModelPrtsAblsFrameNo > mf2.ModelPrtsAblsFrameNo)
                                            mf2.ModelPrtsAblsFrameNo = mf.ModelPrtsAblsFrameNo;
                                    }
                                    // 2009/11/09 Add <<<
                                    ariflg = 1;

                                    break;
                                }
                            }
                        }
                    }
                    //�d�����Ă��Ȃ����alwk��Insert
                    if (ariflg == 0)
                    {
                        PartsModelLnkWork AddData = new PartsModelLnkWork();
                        AddData.FullModelFixedNos = new List<int>();
                        AddData.FullModelFixedNos.Add(mf.FullModelFixedNo);
                        AddData.PartsProperNo = mf.PartsUniqueNo;
                        partsModelLnkWork.Add(AddData);

                        alwk.Add(mf);

# if DEBUG
                        additionCnt++;
# endif

                        if (mf.ColorNarrowingFlag == 1)//���i�J���[�}�X�^�p
                        {
                            colorwk wk = new colorwk();
                            wk.FIGSHAPENORF = mf.FigShapeNo;
                            wk.FULLMODELFIXEDNORF = mf.FullModelFixedNo;
                            //wk.SHAPENOINSIDEROWNORF = mf.ShapeNoInsideRowNo;
                            wk.TBSPARTSCDDERIVEDNORF = mf.TbsPartsCdDerivedNo;
                            wk.TBSPARTSCODERF = mf.TbsPartsCode;
                            alcolorwk.Add(wk);
                        }
                        if (mf.TrimNarrowingFlag == 1)//���i�g�����}�X�^�p
                        {
                            trimwk wk = new trimwk();
                            wk.FIGSHAPENORF = mf.FigShapeNo;
                            wk.FULLMODELFIXEDNORF = mf.FullModelFixedNo;
                            //wk.SHAPENOINSIDEROWNORF = mf.ShapeNoInsideRowNo;
                            wk.TBSPARTSCDDERIVEDNORF = mf.TbsPartsCdDerivedNo;
                            wk.TBSPARTSCODERF = mf.TbsPartsCode;
                            altrimwk.Add(wk);
                        }
                        if (mf.EquipNarrowingFlag == 1)//���i�����}�X�^�p
                        {
                            equipwk wk = new equipwk();
                            wk.FIGSHAPENORF = mf.FigShapeNo;
                            wk.FULLMODELFIXEDNORF = mf.FullModelFixedNo;
                            //wk.SHAPENOINSIDEROWNORF = mf.ShapeNoInsideRowNo;
                            wk.TBSPARTSCDDERIVEDNORF = mf.TbsPartsCdDerivedNo;
                            wk.TBSPARTSCODERF = mf.TbsPartsCode;
                            alequipwk.Add(wk);
                        }
                    }
                }
            }
            //���k�ς�ArrayList��߂�
            RetInf = alwk;

# if DEBUG
            int aaa = additionCnt;
# endif
        }

        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
            if (string.IsNullOrEmpty(connectionText))
                return null;

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion

        #region [ �t�������� ]
        /// <summary>
        /// �D�ǂ��珃������
        /// </summary>
        /// <param name="makerCd">�D�ǃ��[�J�R�[�h</param>
        /// <param name="partsNo">�D�Ǖi��(�n�C�t���t)</param>
        /// <param name="RetInf">�������i���X�g</param>
        /// <returns></returns>
        public int GetGenuineParts(int makerCd, string partsNo, out object RetInf)
        {
            int status = 0;
            ArrayList ret = new ArrayList();
            RetInf = ret;
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null)
                {
                    return 99;
                }
                sqlConnection.Open();
                status = GetGenuinePartsProc(makerCd, partsNo, ref ret, sqlConnection);
            }
            catch
            {
                status = -1;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// �D�ǂ��珃������
        /// </summary>
        /// <param name="makerCd">�D�ǃ��[�J�R�[�h</param>
        /// <param name="partsNo">�D�Ǖi��(�n�C�t���t)</param>
        /// <param name="RetInf">�������i���X�g</param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int GetGenuinePartsProc(int makerCd, string partsNo, ref ArrayList RetInf, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            string selectstr = "SELECT "
                 + "JOINPARTSRF.JOINSOURCEMAKERCODERF, "
                 + "JOINPARTSRF.JOINSOURPARTSNOWITHHRF, "
                 + "PTMKRPRICERF.OFFERDATERF, "
                 + "PTMKRPRICERF.TBSPARTSCODERF, "
                 + "PTMKRPRICERF.TBSPARTSCDDERIVEDNORF, "
                 + "PTMKRPRICERF.OFFERDATERF AS PRICEOFFERDATE , "
                //+ "PTMKRPRICERF.MAKERCODERF, "
                //+ "PTMKRPRICERF.NEWPRTSNOWITHHYPHENRF, "
                 + "PTMKRPRICERF.MAKEROFFERPARTSNAMERF, "
                 + "PTMKRPRICERF.PARTSPRICERF, "
                 + "PTMKRPRICERF.PARTSLAYERCDRF, "
                 + "PTMKRPRICERF.PARTSPRICESTDATERF, "
                 + "PTMKRPRICERF.MAKEROFFERPARTSKANARF,"
                 + "PTMKRPRICERF.OPENPRICEDIVRF,"
                 + "SEARCHPRTNMRF.SEARCHPARTSFULLNAMERF, "
                 + "SEARCHPRTNMRF.SEARCHPARTSHALFNAMERF ";

            string fromstr = " FROM JOINPARTSRF ";
            // -- UPD 2010/06/14 ----------------------------------------->>>
            //fromstr += "LEFT OUTER JOIN PTMKRPRICERF ON PTMKRPRICERF.MAKERCODERF = JOINPARTSRF.JOINSOURCEMAKERCODERF ";
            fromstr += "LEFT OUTER JOIN PTMKRPRICEPMRF AS PTMKRPRICERF ON PTMKRPRICERF.MAKERCODERF = JOINPARTSRF.JOINSOURCEMAKERCODERF ";
            // -- UPD 2010/06/14 -----------------------------------------<<<
            fromstr += "AND PTMKRPRICERF.NEWPRTSNOWITHHYPHENRF = JOINPARTSRF.JOINSOURPARTSNOWITHHRF ";
            fromstr += "LEFT OUTER JOIN SEARCHPRTNMRF ON (PTMKRPRICERF.TBSPARTSCODERF = SEARCHPRTNMRF.TBSPARTSCODERF ";
            fromstr += "AND PTMKRPRICERF.MAKERCODERF = SEARCHPRTNMRF.CARMAKERCODERF) ";

            //string fromstr = " FROM PTMKRPRICERF ";
            //fromstr += "LEFT OUTER JOIN SEARCHPRTNMRF ON (PTMKRPRICERF.TBSPARTSCODERF = SEARCHPRTNMRF.TBSPARTSCODERF ";
            //fromstr += "AND PTMKRPRICERF.MAKERCODERF = SEARCHPRTNMRF.CARMAKERCODERF) ";
            //fromstr += "INNER JOIN JOINPARTSRF ON PTMKRPRICERF.MAKERCODERF = JOINPARTSRF.JOINSOURCEMAKERCODERF ";
            //fromstr += "AND PTMKRPRICERF.NEWPRTSNOWITHHYPHENRF = JOINPARTSRF.JOINSOURPARTSNOWITHHRF ";

            string wherestr = "WHERE JOINPARTSRF.JOINDESTMAKERCDRF = " + makerCd;
            wherestr += " AND JOINPARTSRF.JOINDESTPARTSNORF = '" + partsNo + "'";
            string strdum = selectstr + " " + fromstr + " " + wherestr;

            try
            {
                SqlCommand sqlCommand = new SqlCommand(strdum, sqlConnection);

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    RetPartsInf mf = new RetPartsInf();

                    mf.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    mf.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                    mf.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
                    mf.CatalogPartsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOINSOURCEMAKERCODERF"));
                    mf.PartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSFULLNAMERF"));
                    mf.PartsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSHALFNAMERF"));
                    mf.NewPrtsNoWithHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINSOURPARTSNOWITHHRF"));
                    mf.NewPrtsNoNoneHyphen = mf.NewPrtsNoWithHyphen.Replace("-", "");//SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NEWPRTSNONONEHYPHENRF"));
                    mf.MakerOfferPartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKEROFFERPARTSNAMERF"));
                    mf.PartsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PARTSPRICERF"));
                    mf.PartsLayerCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSLAYERCDRF"));
                    mf.PriceOfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICEOFFERDATE"));
                    mf.PartsPriceStDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PARTSPRICESTDATERF"));
                    mf.PartsNarrowingCode = PartsNarrowingCode;
                    mf.ClgPrtsNoWithHyphen = mf.NewPrtsNoWithHyphen;// SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NEWPRTSNOWITHHYPHENRF"));
                    mf.MakerOfferPartsKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKEROFFERPARTSKANARF"));
                    mf.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));

                    RetInf.Add(mf);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed)
                    myReader.Close();
            }
            return status;
        }
        #endregion

        #region [ �i�ԕ����������� ]
        /// <summary>
        /// �i�ԕ�����������
        /// </summary>
        /// <param name="lstSrchCond">�������X�g</param>
        /// <param name="lstRst">�������i��񃊃X�g</param>
        /// <param name="lstRstPrm">�D�Ǖ��i��񃊃X�g</param>
        /// <param name="lstPrmPrice">�D�ǉ��i���X�g</param>
        /// <returns></returns>
        public int GetOfrPartsInf(ArrayList lstSrchCond,
            out ArrayList lstRst,
            out ArrayList lstRstPrm,
            out ArrayList lstPrmPrice)
        {
            int status = 0;
            lstRst = new ArrayList();
            lstRstPrm = new ArrayList();
            lstPrmPrice = new ArrayList();
            SqlConnection sqlConnection = null;
            try
            {
                if (lstSrchCond == null || lstSrchCond.Count == 0)
                {
                    return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null)
                {
                    return 99;
                }
                sqlConnection.Open();
                status = GetGenuinePartsInfProc(lstSrchCond, lstRst, sqlConnection);
                status = GetPrimePartsInfProc(lstSrchCond, lstRstPrm, lstPrmPrice, sqlConnection);
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// �i�ԕ�����������[����]
        /// </summary>
        /// <param name="lstSrchCond">�������X�g</param>
        /// <param name="lstRst">�������i��񃊃X�g</param>
        /// <param name="sqlConnection">DB�R���l�N�V����</param>
        /// <returns></returns>
        private int GetGenuinePartsInfProc(ArrayList lstSrchCond, ArrayList lstRst, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            string selectstr = "SELECT ";
            string wherestr = string.Empty;
            selectstr += ctQryPartsNo;
            // -- UPD 2010/06/14 ---------------------->>>
            //selectstr += " FROM PTMKRPRICERF ";
            selectstr += " FROM PTMKRPRICEPMRF AS PTMKRPRICERF ";
            // -- UPD 2010/06/14 ----------------------<<<
            selectstr += "LEFT OUTER JOIN SEARCHPRTNMRF ON (PTMKRPRICERF.TBSPARTSCODERF = SEARCHPRTNMRF.TBSPARTSCODERF ";
            selectstr += "AND PTMKRPRICERF.MAKERCODERF = SEARCHPRTNMRF.CARMAKERCODERF) ";
            foreach (OfrPrtsSrchCndWork wk in lstSrchCond)
            {
                if ((wk.PrtsNo == string.Empty) || (wk.MakerCode == 0))
                {
                    continue;
                }

                wherestr += "OR ( PTMKRPRICERF.MAKERCODERF = " + wk.MakerCode + " AND ";
                wherestr += "PTMKRPRICERF.NEWPRTSNOWITHHYPHENRF = '" + wk.PrtsNo + "' ) ";
            }
            if (wherestr.Length == 0)
            {
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            selectstr += " WHERE" + wherestr.Substring(2); // �擪��OR����
            try
            {
                SqlCommand sqlCommand = new SqlCommand(selectstr, sqlConnection);
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    RetPartsInf mf = new RetPartsInf();
                    mf.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    mf.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                    mf.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
                    mf.CatalogPartsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));
                    mf.PartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSFULLNAMERF"));
                    mf.PartsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSHALFNAMERF"));
                    mf.NewPrtsNoWithHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NEWPRTSNOWITHHYPHENRF"));
                    mf.NewPrtsNoNoneHyphen = mf.NewPrtsNoWithHyphen.Replace("-", "");
                    mf.MakerOfferPartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKEROFFERPARTSNAMERF"));
                    mf.PartsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PARTSPRICERF"));
                    mf.PartsLayerCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSLAYERCDRF"));
                    mf.PriceOfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICEOFFERDATE"));
                    mf.PartsPriceStDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PARTSPRICESTDATERF"));
                    mf.PartsNarrowingCode = PartsNarrowingCode;
                    mf.ClgPrtsNoWithHyphen = mf.NewPrtsNoWithHyphen;
                    mf.MakerOfferPartsKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKEROFFERPARTSKANARF"));
                    mf.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));

                    lstRst.Add(mf);
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                myReader.Dispose();
            }
            return status;
        }

        /// <summary>
        /// �i�ԕ�����������[�D��]
        /// </summary>
        /// <param name="lstSrchCond">�������X�g</param>
        /// <param name="lstRstPrm">�D�Ǖ��i��񃊃X�g</param>
        /// <param name="lstPrmPrice">�D�ǉ��i���X�g</param>
        /// <param name="sqlConnection">DB�R���l�N�V����</param>
        /// <returns></returns>
        private int GetPrimePartsInfProc(ArrayList lstSrchCond, ArrayList lstRstPrm, ArrayList lstPrmPrice, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            string selectstr = "SELECT ";
            string wherestr = string.Empty;
            //[�񋟗D�Ǖi�Ԍ���]
            selectstr += "PRIMEPARTSRF.OFFERDATERF, ";
            selectstr += "PRIMEPARTSRF.GOODSMGROUPRF, ";
            selectstr += "PRIMEPARTSRF.TBSPARTSCODERF, ";
            selectstr += "PRIMEPARTSRF.TBSPARTSCDDERIVEDNORF, ";
            selectstr += "PRIMEPARTSRF.PRMSETDTLNO1RF, ";
            selectstr += "PRIMEPARTSRF.PARTSMAKERCDRF, ";
            selectstr += "PRIMEPARTSRF.PRIMEPARTSNOWITHHRF, ";
            selectstr += "PRIMEPARTSRF.PRIMEPARTSNONONEHRF, ";
            selectstr += "PRIMEPARTSRF.PRIMEPARTSNAMERF, ";
            selectstr += "PRIMEPARTSRF.PRIMEPARTSKANANMRF, ";
            selectstr += "PRIMEPARTSRF.PARTSLAYERCDRF, ";
            selectstr += "PRIMEPARTSRF.PRIMEPARTSSPECIALNOTERF, ";
            selectstr += "PRIMEPARTSRF.PARTSATTRIBUTERF, ";
            selectstr += "PRIMEPARTSRF.CATALOGDELETEFLAGRF, ";
            selectstr += "PRIMEPARTSRF.PRMPARTSILLUSTCRF, ";
            selectstr += "PRMPRTPRICERF.OFFERDATERF AS PRICEOFFERDATERF, ";
            selectstr += "PRMPRTPRICERF.PRMSETDTLNO1RF, "; // �Z���N�g�R�[�h
            selectstr += "PRMPRTPRICERF.PRICESTARTDATERF, ";
            selectstr += "PRMPRTPRICERF.NEWPRICERF, ";
            selectstr += "PRMPRTPRICERF.OPENPRICEDIVRF ";

            selectstr += " FROM PRIMEPARTSRF ";
            selectstr += " LEFT OUTER JOIN PRMPRTPRICERF ON PRIMEPARTSRF.PARTSMAKERCDRF = PRMPRTPRICERF.PARTSMAKERCDRF ";
            selectstr += " AND PRIMEPARTSRF.PRIMEPARTSNOWITHHRF = PRMPRTPRICERF.PRIMEPARTSNOWITHHRF ";
            foreach (OfrPrtsSrchCndWork wk in lstSrchCond)
            {
                if ((wk.PrtsNo == string.Empty) || (wk.MakerCode == 0))
                {
                    continue;
                }

                wherestr += "OR ( PRIMEPARTSRF.PARTSMAKERCDRF = " + wk.MakerCode + " AND ";
                wherestr += "PRIMEPARTSRF.PRIMEPARTSNOWITHHRF = '" + wk.PrtsNo + "' ) ";
            }
            if (wherestr.Length == 0)
            {
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            selectstr += " WHERE " + wherestr.Substring(2); // �擪��OR����
            try
            {
                SqlCommand sqlCommand = new SqlCommand(selectstr, sqlConnection);
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    // �D�Ǖ��i���
                    OfferJoinPartsRetWork mf = new OfferJoinPartsRetWork();
                    mf.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    mf.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                    mf.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                    mf.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
                    mf.JoinSourceMakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSMAKERCDRF"));
                    mf.JoinSourPartsNoWithH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNOWITHHRF"));
                    mf.JoinSourPartsNoNoneH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNONONEHRF"));
                    mf.JoinDestMakerCd = mf.JoinSourceMakerCode;
                    mf.JoinDestPartsNo = mf.JoinSourPartsNoWithH;
                    mf.PrimePartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNAMERF"));
                    mf.PrimePartsKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSKANANMRF"));
                    mf.PartsLayerCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSLAYERCDRF"));
                    mf.PrimePartsSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSSPECIALNOTERF"));
                    mf.PartsAttribute = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSATTRIBUTERF"));
                    mf.CatalogDeleteFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATALOGDELETEFLAGRF"));
                    mf.PrmPartsIllustC = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRMPARTSILLUSTCRF"));
                    lstRstPrm.Add(mf);

                    // �D�Ǖ��i���i���
                    OfferJoinPriceRetWork priceWork = new OfferJoinPriceRetWork();
                    priceWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICEOFFERDATERF"));
                    priceWork.PrmSetDtlNo1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMSETDTLNO1RF"));
                    priceWork.PartsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSMAKERCDRF"));
                    priceWork.PrimePartsNoWithH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNOWITHHRF"));
                    priceWork.PriceStartDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICESTARTDATERF"));
                    priceWork.NewPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("NEWPRICERF"));
                    priceWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
                    lstPrmPrice.Add(priceWork);
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                myReader.Dispose();
            }
            return status;
        }

        #endregion

        #region [ ���i�ꊇ�o�^�p���\�b�h ]
        /// <summary>
        /// ���i�ꊇ�o�^�p���\�b�h
        /// </summary>
        /// <param name="InPara">�p�����[�^</param>
        /// <param name="RetInf">���i���߂�</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2009.01.16</br>        
        public int SearchParts(PrtsSrchCndWork InPara, ref object RetInf)
        {
            int status;
            SqlConnection sqlConnection = null;
            CustomSerializeArrayList RetPartsCustomSerializeArrayList = new CustomSerializeArrayList();//���i���
            RetInf = RetPartsCustomSerializeArrayList;
            try
            {
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null)
                {
                    return 99;
                }
                sqlConnection.Open();

                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

                if (InPara.MakerCode < 100) // �������[�J�[�R�[�h��
                {
                    ArrayList lstRetInf = new ArrayList();
                    status = SearchPartsProc(InPara, lstRetInf, sqlConnection);

                    //======���ʂ�CustomSerializeArrayList�ɑ��
                    RetPartsCustomSerializeArrayList.Add(lstRetInf);           //���i���

                }
                else // �D�ǃ��[�J�[�R�[�h����
                {
                    ArrayList lstRstPrm = new ArrayList();
                    ArrayList lstPrmPrice = new ArrayList();
                    status = SearchPrimePartsProc(InPara, lstRstPrm, lstPrmPrice, sqlConnection);

                    //======���ʂ�CustomSerializeArrayList�ɑ��
                    RetPartsCustomSerializeArrayList.Add(lstRstPrm);           //���i���
                    RetPartsCustomSerializeArrayList.Add(lstPrmPrice);         //���i���
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// ���i�ꊇ�o�^�p����[����]
        /// </summary>
        /// <param name="InPara">�����p�����[�^</param>
        /// <param name="RetInf">���o�������i���R�[�h</param>
        /// <param name="sqlConnection">�R�l�N�V�����N���X</param>
        /// <returns></returns>
        private int SearchPartsProc(PrtsSrchCndWork InPara, ArrayList RetInf, SqlConnection sqlConnection)
        {
            SqlDataReader myReader = null;
            //���ʂ�ArrayList�ɂ�����Ə��N���X
            RetPartsInf mf = null;

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string selectstr = string.Empty;
            string fromstr = string.Empty;
            string wherestr = string.Empty;
            string queryCol = string.Empty;

            //�����t���O��`
            int BLorPrtsNoflg = 0;//0:�a�k�R�[�h�����@1:�i�ԞB������

            //====BL�������i�Ԍ������̔���
            if (InPara.PrtsNo != string.Empty)
            {
                if (InPara.PrtsNo.Contains("-"))
                {
                    queryCol = "NEWPRTSNOWITHHYPHENRF";
                }
                else
                {
                    queryCol = "NEWPRTSNONONEHYPHENRF";
                }
                BLorPrtsNoflg = 1;
            }
            else if (InPara.BLCode != 0)
            {
                BLorPrtsNoflg = 0;
            }
            else
            {
                return 99;//�p�����[�^�s��
            }

            try
            {
                selectstr = "SELECT ";
                if (BLorPrtsNoflg == 1 && InPara.MaxCnt > 0)
                {
                    selectstr += string.Format("TOP({0}) ", InPara.MaxCnt);
                }

                #region �i�Ԍ����N�G��
                selectstr += ctQryPartsNo;

                // -- UPD 2011/06/23 ----------------->>>
                //// -- UPD 2010/06/14 ----------------->>>
                ////fromstr = " FROM PTMKRPRICERF ";
                //fromstr = " FROM PTMKRPRICEPMRF AS PTMKRPRICERF";
                //// -- UPD 2010/06/14 -----------------<<<
                fromstr = " FROM PTMKRPRICEPMRF AS PTMKRPRICERF ";
                // -- UPD 2011/06/23 -----------------<<<
                fromstr += "LEFT OUTER JOIN SEARCHPRTNMRF ON (PTMKRPRICERF.TBSPARTSCODERF = SEARCHPRTNMRF.TBSPARTSCODERF ";
                fromstr += "AND PTMKRPRICERF.MAKERCODERF = SEARCHPRTNMRF.CARMAKERCODERF) ";

                #endregion

                SqlCommand sqlCommand = new SqlCommand();
                if (BLorPrtsNoflg == 0) // BL�����̏ꍇ
                {
                    wherestr = " WHERE PTMKRPRICERF.TBSPARTSCODERF = @TBSPARTSCODE ";

                    SqlParameter findBLCODE = sqlCommand.Parameters.Add("@TBSPARTSCODE", SqlDbType.Int);	//BL�R�[�h
                    findBLCODE.Value = SqlDataMediator.SqlSetInt32(InPara.BLCode);
                }
                else if (BLorPrtsNoflg == 1) // �i�Ԍ����̏ꍇ
                {
                    wherestr = " WHERE PTMKRPRICERF." + queryCol + " LIKE @CLGPRTSNOWITHHYPHEN ";

                    SqlParameter findCLGPRTSNOWITHHYPHEN = sqlCommand.Parameters.Add("@CLGPRTSNOWITHHYPHEN", SqlDbType.NVarChar);	//�i��
                    findCLGPRTSNOWITHHYPHEN.Value = SqlDataMediator.SqlSetString(InPara.PrtsNo + "%");
                }
                if (InPara.MakerCode != 0)
                {
                    wherestr += " AND PTMKRPRICERF.MAKERCODERF = @MAKERCODE";
                    ((SqlParameter)sqlCommand.Parameters.Add("@MAKERCODE", SqlDbType.Int)).Value = SqlDataMediator.SqlSetInt(InPara.MakerCode);
                }
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = selectstr + fromstr + wherestr;

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    mf = new RetPartsInf();

                    mf.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    mf.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                    mf.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
                    mf.CatalogPartsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));
                    mf.PartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSFULLNAMERF"));
                    mf.PartsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSHALFNAMERF"));
                    mf.NewPrtsNoWithHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NEWPRTSNOWITHHYPHENRF"));
                    mf.NewPrtsNoNoneHyphen = mf.NewPrtsNoWithHyphen.Replace("-", "");//SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NEWPRTSNONONEHYPHENRF"));
                    mf.MakerOfferPartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKEROFFERPARTSNAMERF"));
                    mf.PartsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PARTSPRICERF"));
                    mf.PartsLayerCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSLAYERCDRF"));
                    mf.PriceOfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICEOFFERDATE"));
                    mf.PartsPriceStDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PARTSPRICESTDATERF"));
                    //mf.PartsNarrowingCode = PartsNarrowingCode;
                    mf.ClgPrtsNoWithHyphen = mf.NewPrtsNoWithHyphen;// SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NEWPRTSNOWITHHYPHENRF"));
                    mf.MakerOfferPartsKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKEROFFERPARTSKANARF"));
                    mf.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));

                    RetInf.Add(mf);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                if (myReader != null && !myReader.IsClosed)
                    myReader.Close();
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed)
                    myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// ���i�ꊇ�o�^�p����[�D��]
        /// </summary>
        /// <param name="InPara">�����p�����[�^</param>
        /// <param name="lstRstPrm">�D�Ǖ��i��񃊃X�g</param>
        /// <param name="lstPrmPrice">�D�ǉ��i���X�g</param>
        /// <param name="sqlConnection">DB�R���l�N�V����</param>
        /// <returns></returns>
        private int SearchPrimePartsProc(PrtsSrchCndWork InPara, ArrayList lstRstPrm, ArrayList lstPrmPrice, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;

            string selectstr = string.Empty;
            string wherestr = string.Empty;
            string queryCol = string.Empty;

            //�����t���O��`
            int BLorPrtsNoflg = 0;//0:�a�k�R�[�h�����@1:�i�ԞB������

            //====BL�������i�Ԍ������̔���
            if (InPara.PrtsNo != string.Empty)
            {
                if (InPara.PrtsNo.Contains("-"))
                {
                    queryCol = "PRIMEPARTSNOWITHHRF";
                }
                else
                {
                    queryCol = "PRIMEPARTSNONONEHRF";
                }
                BLorPrtsNoflg = 1;
            }
            else if (InPara.BLCode != 0)
            {
                BLorPrtsNoflg = 0;
            }
            else
            {
                return 99;//�p�����[�^�s��
            }

            try
            {
                selectstr = "SELECT ";

                if (BLorPrtsNoflg == 1 && InPara.MaxCnt > 0)
                {
                    selectstr += string.Format("TOP({0}) ", InPara.MaxCnt);
                }
                //[�񋟗D�Ǖi�Ԍ���]
                selectstr += "PRIMEPARTSRF.OFFERDATERF, ";
                selectstr += "PRIMEPARTSRF.GOODSMGROUPRF, ";
                selectstr += "PRIMEPARTSRF.TBSPARTSCODERF, ";
                selectstr += "PRIMEPARTSRF.TBSPARTSCDDERIVEDNORF, ";
                selectstr += "PRIMEPARTSRF.PRMSETDTLNO1RF as PRIPRMSETDTLNO1RF, ";
                selectstr += "PRIMEPARTSRF.PARTSMAKERCDRF, ";
                selectstr += "PRIMEPARTSRF.PRIMEPARTSNOWITHHRF, ";
                selectstr += "PRIMEPARTSRF.PRIMEPARTSNONONEHRF, ";
                selectstr += "PRIMEPARTSRF.PRIMEPARTSNAMERF, ";
                selectstr += "PRIMEPARTSRF.PRIMEPARTSKANANMRF, ";
                selectstr += "PRIMEPARTSRF.PARTSLAYERCDRF, ";
                selectstr += "PRIMEPARTSRF.PRIMEPARTSSPECIALNOTERF, ";
                selectstr += "PRIMEPARTSRF.PARTSATTRIBUTERF, ";
                selectstr += "PRIMEPARTSRF.CATALOGDELETEFLAGRF, ";
                selectstr += "PRIMEPARTSRF.PRMPARTSILLUSTCRF, ";
                selectstr += "PRMPRTPRICERF.OFFERDATERF AS PRICEOFFERDATERF, ";
                selectstr += "PRMPRTPRICERF.PRMSETDTLNO1RF, "; // �Z���N�g�R�[�h
                selectstr += "PRMPRTPRICERF.PRICESTARTDATERF, ";
                selectstr += "PRMPRTPRICERF.NEWPRICERF, ";
                selectstr += "PRMPRTPRICERF.OPENPRICEDIVRF ";

                selectstr += " FROM PRIMEPARTSRF ";
                selectstr += " LEFT OUTER JOIN PRMPRTPRICERF ON PRIMEPARTSRF.PARTSMAKERCDRF = PRMPRTPRICERF.PARTSMAKERCDRF ";
                selectstr += " AND PRIMEPARTSRF.PRIMEPARTSNOWITHHRF = PRMPRTPRICERF.PRIMEPARTSNOWITHHRF ";

                SqlCommand sqlCommand = new SqlCommand();
                if (BLorPrtsNoflg == 0) // BL�����̏ꍇ
                {
                    wherestr = " WHERE PRIMEPARTSRF.TBSPARTSCODERF = @TBSPARTSCODE ";

                    SqlParameter findBLCODE = sqlCommand.Parameters.Add("@TBSPARTSCODE", SqlDbType.Int);	//BL�R�[�h
                    findBLCODE.Value = SqlDataMediator.SqlSetInt32(InPara.BLCode);
                }
                else if (BLorPrtsNoflg == 1) // �i�Ԍ����̏ꍇ
                {
                    wherestr = " WHERE PRIMEPARTSRF." + queryCol + " LIKE @CLGPRTSNOWITHHYPHEN ";

                    SqlParameter findCLGPRTSNOWITHHYPHEN = sqlCommand.Parameters.Add("@CLGPRTSNOWITHHYPHEN", SqlDbType.NVarChar);	//�i��
                    findCLGPRTSNOWITHHYPHEN.Value = SqlDataMediator.SqlSetString(InPara.PrtsNo + "%");
                }
                if (InPara.MakerCode != 0)
                {
                    wherestr += " AND PRIMEPARTSRF.PARTSMAKERCDRF = @MAKERCODE";
                    ((SqlParameter)sqlCommand.Parameters.Add("@MAKERCODE", SqlDbType.Int)).Value = SqlDataMediator.SqlSetInt(InPara.MakerCode);
                }

                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = selectstr + wherestr;
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    // �D�Ǖ��i���
                    OfferJoinPartsRetWork mf = new OfferJoinPartsRetWork();
                    mf.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    mf.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                    mf.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                    mf.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
                    mf.JoinSourceMakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSMAKERCDRF"));
                    mf.JoinSourPartsNoWithH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNOWITHHRF"));
                    mf.JoinSourPartsNoNoneH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNONONEHRF"));
                    mf.JoinDestMakerCd = mf.JoinSourceMakerCode;
                    mf.JoinDestPartsNo = mf.JoinSourPartsNoWithH;
                    mf.PrimePartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNAMERF"));
                    mf.PrimePartsKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSKANANMRF"));
                    mf.PartsLayerCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSLAYERCDRF"));
                    mf.PrimePartsSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSSPECIALNOTERF"));
                    mf.PartsAttribute = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSATTRIBUTERF"));
                    mf.CatalogDeleteFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATALOGDELETEFLAGRF"));
                    mf.PrmPartsIllustC = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRMPARTSILLUSTCRF"));

                    // ADD 2013/02/14 22013 �v��@�d�|�ꗗ�Ή� No.1742
                    // �Z���N�g�R�[�h�iPRMSETDTLNO1�j��]�L���Ă��Ȃ����߁A�N���C�A���g���Ńf�[�^���\������Ȃ�
                    mf.PrmSetDtlNo1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIPRMSETDTLNO1RF"));

                    lstRstPrm.Add(mf);

                    // �D�Ǖ��i���i���
                    OfferJoinPriceRetWork priceWork = new OfferJoinPriceRetWork();
                    priceWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICEOFFERDATERF"));
                    priceWork.PrmSetDtlNo1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMSETDTLNO1RF"));
                    priceWork.PartsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSMAKERCDRF"));
                    priceWork.PrimePartsNoWithH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNOWITHHRF"));
                    priceWork.PriceStartDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICESTARTDATERF"));
                    priceWork.NewPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("NEWPRICERF"));
                    priceWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
                    lstPrmPrice.Add(priceWork);
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                myReader.Dispose();
            }
            return status;
        }

        #endregion

        // --- ADD m.suzuki 2010/04/28 ---------->>>>>
        # region [ ���R�����p���\�b�h ]
        /// <summary>
        /// �i�ԕ�����������[����]�i�����R�����p�j
        /// </summary>
        /// <param name="inPara">���o����</param>
        /// <param name="lstRst">�������i��񃊃X�g</param>
        /// <param name="sqlConnection">DB�R���l�N�V����</param>
        /// <returns></returns>
        private int GetGenuinePartsInfForFreeSearch( GetPartsInfPara inPara, ArrayList lstRst, SqlConnection sqlConnection )
        {
            ArrayList lstSrchCond = inPara.SearchKeyList;

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            string selectstr = "SELECT ";
            string wherestr = string.Empty;
            selectstr += ctQryPartsNoForFreeSearch;

            // -- UPD 2010/06/14 ----------------->>>
            //selectstr += " FROM PTMKRPRICERF ";
            selectstr += " FROM PTMKRPRICEPMRF AS PTMKRPRICERF ";
            // -- UPD 2010/06/14 -----------------<<<
            //selectstr += "LEFT OUTER JOIN SEARCHPRTNMRF ON (PTMKRPRICERF.TBSPARTSCODERF = SEARCHPRTNMRF.TBSPARTSCODERF ";
            selectstr += "LEFT OUTER JOIN SEARCHPRTNMRF ON (@FINDTBSPARTSCODERF = SEARCHPRTNMRF.TBSPARTSCODERF ";
            //selectstr += "AND PTMKRPRICERF.MAKERCODERF = SEARCHPRTNMRF.CARMAKERCODERF) ";
            selectstr += "AND ( PTMKRPRICERF.MAKERCODERF = SEARCHPRTNMRF.CARMAKERCODERF OR SEARCHPRTNMRF.CARMAKERCODERF = 0 )) ";
            foreach ( OfrPrtsSrchCndWork wk in lstSrchCond )
            {
                if ( (wk.PrtsNo == string.Empty) || (wk.MakerCode == 0) )
                {
                    continue;
                }

                wherestr += "OR ( PTMKRPRICERF.MAKERCODERF = " + wk.MakerCode + " AND ";
                wherestr += "PTMKRPRICERF.NEWPRTSNOWITHHYPHENRF = '" + wk.PrtsNo + "' ) ";
            }
            if ( wherestr.Length == 0 )
            {
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            //selectstr += " WHERE" + wherestr.Substring( 2 ); // �擪��OR����
            wherestr = " ( " + wherestr.Substring( 2 ) + " ) "; // �擪��OR����
            wherestr += " AND PTMKRPRICERF.PARTSPRICESTDATERF <= @PRICEDATE ";
            selectstr += " WHERE" + wherestr;
            //selectstr += " ORDER BY SRCHPNMACQRCARMKRCD DESC";
            selectstr += " ORDER BY SRCHPNMACQRCARMKRCD DESC, PTMKRPRICERF.PARTSPRICESTDATERF DESC";
            try
            {
                SqlCommand sqlCommand = new SqlCommand( selectstr, sqlConnection );

                SqlParameter findTBSPARTSCODE = sqlCommand.Parameters.Add( "@FINDTBSPARTSCODERF", SqlDbType.Int );
                findTBSPARTSCODE.Value = SqlDataMediator.SqlSetInt( inPara.TbsPartsCode );
                SqlParameter findPRICEDATE = sqlCommand.Parameters.Add( "@PRICEDATE", SqlDbType.Int );
                findPRICEDATE.Value = SqlDataMediator.SqlSetInt( ToLongDate( inPara.PriceDate ) );

                myReader = sqlCommand.ExecuteReader();

                Dictionary<string, int> keyDic = new Dictionary<string, int>();

                while ( myReader.Read() )
                {
                    int srchPNmAcqrCarMkrCd = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SRCHPNMACQRCARMKRCD" ) );
                    int goodsMakerCd = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MAKERCODERF" ) );
                    string goodsNo = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "NEWPRTSNOWITHHYPHENRF" ) );

                    string key = CreateDicKeyForFreeSearch( goodsMakerCd, goodsNo );
                    if ( keyDic.ContainsKey( key ) )
                    {
                        continue;
                    }
                    keyDic.Add( key, srchPNmAcqrCarMkrCd );


                    RetPartsInf mf = new RetPartsInf();
                    mf.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD( myReader, myReader.GetOrdinal( "OFFERDATERF" ) );
                    mf.TbsPartsCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "TBSPARTSCODERF" ) );
                    mf.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "TBSPARTSCDDERIVEDNORF" ) );
                    mf.CatalogPartsMakerCd = goodsMakerCd;
                    mf.PartsName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SEARCHPARTSFULLNAMERF" ) );
                    mf.PartsNameKana = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SEARCHPARTSHALFNAMERF" ) );
                    mf.NewPrtsNoWithHyphen = goodsNo;
                    mf.NewPrtsNoNoneHyphen = mf.NewPrtsNoWithHyphen.Replace( "-", "" );
                    mf.MakerOfferPartsName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MAKEROFFERPARTSNAMERF" ) );
                    mf.PartsPrice = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "PARTSPRICERF" ) );
                    mf.PartsLayerCd = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "PARTSLAYERCDRF" ) );
                    mf.PriceOfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD( myReader, myReader.GetOrdinal( "PRICEOFFERDATE" ) );
                    mf.PartsPriceStDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD( myReader, myReader.GetOrdinal( "PARTSPRICESTDATERF" ) );
                    mf.PartsNarrowingCode = PartsNarrowingCode;
                    mf.ClgPrtsNoWithHyphen = mf.NewPrtsNoWithHyphen;
                    mf.MakerOfferPartsKana = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MAKEROFFERPARTSKANARF" ) );
                    mf.OpenPriceDiv = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "OPENPRICEDIVRF" ) );
                    mf.SrchPNmAcqrCarMkrCd = srchPNmAcqrCarMkrCd;

                    lstRst.Add( mf );
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                myReader.Dispose();
            }
            return status;
        }

        /// <summary>
        /// �d���`�F�b�N�L�[����
        /// </summary>
        /// <param name="goodsMakerCd"></param>
        /// <param name="goodsNo"></param>
        /// <returns></returns>
        private string CreateDicKeyForFreeSearch( int goodsMakerCd, string goodsNo )
        {
            return goodsMakerCd.ToString( "0000" ) + "," + goodsNo.Trim();
        }
        # endregion
        // --- ADD m.suzuki 2010/04/28 ----------<<<<<

        // -- ADD 2010/11/02 -------------------->>>>
        #region [�D�ǌ����A�g�}�X�^�̃`�F�b�N�p]
        /// <summary>
        /// �D�ǌ����A�g�}�X�^�̃`�F�b�N
        /// </summary>
        /// <param name="blCode"></param>
        /// <param name="sqlConnection"></param>
        /// <returns>True:�Y���L��AFalse:�Y������</returns>
        private bool PrmblCodeCheck(int blCode ,ref SqlConnection sqlConnection)
        {
            SqlDataReader myReader = null;
            string query = "";
            SqlCommand sqlCommand = null;
            bool flg = false;

            try
            {
                query = "SELECT TOP 1 TBSPARTSCODERF FROM PRIMEJOINLNKRF WHERE TBSPARTSCODERF=@TBSPARTSCODE";

                sqlCommand = new SqlCommand(query, sqlConnection);

                SqlParameter findTbsCode = sqlCommand.Parameters.Add("@TBSPARTSCODE", SqlDbType.Int);
                findTbsCode.Value = blCode;

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    //�Y���̂a�k�R�[�h����
                    flg = true;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                int status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed)
                    myReader.Close();
                if (sqlCommand != null)
                    sqlCommand.Dispose();
            }

            return flg;
        }
        #endregion
        // -- ADD 2010/11/02 --------------------<<<<

    }

    /// <summary>
    /// �I�t�@�[�p�����񓚕i�ڐݒ�f�[�^�N���X
    /// </summary>
    public class AutoAnsItemStForOffer
    {
        /// <summary>���_�R�[�h</summary>
        /// <remarks>00�͑S��</remarks>
        private string _sectionCode = "";

        /// <summary>���Ӑ�R�[�h</summary>
        /// <remarks>0�͑S���Ӑ�</remarks>
        private Int32 _customerCode;

        /// <summary>���i�����ރR�[�h</summary>
        private Int32 _goodsMGroup;

        /// <summary>BL���i�R�[�h</summary>
        private Int32 _bLGoodsCode;

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>�D�ǐݒ�ڍ׃R�[�h�Q</summary>
        /// <remarks>����ʃR�[�h</remarks>
        private Int32 _prmSetDtlNo2;

        /// <summary>�����񓚋敪</summary>
        /// <remarks>0:���Ȃ�,1:�[��,2:���i</remarks>
        private Int32 _autoAnswerDiv;

        /// <summary>�D�揇��</summary>
        private Int32 _priorityOrder;

        /// public propaty name  :  SectionCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// <value>00�͑S��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
        /// <value>0�͑S���Ӑ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  GoodsMGroup
        /// <summary>���i�����ރR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����ރR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMGroup
        {
            get { return _goodsMGroup; }
            set { _goodsMGroup = value; }
        }

        /// public propaty name  :  BLGoodsCode
        /// <summary>BL���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>���i���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  PrmSetDtlNo2
        /// <summary>�D�ǐݒ�ڍ׃R�[�h�Q�v���p�e�B</summary>
        /// <value>����ʃR�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�ǐݒ�ڍ׃R�[�h�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrmSetDtlNo2
        {
            get { return _prmSetDtlNo2; }
            set { _prmSetDtlNo2 = value; }
        }

        /// public propaty name  :  AutoAnswerDiv
        /// <summary>�����񓚋敪�v���p�e�B</summary>
        /// <value>0:���Ȃ�,1:�[��,2:���i</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����񓚋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AutoAnswerDiv
        {
            get { return _autoAnswerDiv; }
            set { _autoAnswerDiv = value; }
        }

        /// public propaty name  :  PriorityOrder
        /// <summary>�D�揇�ʃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�揇�ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PriorityOrder
        {
            get { return _priorityOrder; }
            set { _priorityOrder = value; }
        }

        /// <summary>
        /// �����񓚕i�ڐݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <returns>AutoAnsItemSt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AutoAnsItemSt�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public AutoAnsItemStForOffer()
        {
        }

        /// <summary>
        /// �����񓚕i�ڐݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="sectionCode">���_�R�[�h(00�͑S��)</param>
        /// <param name="customerCode">���Ӑ�R�[�h(0�͑S���Ӑ�)</param>
        /// <param name="goodsMGroup">���i�����ރR�[�h</param>
        /// <param name="bLGoodsCode">BL���i�R�[�h</param>
        /// <param name="goodsMakerCd">���i���[�J�[�R�[�h</param>
        /// <param name="prmSetDtlNo2">�D�ǐݒ�ڍ׃R�[�h�Q(����ʃR�[�h)</param>
        /// <param name="prmSetDtlName2">�D�ǐݒ�ڍז��̂Q</param>
        /// <param name="autoAnswerDiv">�����񓚋敪(0:���Ȃ�,1:�[��,2:���i)</param>
        /// <param name="priorityOrder">�D�揇��</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <param name="bLGoodsName">BL���i�R�[�h����</param>
        /// <returns>AutoAnsItemSt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AutoAnsItemSt�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public AutoAnsItemStForOffer(string sectionCode, Int32 customerCode, Int32 goodsMGroup, Int32 bLGoodsCode, Int32 goodsMakerCd, Int32 prmSetDtlNo2, Int32 autoAnswerDiv, Int32 priorityOrder)
        {
            this._sectionCode = sectionCode;
            this._customerCode = customerCode;
            this._goodsMGroup = goodsMGroup;
            this._bLGoodsCode = bLGoodsCode;
            this._goodsMakerCd = goodsMakerCd;
            this._prmSetDtlNo2 = prmSetDtlNo2;
            this._autoAnswerDiv = autoAnswerDiv;
            this._priorityOrder = priorityOrder;
        }

        /// <summary>
        /// �����񓚕i�ڐݒ�}�X�^��������
        /// </summary>
        /// <returns>AutoAnsItemSt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����AutoAnsItemSt�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public AutoAnsItemStForOffer Clone()
        {
            return new AutoAnsItemStForOffer(this._sectionCode, this._customerCode, this._goodsMGroup, this._bLGoodsCode, this._goodsMakerCd, this._prmSetDtlNo2, this._autoAnswerDiv, this._priorityOrder);
        }

        /// <summary>
        /// �����񓚕i�ڐݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�AutoAnsItemSt�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AutoAnsItemSt�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(AutoAnsItemStForOffer target)
        {
            return ((this.SectionCode == target.SectionCode)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.GoodsMGroup == target.GoodsMGroup)
                 && (this.BLGoodsCode == target.BLGoodsCode)
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.PrmSetDtlNo2 == target.PrmSetDtlNo2)
                 && (this.AutoAnswerDiv == target.AutoAnswerDiv)
                 && (this.PriorityOrder == target.PriorityOrder));
        }

        /// <summary>
        /// �����񓚕i�ڐݒ�}�X�^��r����
        /// </summary>
        /// <param name="autoAnsItemSt1">
        ///                    ��r����AutoAnsItemSt�N���X�̃C���X�^���X
        /// </param>
        /// <param name="autoAnsItemSt2">��r����AutoAnsItemSt�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AutoAnsItemSt�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(AutoAnsItemStForOffer autoAnsItemSt1, AutoAnsItemStForOffer autoAnsItemSt2)
        {
            return ((autoAnsItemSt1.SectionCode == autoAnsItemSt2.SectionCode)
                 && (autoAnsItemSt1.CustomerCode == autoAnsItemSt2.CustomerCode)
                 && (autoAnsItemSt1.GoodsMGroup == autoAnsItemSt2.GoodsMGroup)
                 && (autoAnsItemSt1.BLGoodsCode == autoAnsItemSt2.BLGoodsCode)
                 && (autoAnsItemSt1.GoodsMakerCd == autoAnsItemSt2.GoodsMakerCd)
                 && (autoAnsItemSt1.PrmSetDtlNo2 == autoAnsItemSt2.PrmSetDtlNo2)
                 && (autoAnsItemSt1.AutoAnswerDiv == autoAnsItemSt2.AutoAnswerDiv)
                 && (autoAnsItemSt1.PriorityOrder == autoAnsItemSt2.PriorityOrder)
                 );
        }
        /// <summary>
        /// �����񓚕i�ڐݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�AutoAnsItemSt�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AutoAnsItemSt�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(AutoAnsItemStForOffer target)
        {
            ArrayList resList = new ArrayList();
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.GoodsMGroup != target.GoodsMGroup) resList.Add("GoodsMGroup");
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.PrmSetDtlNo2 != target.PrmSetDtlNo2) resList.Add("PrmSetDtlNo2");
            if (this.AutoAnswerDiv != target.AutoAnswerDiv) resList.Add("AutoAnswerDiv");
            if (this.PriorityOrder != target.PriorityOrder) resList.Add("PriorityOrder");

            return resList;
        }

        /// <summary>
        /// �����񓚕i�ڐݒ�}�X�^��r����
        /// </summary>
        /// <param name="autoAnsItemSt1">��r����AutoAnsItemSt�N���X�̃C���X�^���X</param>
        /// <param name="autoAnsItemSt2">��r����AutoAnsItemSt�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AutoAnsItemSt�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(AutoAnsItemStForOffer autoAnsItemSt1, AutoAnsItemStForOffer autoAnsItemSt2)
        {
            ArrayList resList = new ArrayList();
            if (autoAnsItemSt1.SectionCode != autoAnsItemSt2.SectionCode) resList.Add("SectionCode");
            if (autoAnsItemSt1.CustomerCode != autoAnsItemSt2.CustomerCode) resList.Add("CustomerCode");
            if (autoAnsItemSt1.GoodsMGroup != autoAnsItemSt2.GoodsMGroup) resList.Add("GoodsMGroup");
            if (autoAnsItemSt1.BLGoodsCode != autoAnsItemSt2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (autoAnsItemSt1.GoodsMakerCd != autoAnsItemSt2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (autoAnsItemSt1.PrmSetDtlNo2 != autoAnsItemSt2.PrmSetDtlNo2) resList.Add("PrmSetDtlNo2");
            if (autoAnsItemSt1.AutoAnswerDiv != autoAnsItemSt2.AutoAnswerDiv) resList.Add("AutoAnswerDiv");
            if (autoAnsItemSt1.PriorityOrder != autoAnsItemSt2.PriorityOrder) resList.Add("PriorityOrder");

            return resList;
        }
    }
}
