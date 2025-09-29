using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���[�U�[���i����DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���[�U�[���i�����̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.05.05</br>
    /// <br></br>
    /// <br>Update Note: 2009.02.19 20056 ���n ��� MAX�����w��\Search���\�b�h�ǉ�</br>
    /// <br>Update Note: 2009.02.24 20056 ���n ��� �������i���擾�����ǉ�</br>
    /// <br>Update Note: 2009.04.09 20056 ���n ��� �d������擾�����ǉ�</br>
    /// <br>Update Note: 2009/09/04 20056 ���n ��� MANTIS[0012224] LogicalMode�w���Search���\�b�h�ǉ�</br>
    /// <br>Update Note: 2011/01/27 22018 ��� ���b ��ւ���ꍇ�͌��������Ȃ��ł������I��UI���\�������̂Œ��o���s��</br>
    /// <br>Update Note: 2011/03/17 22008 ���� ���n ���[�U�[���i�������ɍ݌ɂ̎擾���s��Ȃ����\�b�h��ǉ�</br>
    /// <br>Update Note: 2011/11/29 30517 �Ė� �x�� ���i�݌Ɉꊇ�o�^�C���������̃^�C���A�E�g���Ԃ�60�b�ɉ���</br>
    /// <br>Update Note: 2012/05/22 zhangy3 </br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 2012/06/27�z�M��</br>
    /// <br>             Redmine#29871 ����`�[���́@�u*�v���g�p�����i�Ԍ����̌��ʂ�����قȂ�</br>
    /// <br>Update Note: 2012/09/04 YANGMJ </br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 </br>
    /// <br>             Redmine#32095 ����`�[���́@���i�݌Ɉꊇ�o�^�C���������G���[�̏C��</br>
    /// <br>Update Note: 2012/12/01 zhangy3 </br>
    /// <br>�Ǘ��ԍ�   : 2013/01/16�z�M��</br>
    /// <br>             Redmine#33231 ���i�݌Ƀ}�X�^�̎d�l�ύX</br>
    /// <br>Update Note: 2013/01/24 gezh </br>
    /// <br>             Redmine#33361 ���i�݌Ɉꊇ�o�^�C���̃T�[�o�[���׌y���̏C��</br>
    /// <br>Update Note: 2013/02/08 �c����</br>
    /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/26�z�M��</br>
    /// <br>           : Redmine#34640 ���i�݌Ƀ}�X�^�̎d�l�ύX(#33231�̎c����)</br>
    /// <br>Update Note: 2013/03/27 huangt</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 2013/05/15�z�M��</br>
    /// <br>           : Redmine#35019 �i�Ԍ����̌����i�̌����̃��X�|���X�ቺ�΍�i��1833�j</br>
    /// <br>Update Note: K2013/03/18 �c����</br>
    /// <br>�Ǘ��ԍ�   : 10806793-00 2013/04/10�z�M��</br>
    /// <br>           : Redmine#35071 ���i�݌Ƀ}�X�^�E�R�`���i�l�ʑg�ݍ��݁i#34640�c���j</br>
    /// <br>Update Note: 2013/03/18 yangyi</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 20150515�z�M���̑Ή�</br>
    /// <br>           : Redmine#34962 �@�u���i�݌Ɉꊇ�C���v�̃T�[�o�[���׌y���Ή�</br>
    /// <br>Update Note: 2013/04/23 yangyi</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 20150515�z�M���̑Ή�</br>
    /// <br>           : Redmine#35018 �@�u���i�݌Ɉꊇ�C���v�̃T�[�o�[���׌y���Ή�</br>
    /// <br>Update Note: 2013/04/25 yangyi</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 20150515�z�M���̑Ή�</br>
    /// <br>           : Redmine#35018 �@�u���i�݌Ɉꊇ�C���v�̃T�[�o�[���׌y���Ή�</br>
    /// <br>Update Note: 2013/04/27 yangyi</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 20150515�z�M���̑Ή�</br>
    /// <br>           : Redmine#35018 �@�u���i�݌Ɉꊇ�C���v�̃T�[�o�[���׌y���@���̂Q</br>
    /// <br>Update Note: K2013/07/23 ������</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00</br>
    /// <br>           : Redmine#38624 �@���i�݌Ɉꊇ�C���̑Ή��i��34962�̃f�O���j</br>
    /// <br>Update Note: 2013/08/13 �c����</br>
    /// <br>�Ǘ��ԍ�   : 10902175-00</br>
    /// <br>             Redmine#39794 ���i�݌Ƀ}�X�^�U�̑��x���P</br>
    /// <br>Update Note: K2013/10/08 gezh</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00</br>
    /// <br>           : Redmine#38624 �@���i�݌Ɉꊇ�C���̏�Q��17�Ή�</br>
    /// <br>Update Note: 2014/01/15 huangt</br>
    /// <br>�Ǘ��ԍ�   : 10904597-00</br>
    /// <br>           : Redmine#40998 �ݏo���̕ύX���\�ɂ���悤�ɏC��</br>
    /// <br>Update Note: 2014/02/06 ���� ����q</br>
    /// <br>�Ǘ��ԍ�   : </br>
    /// <br>           : SCM�d�|�ꗗ��10632�Ή�</br>
    /// <br>Update Note: 2014/02/10 ���z</br>
    /// <br>�Ǘ��ԍ�   : 10970685-00</br>
    /// <br>           : Redmine#41976 ���i�}�X�^�U�̒ǉ�</br>
    /// <br>Update Note: 2015/08/17 �c����</br>
    /// <br>�Ǘ��ԍ�   : 11170052-00</br>
    /// <br>           : Redmine#47036 ���i�݌Ɉꊇ�o�^�C�� �Ǘ����_�E�q�ɂ̒ǉ�</br>
    /// <br>Update Note: 2020/06/18 杍^</br>
    /// <br>�Ǘ��ԍ�   : 11670219-00</br>
    /// <br>           : PMKOBETSU-4005 �d�a�d�΍�</br>
    /// </remarks>
    [Serializable]
    public class UsrJoinPartsSearchDB : RemoteWithAppLockDB, IUsrJoinPartsSearchDB
    {
        #region [ ������ ]
        # region --- �o�t�a�k�h�b��` ---

        # region --- �R���X�g���N�^ ---
        /// <summary>
        ///�@���[�U�[���i����DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : 96186�@���ԁ@�T��</br>
        /// <br>Date       : 2007.03.05</br>
        /// </remarks>
        public UsrJoinPartsSearchDB()
            :
            base("PMKEN06064D", "Broadleaf.Application.Remoting.UsrJoinPartsSearchDB", "JOINPARTSURF")
        {
        }
        # endregion

        # region --- ���[�U�[���i���� DB�����[�g�I�u�W�F�N�g ---

        // 2009/09/04 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> DEL
        ///// <summary>
        /////���[�U�[���i����DB�����[�g�I�u�W�F�N�g
        ///// </summary>
        ///// <param name="retObj"></param>
        ///// <param name="searchFlg">�����t���O</param>
        ///// <param name="searchType"></param>
        ///// <param name="searchCond">��������</param>        
        ///// <returns>DB Status</returns>
        //public int UserGoodsJoinSearch(out object retObj, UsrSearchFlg searchFlg, int searchType, object searchCond)
        //{
        //    //���o�̓p�����[�^�[�ݒ�
        //    SqlConnection sqlConnection = null;
        //    retObj = null;
        //    try
        //    {
        //        //�r�p�k��������
        //        sqlConnection = CreateSqlConnection();
        //        if (sqlConnection == null) return 99;
        //        sqlConnection.Open();
        //        //--------------------------------

        //        return UserGoodsJoinSearchProc(out retObj, searchFlg, searchType, searchCond, sqlConnection);
        //    }
        //    catch (SqlException ex)
        //    {
        //        return base.WriteSQLErrorLog(ex, "UsrJoinPartsSearchDB.Search�ɂ�SQL�G���[���� Msg=" + ex.Message, 0);
        //    }
        //    catch (Exception ex)
        //    {
        //        base.WriteErrorLog(ex, "UsrJoinPartsSearchDB.Search Exception = " + ex.Message);
        //        return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
        //    }
        //    finally
        //    {
        //        if (sqlConnection != null)
        //        {
        //            sqlConnection.Dispose();
        //        }
        //    }
        //}
        // 2009/09/04 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< DEL

        // 2009/09/04 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> ADD
        /// <summary>
        ///���[�U�[���i����DB�����[�g�I�u�W�F�N�g
        /// </summary>
        /// <param name="retObj"></param>
        /// <param name="searchFlg">�����t���O</param>
        /// <param name="searchType"></param>
        /// <param name="searchCond">��������</param>        
        /// <returns>DB Status</returns>
        public int UserGoodsJoinSearch(out object retObj, UsrSearchFlg searchFlg, int searchType, object searchCond)
        {
            return this.UserGoodsJoinSearch(out retObj, searchFlg, searchType, ConstantManagement.LogicalMode.GetData0, searchCond);
        }

        /// <summary>
        /// ���[�U�[���i����DB�����[�g�I�u�W�F�N�g
        /// </summary>
        /// <param name="retObj"></param>
        /// <param name="searchFlg"></param>
        /// <param name="searchType"></param>
        /// <param name="logicalMode"></param>
        /// <param name="searchCond"></param>
        /// <returns></returns>
        public int UserGoodsJoinSearch(out object retObj, UsrSearchFlg searchFlg, int searchType, ConstantManagement.LogicalMode logicalMode, object searchCond)
        {
            //���o�̓p�����[�^�[�ݒ�
            SqlConnection sqlConnection = null;
            retObj = null;
            try
            {
                //�r�p�k��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return 99;
                sqlConnection.Open();
                //--------------------------------

                return UserGoodsJoinSearchProc(out retObj, searchFlg, searchType, logicalMode, searchCond, sqlConnection);
            }
            catch (SqlException ex)
            {
                return base.WriteSQLErrorLog(ex, "UsrJoinPartsSearchDB.Search�ɂ�SQL�G���[���� Msg=" + ex.Message, 0);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UsrJoinPartsSearchDB.Search Exception = " + ex.Message);
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                }
            }
        }
        // 2009/09/04 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< ADD


        #region ���[�U�[���i����DB�����[�g�I�u�W�F�N�g
        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� ------------------------------------------------->>>>>
        /// <summary>
        /// ���[�U�[���i����DB�����[�g�I�u�W�F�N�g
        /// </summary>
        /// <param name="retObj"></param>
        /// <param name="listSearchFlg"></param>
        /// <param name="listSearchType"></param>
        /// <param name="logicalMode"></param>
        /// <param name=listSearchCond"></param>
        /// <returns>�X�e�[�^�X</returns>
        public int UserGoodsJoinSearch(out ArrayList retObj, ArrayList listSearchFlg, ArrayList listSearchType, ConstantManagement.LogicalMode logicalMode, ArrayList listSearchCond)
        {
            //���o�̓p�����[�^�[�ݒ�
            SqlConnection sqlConnection = null;
            retObj = new ArrayList();

            List<UsrSearchFlg> searchFlgList = new List<UsrSearchFlg>();
            List<int> searchTypeList = new List<int>();
            List<object> searchCondList = new List<object>();

            try
            {
                // List�̌�������v���Ȃ���΃G���[
                if ((searchFlgList.Count == searchTypeList.Count) && 
                    (searchFlgList.Count == searchCondList.Count))
                {
                    //�r�p�k��������
                    sqlConnection = CreateSqlConnection();
                    if (sqlConnection == null) return 99;
                    sqlConnection.Open();
                    //--------------------------------

                    UsrSearchFlg searchFlg;
                    int searchType;
                    object searchCond;
                    object retObjTemp;

                    for (int i = 0; i < listSearchFlg.Count; i++)
                    {
                        searchFlg = (UsrSearchFlg)listSearchFlg[i];
                        searchType = (int)listSearchType[i];
                        searchCond = (object)listSearchCond[i];
                        int status = UserGoodsJoinSearchProcForAutoSearch(out retObjTemp, searchFlg, searchType, logicalMode, searchCond, sqlConnection);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            if (retObjTemp != null)
                            {
                                retObj.Add(retObjTemp);
                            }
                        }
                    }
                }
                return 0;
            }
            catch (SqlException ex)
            {
                return base.WriteSQLErrorLog(ex, "UsrJoinPartsSearchDB.Search�ɂ�SQL�G���[���� Msg=" + ex.Message, 0);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UsrJoinPartsSearchDB.Search Exception = " + ex.Message);
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }
        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� -------------------------------------------------<<<<<
        #endregion


        //private int UserGoodsJoinSearchProc(out object retObj, UsrSearchFlg searchFlg, int searchType, object searchCond, SqlConnection sqlConnection) // 2009/09/04 DEL
        private int UserGoodsJoinSearchProc(out object retObj, UsrSearchFlg searchFlg, int searchType, ConstantManagement.LogicalMode logicalMode, object searchCond, SqlConnection sqlConnection) // 2009/09/04 ADD
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            //���o�̓p�����[�^�[�ݒ�
            CustomSerializeArrayList retList = new CustomSerializeArrayList();
            retObj = null;
            try
            {
                string enterpriseCd = string.Empty;
                ArrayList _usrPartsSubstRetWork = null;	        //���[�U�[��փ}�X�^���X�g
                ArrayList _usrJoinPartsRetWork = null;	        //���[�U�[�����}�X�^���X�g
                ArrayList _usrGoodsRetWork = new ArrayList();	//���[�U�[���i�}�X�^���X�g
                ArrayList _usrSetPartsRetWork = null;           //���[�U�[�Z�b�g�}�X�^���X�g

                ArrayList inParts = new ArrayList();            // ���i���X�g(���[�U�[DB�̏��i�}�X�^����擾���鏤�i���̂�)

                ArrayList lstUsrDBSearch = new ArrayList();                // ���[�U�[DB�����p���X�g

                ArrayList outSubst = null;                      // ���[�U�[��֌������ʃ��X�g
                ArrayList outJoinSubst = null;                  // ���[�U�[������֌������ʃ��X�g
                ArrayList outSetSubst = null;                   // ���[�U�[�Z�b�g��֌������ʃ��X�g

                ArrayList searchCondList = searchCond as ArrayList;

                ArrayList usrGoodsRetWorkOfr;                   // ���[�U�[���i���X�g[ �񋟕��������ʃ��X�g ]
                ArrayList usrGoodsRetWorkUsr;                   // ���[�U�[���i���X�g[ ���[�U�[���������ʃ��X�g ]
                if (searchCondList != null && searchCondList.Count > 0)
                {
                    enterpriseCd = ((UsrPartsNoSearchCondWork)searchCondList[0]).EnterpriseCode;

                    UsrPartsNoSearchCondWork cond = searchCondList[0] as UsrPartsNoSearchCondWork;

                    //���i��������
                    //status = SearchUsrGoods(cond, searchType, out usrGoodsRetWorkOfr, sqlConnection); // 2009/09/04 DEL
                    status = SearchUsrGoods(cond, searchType, logicalMode, out usrGoodsRetWorkOfr, sqlConnection); // 2009/09/04 ADD
                    searchCondList.RemoveAt(0); // �擪�̌��������폜

                    lstUsrDBSearch.AddRange(searchCondList);
                    inParts.AddRange(searchCondList);

                    foreach (UsrGoodsRetWork wk in usrGoodsRetWorkOfr)
                    {
                        UsrPartsNoSearchCondWork ipa = new UsrPartsNoSearchCondWork();
                        ipa.EnterpriseCode = enterpriseCd;
                        ipa.MakerCode = wk.GoodsMakerCd;
                        ipa.PrtsNo = wk.GoodsNo;

                        lstUsrDBSearch.Add(ipa);
                    }
                    _usrGoodsRetWork.AddRange(usrGoodsRetWorkOfr);
                }
                else
                {
                    #region [ �������������X�g�łȂ��A�f�[�^�N���X�̏ꍇ - ���ݕs�v(�\���@�\) ]
                    UsrPartsNoSearchCondWork cond = searchCond as UsrPartsNoSearchCondWork;
                    if (cond != null)
                    {
                        enterpriseCd = cond.EnterpriseCode;
                        lstUsrDBSearch.Add(cond);
                        if (searchFlg == UsrSearchFlg.UsrPartsAndAll || searchFlg == UsrSearchFlg.UsrPartsAndSet)
                        {
                            inParts.Add(cond);
                        }

                        //���i��������
                        //status = SearchUsrGoods(cond, searchType, out usrGoodsRetWorkOfr, sqlConnection); //2009/09/04 DEL
                        status = SearchUsrGoods(cond, searchType, logicalMode, out usrGoodsRetWorkOfr, sqlConnection); // 2009/09/04 ADD
                        foreach (UsrGoodsRetWork wk in _usrSetPartsRetWork)
                        {
                            UsrPartsNoSearchCondWork ipa = new UsrPartsNoSearchCondWork();
                            ipa.EnterpriseCode = enterpriseCd;
                            ipa.MakerCode = wk.GoodsMakerCd;
                            ipa.PrtsNo = wk.GoodsNo;
                            inParts.Add(ipa);
                        }
                        _usrGoodsRetWork.AddRange(usrGoodsRetWorkOfr);
                    }
                    else
                    {
                        return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                    }
                    #endregion
                }

                // --- ADD m.suzuki 2011/01/27 ---------->>>>>
                ArrayList lstJoinSearch = new ArrayList();
                // --- UPD m.suzuki 2011/01/27 ----------<<<<<

                //if (searchFlg == UsrSearchFlg.UsrPartsAndAll)
                if (searchFlg >= UsrSearchFlg.UsrPartsAndSet)
                {
                    #region [ [�@a]�����i�ԁ���֌������� ]
                    //status = UsrPartsSubstMain(inSubst, out outSubst, sqlConnection);
                    status = UsrPartsSubstMain(lstUsrDBSearch, out outSubst, sqlConnection);
                    if (status != 0)
                    {
                        return status;
                    }
                    //--------------------------------

                    foreach (UsrPartsSubstRetWork wk in outSubst)
                    {
                        UsrPartsNoSearchCondWork ipa = new UsrPartsNoSearchCondWork();
                        ipa.EnterpriseCode = enterpriseCd;
                        ipa.MakerCode = wk.SubstDestMakerCd;
                        ipa.PrtsNo = wk.SubstDestPartsNo;

                        // --- ADD m.suzuki 2011/01/27 ---------->>>>>
                        lstJoinSearch.Add( ipa );
                        // --- ADD m.suzuki 2011/01/27 ----------<<<<<
                        lstUsrDBSearch.Add( ipa );
                        inParts.Add(ipa);
                    }
                    #endregion
                }
                if (searchFlg == UsrSearchFlg.UsrPartsAndAll || searchFlg == UsrSearchFlg.UsrPartsJoinSet)
                {
                    //[�A]���[�U�[�������������i�������i�A�D�Ǖ��i�ɑ΂�������������j
                    status = UsrJoinPartsSearch(lstUsrDBSearch, out _usrJoinPartsRetWork, sqlConnection);
                    if (status != 0)
                    {
                        return status;
                    }
                    //--------------------------------

                    ArrayList inJoinSubst = new ArrayList();
                    foreach (UsrJoinPartsRetWork wk in _usrJoinPartsRetWork)
                    {
                        UsrPartsNoSearchCondWork ipa = new UsrPartsNoSearchCondWork();
                        ipa.EnterpriseCode = enterpriseCd;
                        ipa.MakerCode = wk.JoinDestMakerCd;
                        ipa.PrtsNo = wk.JoinDestPartsNo;

                        inJoinSubst.Add(ipa);
                    }
                    lstUsrDBSearch.AddRange(inJoinSubst);
                    inParts.AddRange(inJoinSubst);

                    //if (searchFlg == UsrSearchFlg.UsrPartsAndAll)
                    if (searchFlg >= UsrSearchFlg.UsrPartsAndSet)
                    {
                        //[�@b]�����i�ԁ���֌�������
                        status = UsrPartsSubstMain(inJoinSubst, out outJoinSubst, sqlConnection);
                        if (status != 0)
                        {
                            return status;
                        }
                        foreach (UsrPartsSubstRetWork wk in outJoinSubst)
                        {
                            UsrPartsNoSearchCondWork ipa = new UsrPartsNoSearchCondWork();
                            ipa.EnterpriseCode = enterpriseCd;
                            ipa.MakerCode = wk.SubstDestMakerCd;
                            ipa.PrtsNo = wk.SubstDestPartsNo;

                            lstUsrDBSearch.Add(ipa); // TODO : ���[�U�[�o�^���̌�����ւɑ΂��ăZ�b�g�������������H
                            inParts.Add(ipa);
                        }
                    }

                } // searchFlg��1�̂Ƃ��̂ݏ�L�u���b�N�����s
                //--------------------------------
                // --- ADD m.suzuki 2011/01/27 ---------->>>>>
                else if ( searchFlg == UsrSearchFlg.UsrPartsAndSet )
                {
                    # region [��ւ݂̂̏ꍇ�������I����\������̂ő�֐�ɑ΂��錋����̂ݒ��o]
                    //[�A]���[�U�[�������������i�������i�A�D�Ǖ��i�ɑ΂�������������j
                    status = UsrJoinPartsSearch( lstJoinSearch, out _usrJoinPartsRetWork, sqlConnection );
                    if ( status != 0 )
                    {
                        return status;
                    }

                    ArrayList inJoinSubst = new ArrayList();
                    foreach ( UsrJoinPartsRetWork wk in _usrJoinPartsRetWork )
                    {
                        UsrPartsNoSearchCondWork ipa = new UsrPartsNoSearchCondWork();
                        ipa.EnterpriseCode = enterpriseCd;
                        ipa.MakerCode = wk.JoinDestMakerCd;
                        ipa.PrtsNo = wk.JoinDestPartsNo;

                        inJoinSubst.Add( ipa );
                    }
                    lstUsrDBSearch.AddRange( inJoinSubst );
                    inParts.AddRange( inJoinSubst );

                    //[�@b]�����i�ԁ���֌�������
                    status = UsrPartsSubstMain( inJoinSubst, out outJoinSubst, sqlConnection );
                    if ( status != 0 )
                    {
                        return status;
                    }
                    foreach ( UsrPartsSubstRetWork wk in outJoinSubst )
                    {
                        UsrPartsNoSearchCondWork ipa = new UsrPartsNoSearchCondWork();
                        ipa.EnterpriseCode = enterpriseCd;
                        ipa.MakerCode = wk.SubstDestMakerCd;
                        ipa.PrtsNo = wk.SubstDestPartsNo;

                        lstUsrDBSearch.Add( ipa );
                        inParts.Add( ipa );
                    }
                    # endregion
                }
                // --- ADD m.suzuki 2011/01/27 ----------<<<<<

                if (searchFlg != UsrSearchFlg.UsrPartsOnly)
                {
                    ArrayList inSetSubst = new ArrayList();
                    //[�C]�Z�b�g��������
                    status = SearchSetParts(lstUsrDBSearch, out _usrSetPartsRetWork, sqlConnection);
                    if (status != 0)
                    {
                        return status;
                    }
                    //--------------------------------
                    foreach (UsrSetPartsRetWork wk in _usrSetPartsRetWork)
                    {
                        UsrPartsNoSearchCondWork ipa = new UsrPartsNoSearchCondWork();
                        ipa.EnterpriseCode = enterpriseCd;
                        ipa.MakerCode = wk.SetSubMakerCd;
                        ipa.PrtsNo = wk.SetSubPartsNo;

                        inSetSubst.Add(ipa);
                    }
                    lstUsrDBSearch.AddRange(inSetSubst);
                    inParts.AddRange(inSetSubst);

                    //if (searchFlg == UsrSearchFlg.UsrPartsAndAll)
                    if (searchFlg >= UsrSearchFlg.UsrPartsAndSet)
                    {
                        //[�@c]�Z�b�g�q�̑�֌�������
                        status = UsrPartsSubstMain(inSetSubst, out outSetSubst, sqlConnection);
                        if (status != 0)
                        {
                            return status;
                        }
                        //���i���擾����
                        foreach (UsrPartsSubstRetWork wk in outSetSubst)
                        {
                            UsrPartsNoSearchCondWork ipa = new UsrPartsNoSearchCondWork();
                            ipa.EnterpriseCode = enterpriseCd;
                            ipa.MakerCode = wk.SubstDestMakerCd;
                            ipa.PrtsNo = wk.SubstDestPartsNo;

                            lstUsrDBSearch.Add(ipa);
                            inParts.Add(ipa);
                        }
                        //--------------------------------
                    }  // searchFlg��1�̂Ƃ��̂ݏ�L�u���b�N�����s
                }

                //[�B]���i���擾����
                //status = SearchUsrGoods(inParts, out usrGoodsRetWorkUsr, sqlConnection); // 2009/09/04 DEL
                status = SearchUsrGoods(inParts, logicalMode, out usrGoodsRetWorkUsr, sqlConnection); // 2009/09/04 ADD
                _usrGoodsRetWork.AddRange(usrGoodsRetWorkUsr);
                if (status != 0)
                {
                    return status;
                }
                //--------------------------------
                ArrayList _usrGoodsPrice = null;

                status = SearchUsrGoodsPriceProc(lstUsrDBSearch, out _usrGoodsPrice, ConstantManagement.LogicalMode.GetData0, sqlConnection);
                if (status != 0)
                {
                    return status;
                }
                ArrayList _usrGoodsStock = null;
                status = GetStockInfo(lstUsrDBSearch, out _usrGoodsStock, sqlConnection);

                //�߂�l�̐ݒ�
                //if (searchFlg == UsrSearchFlg.UsrPartsAndAll)
                if (searchFlg >= UsrSearchFlg.UsrPartsAndSet)
                {
                    if (outSubst != null)
                        _usrPartsSubstRetWork = outSubst;
                    if (outJoinSubst != null)
                        _usrPartsSubstRetWork.AddRange(outJoinSubst);
                    if (outSetSubst != null)
                        _usrPartsSubstRetWork.AddRange(outSetSubst);

                    retList.Add(_usrPartsSubstRetWork); // [0] ��փ��X�g
                }

                // --- UPD m.suzuki 2011/01/27 ---------->>>>>
                //if ( searchFlg == UsrSearchFlg.UsrPartsAndAll || searchFlg == UsrSearchFlg.UsrPartsJoinSet )
                //    retList.Add(_usrJoinPartsRetWork);  // [1] �������X�g

                if ( searchFlg == UsrSearchFlg.UsrPartsAndAll || 
                     searchFlg == UsrSearchFlg.UsrPartsJoinSet ||
                     (searchFlg == UsrSearchFlg.UsrPartsAndSet && _usrJoinPartsRetWork != null && _usrJoinPartsRetWork.Count > 0) )
                {
                    retList.Add( _usrJoinPartsRetWork );  // [1] �������X�g
                }
                // --- UPD m.suzuki 2011/01/27 ----------<<<<<

                if (searchFlg != UsrSearchFlg.UsrPartsOnly)
                    retList.Add(_usrSetPartsRetWork);   // [2] �Z�b�g���X�g
                retList.Add(_usrGoodsRetWork);      // [3] ���i���X�g
                retList.Add(_usrGoodsPrice);        // [4] ���i���X�g
                retList.Add(_usrGoodsStock);        // [5] �݌Ƀ��X�g
            }
            catch (SqlException ex)
            {
                return base.WriteSQLErrorLog(ex, "UsrJoinPartsSearchDB.Search�ɂ�SQL�G���[���� Msg=" + ex.Message, 0);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UsrJoinPartsSearchDB.Search Exception = " + ex.Message);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                retObj = (object)retList;
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� ------------------------------------------------->>>>>
        /// <summary>
        ///  ���[�U�[���i����DB�����[�g�I�u�W�F�N�g�i�����񓚏����p�j
        /// </summary>
        /// <param name="retObj"></param>
        /// <param name="searchFlg"></param>
        /// <param name="searchType"></param>
        /// <param name="logicalMode"></param>
        /// <param name="searchCond"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int UserGoodsJoinSearchProcForAutoSearch(out object retObj, UsrSearchFlg searchFlg, int searchType, ConstantManagement.LogicalMode logicalMode, object searchCond, SqlConnection sqlConnection) // 2009/09/04 ADD
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            //���o�̓p�����[�^�[�ݒ�
            CustomSerializeArrayList retList = new CustomSerializeArrayList();
            retObj = null;
            try
            {
                string enterpriseCd = string.Empty;
                ArrayList _usrPartsSubstRetWork = null;	        //���[�U�[��փ}�X�^���X�g
                ArrayList _usrJoinPartsRetWork = null;	        //���[�U�[�����}�X�^���X�g
                ArrayList _usrGoodsRetWork = new ArrayList();	//���[�U�[���i�}�X�^���X�g
                ArrayList _usrSetPartsRetWork = null;           //���[�U�[�Z�b�g�}�X�^���X�g

                ArrayList inParts = new ArrayList();            // ���i���X�g(���[�U�[DB�̏��i�}�X�^����擾���鏤�i���̂�)

                ArrayList lstUsrDBSearch = new ArrayList();                // ���[�U�[DB�����p���X�g

                ArrayList outSubst = null;                      // ���[�U�[��֌������ʃ��X�g
                ArrayList outJoinSubst = null;                  // ���[�U�[������֌������ʃ��X�g
                ArrayList outSetSubst = null;                   // ���[�U�[�Z�b�g��֌������ʃ��X�g

                ArrayList searchCondList = searchCond as ArrayList;

                ArrayList usrGoodsRetWorkOfr;                   // ���[�U�[���i���X�g[ �񋟕��������ʃ��X�g ]
                ArrayList usrGoodsRetWorkUsr;                   // ���[�U�[���i���X�g[ ���[�U�[���������ʃ��X�g ]
                if (searchCondList != null && searchCondList.Count > 0)
                {
                    enterpriseCd = ((UsrPartsNoSearchCondWork)searchCondList[0]).EnterpriseCode;

                    UsrPartsNoSearchCondWork cond = searchCondList[0] as UsrPartsNoSearchCondWork;

                    //���i��������
                    //status = SearchUsrGoods(cond, searchType, out usrGoodsRetWorkOfr, sqlConnection); // 2009/09/04 DEL
                    status = SearchUsrGoods(cond, searchType, logicalMode, out usrGoodsRetWorkOfr, sqlConnection); // 2009/09/04 ADD
                    searchCondList.RemoveAt(0); // �擪�̌��������폜

                    lstUsrDBSearch.AddRange(searchCondList);
                    inParts.AddRange(searchCondList);

                    foreach (UsrGoodsRetWork wk in usrGoodsRetWorkOfr)
                    {
                        UsrPartsNoSearchCondWork ipa = new UsrPartsNoSearchCondWork();
                        ipa.EnterpriseCode = enterpriseCd;
                        ipa.MakerCode = wk.GoodsMakerCd;
                        ipa.PrtsNo = wk.GoodsNo;

                        lstUsrDBSearch.Add(ipa);
                    }
                    _usrGoodsRetWork.AddRange(usrGoodsRetWorkOfr);
                }
                else
                {
                    #region [ �������������X�g�łȂ��A�f�[�^�N���X�̏ꍇ - ���ݕs�v(�\���@�\) ]
                    UsrPartsNoSearchCondWork cond = searchCond as UsrPartsNoSearchCondWork;
                    if (cond != null)
                    {
                        enterpriseCd = cond.EnterpriseCode;
                        lstUsrDBSearch.Add(cond);
                        if (searchFlg == UsrSearchFlg.UsrPartsAndAll || searchFlg == UsrSearchFlg.UsrPartsAndSet)
                        {
                            inParts.Add(cond);
                        }

                        //���i��������
                        status = SearchUsrGoods(cond, searchType, logicalMode, out usrGoodsRetWorkOfr, sqlConnection); 
                        foreach (UsrGoodsRetWork wk in _usrSetPartsRetWork)
                        {
                            UsrPartsNoSearchCondWork ipa = new UsrPartsNoSearchCondWork();
                            ipa.EnterpriseCode = enterpriseCd;
                            ipa.MakerCode = wk.GoodsMakerCd;
                            ipa.PrtsNo = wk.GoodsNo;
                            inParts.Add(ipa);
                        }
                        _usrGoodsRetWork.AddRange(usrGoodsRetWorkOfr);
                    }
                    else
                    {
                        return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                    }
                    #endregion
                }

                ArrayList lstJoinSearch = new ArrayList();

                if (searchFlg >= UsrSearchFlg.UsrPartsAndSet)
                {
                    #region [ [�@a]�����i�ԁ���֌������� ]
                    status = UsrPartsSubstMainForAutoAnswer(lstUsrDBSearch, out outSubst, sqlConnection);
                    if (status != 0)
                    {
                        return status;
                    }

                    foreach (UsrPartsSubstRetWork wk in outSubst)
                    {
                        UsrPartsNoSearchCondWork ipa = new UsrPartsNoSearchCondWork();
                        ipa.EnterpriseCode = enterpriseCd;
                        ipa.MakerCode = wk.SubstDestMakerCd;
                        ipa.PrtsNo = wk.SubstDestPartsNo;

                        lstJoinSearch.Add(ipa);
                        lstUsrDBSearch.Add(ipa);
                        inParts.Add(ipa);
                    }
                    #endregion
                }
                if (searchFlg == UsrSearchFlg.UsrPartsAndAll || searchFlg == UsrSearchFlg.UsrPartsJoinSet)
                {
                    //[�A]���[�U�[�������������i�������i�A�D�Ǖ��i�ɑ΂�������������j
                    status = UsrJoinPartsSearch(lstUsrDBSearch, out _usrJoinPartsRetWork, sqlConnection);
                    if (status != 0)
                    {
                        return status;
                    }

                    ArrayList inJoinSubst = new ArrayList();
                    foreach (UsrJoinPartsRetWork wk in _usrJoinPartsRetWork)
                    {
                        UsrPartsNoSearchCondWork ipa = new UsrPartsNoSearchCondWork();
                        ipa.EnterpriseCode = enterpriseCd;
                        ipa.MakerCode = wk.JoinDestMakerCd;
                        ipa.PrtsNo = wk.JoinDestPartsNo;

                        inJoinSubst.Add(ipa);
                    }
                    lstUsrDBSearch.AddRange(inJoinSubst);
                    inParts.AddRange(inJoinSubst);

                    if (searchFlg >= UsrSearchFlg.UsrPartsAndSet)
                    {
                        //[�@b]�����i�ԁ���֌�������
                        status = UsrPartsSubstMainForAutoAnswer(inJoinSubst, out outJoinSubst, sqlConnection);
                        if (status != 0)
                        {
                            return status;
                        }
                        foreach (UsrPartsSubstRetWork wk in outJoinSubst)
                        {
                            UsrPartsNoSearchCondWork ipa = new UsrPartsNoSearchCondWork();
                            ipa.EnterpriseCode = enterpriseCd;
                            ipa.MakerCode = wk.SubstDestMakerCd;
                            ipa.PrtsNo = wk.SubstDestPartsNo;

                            lstUsrDBSearch.Add(ipa); // TODO : ���[�U�[�o�^���̌�����ւɑ΂��ăZ�b�g�������������H
                            inParts.Add(ipa);
                        }
                    }

                } // searchFlg��1�̂Ƃ��̂ݏ�L�u���b�N�����s
                else if (searchFlg == UsrSearchFlg.UsrPartsAndSet)
                {
                    # region [��ւ݂̂̏ꍇ�������I����\������̂ő�֐�ɑ΂��錋����̂ݒ��o]
                    //[�A]���[�U�[�������������i�������i�A�D�Ǖ��i�ɑ΂�������������j
                    status = UsrJoinPartsSearch(lstJoinSearch, out _usrJoinPartsRetWork, sqlConnection);
                    if (status != 0)
                    {
                        return status;
                    }

                    ArrayList inJoinSubst = new ArrayList();
                    foreach (UsrJoinPartsRetWork wk in _usrJoinPartsRetWork)
                    {
                        UsrPartsNoSearchCondWork ipa = new UsrPartsNoSearchCondWork();
                        ipa.EnterpriseCode = enterpriseCd;
                        ipa.MakerCode = wk.JoinDestMakerCd;
                        ipa.PrtsNo = wk.JoinDestPartsNo;

                        inJoinSubst.Add(ipa);
                    }
                    lstUsrDBSearch.AddRange(inJoinSubst);
                    inParts.AddRange(inJoinSubst);

                    //[�@b]�����i�ԁ���֌�������
                    status = UsrPartsSubstMainForAutoAnswer(inJoinSubst, out outJoinSubst, sqlConnection);
                    if (status != 0)
                    {
                        return status;
                    }
                    foreach (UsrPartsSubstRetWork wk in outJoinSubst)
                    {
                        UsrPartsNoSearchCondWork ipa = new UsrPartsNoSearchCondWork();
                        ipa.EnterpriseCode = enterpriseCd;
                        ipa.MakerCode = wk.SubstDestMakerCd;
                        ipa.PrtsNo = wk.SubstDestPartsNo;

                        lstUsrDBSearch.Add(ipa);
                        inParts.Add(ipa);
                    }
                    # endregion
                }

                if (searchFlg != UsrSearchFlg.UsrPartsOnly)
                {
                    ArrayList inSetSubst = new ArrayList();
                    //[�C]�Z�b�g��������
                    status = SearchSetParts(lstUsrDBSearch, out _usrSetPartsRetWork, sqlConnection);
                    if (status != 0)
                    {
                        return status;
                    }
                    //--------------------------------
                    foreach (UsrSetPartsRetWork wk in _usrSetPartsRetWork)
                    {
                        UsrPartsNoSearchCondWork ipa = new UsrPartsNoSearchCondWork();
                        ipa.EnterpriseCode = enterpriseCd;
                        ipa.MakerCode = wk.SetSubMakerCd;
                        ipa.PrtsNo = wk.SetSubPartsNo;

                        inSetSubst.Add(ipa);
                    }
                    lstUsrDBSearch.AddRange(inSetSubst);
                    inParts.AddRange(inSetSubst);

                    if (searchFlg >= UsrSearchFlg.UsrPartsAndSet)
                    {
                        //[�@c]�Z�b�g�q�̑�֌�������
                        status = UsrPartsSubstMainForAutoAnswer(inSetSubst, out outSetSubst, sqlConnection);
                        if (status != 0)
                        {
                            return status;
                        }
                        //���i���擾����
                        foreach (UsrPartsSubstRetWork wk in outSetSubst)
                        {
                            UsrPartsNoSearchCondWork ipa = new UsrPartsNoSearchCondWork();
                            ipa.EnterpriseCode = enterpriseCd;
                            ipa.MakerCode = wk.SubstDestMakerCd;
                            ipa.PrtsNo = wk.SubstDestPartsNo;

                            lstUsrDBSearch.Add(ipa);
                            inParts.Add(ipa);
                        }
                        //--------------------------------
                    }  // searchFlg��1�̂Ƃ��̂ݏ�L�u���b�N�����s
                }

                //[�B]���i���擾����
                status = SearchUsrGoods(inParts, logicalMode, out usrGoodsRetWorkUsr, sqlConnection); // 2009/09/04 ADD
                _usrGoodsRetWork.AddRange(usrGoodsRetWorkUsr);
                if (status != 0)
                {
                    return status;
                }
                //--------------------------------
                ArrayList _usrGoodsPrice = null;

                status = SearchUsrGoodsPriceProc(lstUsrDBSearch, out _usrGoodsPrice, ConstantManagement.LogicalMode.GetData0, sqlConnection);
                if (status != 0)
                {
                    return status;
                }
                ArrayList _usrGoodsStock = null;
                status = GetStockInfoForAutoSearch(lstUsrDBSearch, out _usrGoodsStock, sqlConnection);

                //�߂�l�̐ݒ�
                if (searchFlg >= UsrSearchFlg.UsrPartsAndSet)
                {
                    if (outSubst != null)
                        _usrPartsSubstRetWork = outSubst;
                    if (outJoinSubst != null)
                        _usrPartsSubstRetWork.AddRange(outJoinSubst);
                    if (outSetSubst != null)
                        _usrPartsSubstRetWork.AddRange(outSetSubst);

                    retList.Add(_usrPartsSubstRetWork); // [0] ��փ��X�g
                }


                if (searchFlg == UsrSearchFlg.UsrPartsAndAll ||
                     searchFlg == UsrSearchFlg.UsrPartsJoinSet ||
                     (searchFlg == UsrSearchFlg.UsrPartsAndSet && _usrJoinPartsRetWork != null && _usrJoinPartsRetWork.Count > 0))
                {
                    retList.Add(_usrJoinPartsRetWork);  // [1] �������X�g
                }

                if (searchFlg != UsrSearchFlg.UsrPartsOnly)
                    retList.Add(_usrSetPartsRetWork);   // [2] �Z�b�g���X�g
                retList.Add(_usrGoodsRetWork);      // [3] ���i���X�g
                retList.Add(_usrGoodsPrice);        // [4] ���i���X�g
                retList.Add(_usrGoodsStock);        // [5] �݌Ƀ��X�g
            }
            catch (SqlException ex)
            {
                return base.WriteSQLErrorLog(ex, "UsrJoinPartsSearchDB.Search�ɂ�SQL�G���[���� Msg=" + ex.Message, 0);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UsrJoinPartsSearchDB.Search Exception = " + ex.Message);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                retObj = (object)retList;
            }
            return status;
        }
        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� ------------------------------------------------->>>>>

        // �݌ɏ��擾����
        private int GetStockInfo(ArrayList inSetParts, out ArrayList _usrGoodsStock, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            if (inSetParts == null)
            {
                _usrGoodsStock = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            else if (inSetParts.Count == 0)
            {
                _usrGoodsStock = new ArrayList();
                return 0;
            }

            //���[�J�[�R�[�h�E�i�� 
            ArrayList retList = new ArrayList();
            StockDB stockDB = new StockDB();
            ArrayList stockRetList;
            StockWork stockWk = new StockWork();
            stockWk.EnterpriseCode = ((UsrPartsNoSearchCondWork)(inSetParts[0])).EnterpriseCode;

            foreach (UsrPartsNoSearchCondWork wk in inSetParts)
            {
                if ((wk.PrtsNo == string.Empty) || (wk.MakerCode == 0))
                {
                    continue;
                }

                stockWk.GoodsMakerCd = wk.MakerCode;
                stockWk.GoodsNo = wk.PrtsNo;
                status = stockDB.SearchStockProc(out stockRetList, stockWk, 0, ConstantManagement.LogicalMode.GetData0, ref sqlConnection);
                if (status == 0)
                {
                    retList.AddRange(stockRetList);
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                {
                    status = 0;
                }
            }
            _usrGoodsStock = retList;

            return status;
        }

        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� ------------------------------------------------->>>>>
        /// <summary>
        ///  �݌ɏ��擾����
        /// </summary>
        /// <param name="inSetParts"></param>
        /// <param name="_usrGoodsStock"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int GetStockInfoForAutoSearch(ArrayList inSetParts, out ArrayList _usrGoodsStock, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            if (inSetParts == null)
            {
                _usrGoodsStock = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            else if (inSetParts.Count == 0)
            {
                _usrGoodsStock = new ArrayList();
                return 0;
            }

            //���[�J�[�R�[�h�E�i�� 
            ArrayList retList = new ArrayList();
            StockDB stockDB = new StockDB();
            object stockRetList;
            List<StockWork> stockWkList = new List<StockWork>();


            foreach (UsrPartsNoSearchCondWork wk in inSetParts)
            {
                if ((wk.PrtsNo == string.Empty) || (wk.MakerCode == 0))
                {
                    continue;
                }

                StockWork stockWk = new StockWork();
                stockWk.EnterpriseCode = wk.EnterpriseCode;
                stockWk.GoodsMakerCd = wk.MakerCode;
                stockWk.GoodsNo = wk.PrtsNo;
                stockWkList.Add(stockWk);
            }

            object objStockWk = stockWkList;

            status = stockDB.SearchStockForAutoSearchProc(out stockRetList, objStockWk, 0, ConstantManagement.LogicalMode.GetData0, ref sqlConnection);
            if (status == 0)
            {
                retList.AddRange(stockRetList as ArrayList);
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_EOF)
            {
                status = 0;
            }
            _usrGoodsStock = retList;

            return status;
        }
        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� -------------------------------------------------<<<<<

        # endregion

        # region --- ���[�U�[���i���� DB�����[�g�I�u�W�F�N�g ---
        // 2009/09/04 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> DEL
        ///// <summary>
        ///// ���[�U�[���i����DB�����[�g�I�u�W�F�N�g
        ///// </summary>
        ///// <param name="partsNoSearchCondWork">��������[1���F�B�������@ArrayList�F����]</param>
        ///// <param name="searchType">0:���S��v/1:�O����v/2:�����v/3:�B��/4:�n�C�t���������S��v/5:[����]����������</param>
        ///// <param name="usrGoodsRetWork"></param>
        ///// <param name="usrGoodsPrice"></param>
        ///// <param name="usrGoodsStock"></param>
        ///// <returns></returns>
        //public int UserGoodsSearch(object partsNoSearchCondWork, int searchType, out ArrayList usrGoodsRetWork, out ArrayList usrGoodsPrice, out ArrayList usrGoodsStock)
        //{
        //    return UserGoodsSearchProc(partsNoSearchCondWork, searchType, out usrGoodsRetWork, out usrGoodsPrice, out usrGoodsStock);
        //}
        // 2009/09/04 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< DEL

        // 2009/09/04 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> ADD
        /// <summary>
        /// ���[�U�[���i����DB�����[�g�I�u�W�F�N�g
        /// </summary>
        /// <param name="partsNoSearchCondWork">��������[1���F�B�������@ArrayList�F����]</param>
        /// <param name="searchType">0:���S��v/1:�O����v/2:�����v/3:�B��/4:�n�C�t���������S��v/5:[����]����������</param>
        /// <param name="usrGoodsRetWork"></param>
        /// <param name="usrGoodsPrice"></param>
        /// <param name="usrGoodsStock"></param>
        /// <returns></returns>
        public int UserGoodsSearch(object partsNoSearchCondWork, int searchType, out ArrayList usrGoodsRetWork, out ArrayList usrGoodsPrice, out ArrayList usrGoodsStock)
        {
            return this.UserGoodsSearch(partsNoSearchCondWork, searchType, ConstantManagement.LogicalMode.GetData0, out usrGoodsRetWork, out usrGoodsPrice, out usrGoodsStock);
        }

        /// <summary>
        /// ���[�U�[���i����DB�����[�g�I�u�W�F�N�g
        /// </summary>
        /// <param name="partsNoSearchCondWork"></param>
        /// <param name="searchType"></param>
        /// <param name="logicalMode"></param>
        /// <param name="usrGoodsRetWork"></param>
        /// <param name="usrGoodsPrice"></param>
        /// <param name="usrGoodsStock"></param>
        /// <returns></returns>
        public int UserGoodsSearch(object partsNoSearchCondWork, int searchType, ConstantManagement.LogicalMode logicalMode, out ArrayList usrGoodsRetWork, out ArrayList usrGoodsPrice, out ArrayList usrGoodsStock)
        {
            return UserGoodsSearchProc(partsNoSearchCondWork, searchType, logicalMode, out usrGoodsRetWork, out usrGoodsPrice, out usrGoodsStock);
        }
        // 2009/09/04 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< ADD

        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� ------------------------------------------------->>>>>
        /// <summary>
        /// ���[�U�[���i����DB�����[�g�I�u�W�F�N�g
        /// </summary>
        /// <param name="partsNoSearchCondWorkList"></param>
        /// <param name="searchTypeList"></param>
        /// <param name="logicalMode"></param>
        /// <param name="usrGoodsRetWork"></param>
        /// <param name="usrGoodsPrice"></param>
        /// <param name="usrGoodsStock"></param>
        /// <returns></returns>
        public int UserGoodsSearch(ArrayList partsNoSearchCondWorkList, ArrayList searchTypeList, ConstantManagement.LogicalMode logicalMode, out ArrayList usrGoodsRetWork, out ArrayList usrGoodsPrice, out ArrayList usrGoodsStock)
        {
            return UserGoodsSearchProc(partsNoSearchCondWorkList, searchTypeList, logicalMode, out usrGoodsRetWork, out usrGoodsPrice, out usrGoodsStock);
        }
        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� -------------------------------------------------<<<<<

        //private int UserGoodsSearchProc(object partsNoSearchCondWork, int searchType, out ArrayList usrGoodsRetWork, out ArrayList usrGoodsPrice, out ArrayList usrGoodsStock) // 2009/09/04 DEL
        private int UserGoodsSearchProc(object partsNoSearchCondWork, int searchType, ConstantManagement.LogicalMode logicalMode, out ArrayList usrGoodsRetWork, out ArrayList usrGoodsPrice, out ArrayList usrGoodsStock) // 209/09/04 ADD
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            //���o�̓p�����[�^�[�ݒ�
            usrGoodsRetWork = null;
            usrGoodsPrice = null;
            usrGoodsStock = null;
            SqlConnection sqlConnection = null;

            try
            {
                string enterpriseCode;
                //�r�p�k��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                if (partsNoSearchCondWork is ArrayList)
                {
                    ArrayList searchCondList = partsNoSearchCondWork as ArrayList;
                    enterpriseCode = ((UsrPartsNoSearchCondWork)searchCondList[0]).EnterpriseCode;
                    //���i��������
                    //status = SearchUsrGoods(searchCondList, out usrGoodsRetWork, sqlConnection); // 2009/09/04 DEL
                    status = SearchUsrGoods(searchCondList, logicalMode, out usrGoodsRetWork, sqlConnection); // 2009/09/04 ADD
                }
                else if (partsNoSearchCondWork is UsrPartsNoSearchCondWork)
                {
                    if (searchType == 5) // ������������
                    {
                        UsrPartsNoSearchCondWork searchCond = partsNoSearchCondWork as UsrPartsNoSearchCondWork;
                        enterpriseCode = searchCond.EnterpriseCode;
                        //���i��������
                        status = SearchJoinSrcGoods(searchCond, out usrGoodsRetWork, sqlConnection);
                    }
                    else
                    {
                        UsrPartsNoSearchCondWork searchCond = partsNoSearchCondWork as UsrPartsNoSearchCondWork;
                        enterpriseCode = searchCond.EnterpriseCode;
                        //���i��������
                        //status = SearchUsrGoods(searchCond, searchType, out usrGoodsRetWork, sqlConnection); // 2009/09/04 DEL
                        status = SearchUsrGoods(searchCond, searchType, logicalMode, out usrGoodsRetWork, sqlConnection); // 2009/09/04 ADD
                    }
                }
                else
                {
                    return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                }
                ArrayList priceList = new ArrayList();
                foreach (UsrGoodsRetWork usrGoodsWork in usrGoodsRetWork)
                {
                    UsrPartsNoSearchCondWork wk = new UsrPartsNoSearchCondWork();
                    wk.EnterpriseCode = enterpriseCode;
                    wk.MakerCode = usrGoodsWork.GoodsMakerCd;
                    wk.PrtsNo = usrGoodsWork.GoodsNo;
                    priceList.Add(wk);
                }
                status = SearchUsrGoodsPriceProc(priceList, out usrGoodsPrice, ConstantManagement.LogicalMode.GetData0, sqlConnection);
                status = GetStockInfo(priceList, out usrGoodsStock, sqlConnection);
            }
            catch (SqlException ex)
            {
                return base.WriteSQLErrorLog(ex, "UsrJoinPartsSearchDB.GoodsSearch�ɂ�SQL�G���[���� Msg=" + ex.Message, 0);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UsrJoinPartsSearchDB.GoodsSearch Exception = " + ex.Message);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� ------------------------------------------------->>>>>
        /// <summary>
        ///  ���[�U�[���i����
        /// </summary>
        /// <param name="partsNoSearchCondWorkList"></param>
        /// <param name="searchTypeList"></param>
        /// <param name="logicalMode"></param>
        /// <param name="usrGoodsRetWork"></param>
        /// <param name="usrGoodsPrice"></param>
        /// <param name="usrGoodsStock"></param>
        /// <returns></returns>
        private int UserGoodsSearchProc(ArrayList partsNoSearchCondWorkList, ArrayList searchTypeList, ConstantManagement.LogicalMode logicalMode, out ArrayList usrGoodsRetWork, out ArrayList usrGoodsPrice, out ArrayList usrGoodsStock) 
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            //���o�̓p�����[�^�[�ݒ�
            usrGoodsRetWork = null;
            usrGoodsPrice = null;
            usrGoodsStock = null;
            SqlConnection sqlConnection = null;

            ArrayList usrGoodsRetWorkTemp = new ArrayList();
            ArrayList usrGoodsPriceTemp = new ArrayList();
            ArrayList usrGoodsStockTemp = new ArrayList();

            try
            {
                string enterpriseCode;
                //�r�p�k��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                for (int i = 0 ; i < partsNoSearchCondWorkList.Count; i++)
                {
                    UsrPartsNoSearchCondWork partsNoSearchCondWork = partsNoSearchCondWorkList[i] as UsrPartsNoSearchCondWork;
                    int searchType = (int)searchTypeList[i];

                    if (searchType == 5) // ������������
                    {
                        UsrPartsNoSearchCondWork searchCond = partsNoSearchCondWork;
                        enterpriseCode = searchCond.EnterpriseCode;
                        //���i��������
                        status = SearchJoinSrcGoods(searchCond, out usrGoodsRetWorkTemp, sqlConnection);
                    }
                    else
                    {
                        UsrPartsNoSearchCondWork searchCond = partsNoSearchCondWork;
                        enterpriseCode = searchCond.EnterpriseCode;
                        //���i��������
                        status = SearchUsrGoods(searchCond, searchType, logicalMode, out usrGoodsRetWorkTemp, sqlConnection); 
                    }
                    ArrayList priceList = new ArrayList();
                    foreach (UsrGoodsRetWork usrGoodsWork in usrGoodsRetWorkTemp)
                    {
                        UsrPartsNoSearchCondWork wk = new UsrPartsNoSearchCondWork();
                        wk.EnterpriseCode = enterpriseCode;
                        wk.MakerCode = usrGoodsWork.GoodsMakerCd;
                        wk.PrtsNo = usrGoodsWork.GoodsNo;
                        priceList.Add(wk);
                    }
                    status = SearchUsrGoodsPriceProc(priceList, out usrGoodsPriceTemp, ConstantManagement.LogicalMode.GetData0, sqlConnection);
                    status = GetStockInfo(priceList, out usrGoodsStockTemp, sqlConnection);

                    usrGoodsRetWork.Add(usrGoodsRetWorkTemp);
                    usrGoodsPrice.Add(usrGoodsPriceTemp);
                    usrGoodsStock.Add(usrGoodsStockTemp);
                }
            }
            catch (SqlException ex)
            {
                return base.WriteSQLErrorLog(ex, "UsrJoinPartsSearchDB.GoodsSearch�ɂ�SQL�G���[���� Msg=" + ex.Message, 0);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UsrJoinPartsSearchDB.GoodsSearch Exception = " + ex.Message);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                }
            }
            return status;
        }
        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� -------------------------------------------------<<<<<

        # endregion

        # region --- ���[�U�[���i�B������ DB�����[�g�I�u�W�F�N�g --- [ �s�v ]
#if NoUse
        /// <summary>
        /// ���[�U�[���i�B������DB�����[�g�I�u�W�F�N�g
        /// </summary>
        /// <param name="partsNoSearchCondWork"></param>
        /// <param name="usrGoodsRetWork"></param>
        /// <returns></returns>
        public int GoodsSearch(UsrPartsNoSearchCondWork partsNoSearchCondWork, out ArrayList usrGoodsRetWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            //���o�̓p�����[�^�[�ݒ�
            usrGoodsRetWork = null;
            SqlConnection sqlConnection = null;
            try
            {
                //�r�p�k��������
                SqlConnectionInfo sqlConnectioninfo = new SqlConnectionInfo();
                string connectionText = sqlConnectioninfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (string.IsNullOrEmpty(connectionText))
                {
                    return 99;
                }
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                //���i��������
                status = SearchUsrGoods(partsNoSearchCondWork, out usrGoodsRetWork, sqlConnection);
            }
            catch (SqlException ex)
            {
                return base.WriteSQLErrorLog(ex, "UsrJoinPartsSearchDB.GoodsSearch�ɂ�SQL�G���[���� Msg=" + ex.Message, 0);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UsrJoinPartsSearchDB.GoodsSearch Exception = " + ex.Message);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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
#endif
        # endregion

        /// <summary>
        /// ���[�U�[���i�擾����
        /// </summary>
        /// <param name="inParts"></param>
        /// <param name="usrGoodsPrice"></param>
        /// <returns></returns>
        public int SearchUsrGoodsPrice(ArrayList inParts, out ArrayList usrGoodsPrice)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            //���o�̓p�����[�^�[�ݒ�
            usrGoodsPrice = new ArrayList();
            SqlConnection sqlConnection = null;

            try
            {
                //�r�p�k��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return 99;
                sqlConnection.Open();

                //���i��������
                status = SearchUsrGoodsPriceProc(inParts, out usrGoodsPrice, ConstantManagement.LogicalMode.GetData0, sqlConnection);

            }
            catch (SqlException ex)
            {
                return base.WriteSQLErrorLog(ex, "UsrJoinPartsSearchDB.SearchUsrGoodsPrice�ɂ�SQL�G���[���� Msg=" + ex.Message, 0);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UsrJoinPartsSearchDB.SearchUsrGoodsPrice Exception = " + ex.Message);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// �i���擾(�S�p)
        /// </summary>
        /// <param name="makerCd">���[�J�R�[�h</param>
        /// <param name="partsNo">�n�C�t���t�i��</param>
        /// <param name="name">�i��</param>
        /// <returns></returns>
        public int GetPartsName(int makerCd, string partsNo, out string name)
        {
            return GetPartsNameProc(makerCd, partsNo, out name ,0);
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

        private int GetPartsNameProc(int makerCd, string partsNo, out string name ,int mode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string nameString = "";
            if (mode == 0)
                nameString = "GOODSNAMERF";
            else
                nameString = "GOODSNAMEKANARF";


            string query = "SELECT " + nameString +" GOODSNAMERF FROM GOODSURF "
                         + "WHERE GOODSNORF = @PARTSNO AND GOODSMAKERCDRF = @MAKERCODE ";
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
        //-------- ADD �c���� 2013/02/08 Redmine#34640 ------->>>>>
        /// <summary>
        /// ���i���ɂ���Đŗ����LIST��߂�܂�
        /// </summary>
        /// <param name="work">���i���</param>
        /// <param name="rateList">�߂胊�X�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���i���ɂ���Đŗ����LIST��߂�܂�</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2013/02/08</br>
        /// </remarks>
        public int GetRateWorkByGood(GoodsUnitDataWork work, out ArrayList rateList)
        {
            RateDB rate = new RateDB();
            return rate.SearchRateByGoodsNoMarker(work.EnterpriseCode, work.GoodsMakerCd, work.GoodsNo, out rateList);
        }

        /// <summary>
        /// �O�i�ԁE���i�Ԃ̌���
        /// </summary>
        /// <param name="parmWork">��������</param>
        /// <param name="readMode">�������[�h�i�O�F�O�ŁG�P�F���Łj</param>
        /// <param name="goodsList">��������</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �O�i�ԁE���i�Ԃ̌������s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2013/02/08</br>
        /// </remarks>
        public int GetPrevNextGoods(GoodsUnitDataWork parmWork, int readMode, out ArrayList goodsList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            goodsList = new ArrayList();
            SqlConnection sqlConnection = null;

            try
            {
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();
                status = SearchPrevNextGoods(parmWork, readMode, ref goodsList, ref sqlConnection);
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
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
        /// �O�i�ԁE���i�Ԃ̌���
        /// </summary>
        /// <param name="parmWork">��������</param>
        /// <param name="readMode">�������[�h�i�O�F�O�ŁG�P�F���Łj</param>
        /// <param name="goodsList">��������</param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �O�i�ԁE���i�Ԃ̌������s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2013/02/08</br>
        /// </remarks>
        private int SearchPrevNextGoods(GoodsUnitDataWork parmWork, int readMode, ref ArrayList goodsList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                sqlCommand = new SqlCommand();
                StringBuilder sqlText = new StringBuilder();

                sqlText.Append("SELECT TOP(1) ").Append(Environment.NewLine);
                sqlText.Append("  GOODSNORF ").Append(Environment.NewLine);
                sqlText.Append("  ,GOODSMAKERCDRF ").Append(Environment.NewLine);
                sqlText.Append("FROM ").Append(Environment.NewLine);
                sqlText.Append("  GOODSURF WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                sqlText.Append("WHERE ").Append(Environment.NewLine);
                //��ƃR�[�h
                sqlText.Append(" ENTERPRISECODERF=@ENTERPRISECODE ").Append(Environment.NewLine);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(parmWork.EnterpriseCode);
                // 0:�O�� 1:����
                if (readMode == 0)
                {
                    if (!string.IsNullOrEmpty(parmWork.GoodsNo))
                    {

                        if (parmWork.GoodsMakerCd != 0)
                        {
                            //���i�ԍ�
                            sqlText.Append(" AND ((GOODSNORF=@FINDGOODSNO ").Append(Environment.NewLine);

                            //���i���[�J�[�R�[�h
                            sqlText.Append(" AND GOODSMAKERCDRF<@FINDGOODSMAKERCD) ").Append(Environment.NewLine);

                            //���i�ԍ�
                            sqlText.Append(" OR (GOODSNORF<@FINDGOODSNO)) ").Append(Environment.NewLine);
                        }
                        else
                        {
                            //���i�ԍ�
                            sqlText.Append(" AND GOODSNORF<=@FINDGOODSNO ").Append(Environment.NewLine);
                        }
                    }

                    // ORDER BY
                    sqlText.Append("ORDER BY GOODSNORF DESC,GOODSMAKERCDRF DESC ").Append(Environment.NewLine);
                }
                else
                {
                    if (!string.IsNullOrEmpty(parmWork.GoodsNo))
                    {
                        if (parmWork.GoodsMakerCd != 0)
                        {
                            //���i�ԍ�
                            sqlText.Append(" AND ((GOODSNORF=@FINDGOODSNO ").Append(Environment.NewLine);

                            //���i���[�J�[�R�[�h
                            sqlText.Append(" AND GOODSMAKERCDRF>@FINDGOODSMAKERCD) ").Append(Environment.NewLine);

                            //���i�ԍ�
                            sqlText.Append(" OR (GOODSNORF>@FINDGOODSNO)) ").Append(Environment.NewLine);
                        }
                        else
                        {
                            //���i�ԍ�
                            sqlText.Append(" AND GOODSNORF>=@FINDGOODSNO ").Append(Environment.NewLine);
                        }
                    }

                    // ORDER BY
                    sqlText.Append("ORDER BY GOODSNORF,GOODSMAKERCDRF ").Append(Environment.NewLine);
                }

                SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                paraGoodsNo.Value = SqlDataMediator.SqlSetString(parmWork.GoodsNo);

                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(parmWork.GoodsMakerCd);

                sqlCommand.CommandText = sqlText.ToString();
                sqlCommand.Connection = sqlConnection;

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {

                    al.Add(CopyToGoodsWorkFromReader(ref myReader));

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
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            goodsList = al;

            return status;
        }

        /// <summary>
        /// myReader->GoodsUWork�֊i�[
        /// </summary>
        /// <param name="myReader"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : myReader->GoodsUWork�֊i�[���s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2013/02/08</br>
        /// </remarks>
        private GoodsUWork CopyToGoodsWorkFromReader(ref SqlDataReader myReader)
        {
            GoodsUWork goodsResultWork = new GoodsUWork();

            #region �N���X�֊i�[
            goodsResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            goodsResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            #endregion

            return goodsResultWork;
        }
        //-------- ADD �c���� 2013/02/08 Redmine#34640 -------<<<<<
        //-------- ADD �c���� K2013/03/18 Redmine#35071 ------->>>>>
        /// <summary>
        /// �w�肳�ꂽ�]�ƈ����ɑ΂��ď]�ƈ��Ǘ�����ǉ����Ė߂��܂�
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="employeeCode">�]�ƈ��R�[�h</param>
        /// <param name="unCstChngDiv">���P���C���敪</param>
        /// <param name="stckCntChngDiv">�݌ɐ��C���敪</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�]�ƈ����ɑ΂��ď]�ƈ��Ǘ�����ǉ����Ė߂��܂�</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : K2013/03/18</br>
        /// </remarks>
        public int ReadMng(string enterpriseCode, string employeeCode, out int unCstChngDiv, out int stckCntChngDiv)
        {
            try
            {
                unCstChngDiv = 0;
                stckCntChngDiv = 0;

                int status = ReadMngProc(enterpriseCode, employeeCode, out unCstChngDiv, out stckCntChngDiv);

                return status;
            }
            catch (Exception ex)
            {
                unCstChngDiv = 0;
                stckCntChngDiv = 0;
                base.WriteErrorLog(ex, "UsrJoinPartsSearchDB.ReadMng Exception = " + ex.Message);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
        }

        /// <summary>
        /// �w�肳�ꂽ�]�ƈ�Guid�̏]�ƈ���߂��܂�
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="employeeCode">�]�ƈ��R�[�h</param>
        /// <param name="unCstChngDiv">���P���C���敪</param>
        /// <param name="stckCntChngDiv">�݌ɐ��C���敪</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�]�ƈ����ɑ΂��ď]�ƈ��Ǘ�����ǉ����Ė߂��܂�</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : K2013/03/18</br>
        /// </remarks>
        private int ReadMngProc(string enterpriseCode, string employeeCode, out int unCstChngDiv, out int stckCntChngDiv)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            unCstChngDiv = 0;
            stckCntChngDiv = 0;

            try
            {
                //�R�l�N�V����������擾
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == string.Empty) return status;

                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                // �]�ƈ��Ǘ��}�X�^��������擾
                StringBuilder sqlString = new StringBuilder();

                sqlString.AppendLine("SELECT");
                sqlString.AppendLine("	 UNCSTCHNGDIVRF");
                sqlString.AppendLine("	,STCKCNTCHNGDIVRF");
                sqlString.AppendLine("FROM");
                sqlString.AppendLine("	 YMGTEMPLOYEEMNGRF");
                sqlString.AppendLine("WHERE");
                sqlString.AppendLine("	    ENTERPRISECODERF = @FINDENTERPRISECODE");
                sqlString.AppendLine("	AND EMPLOYEECODERF = @FINDEMPLOYEECODE");

                sqlCommand.CommandText = sqlString.ToString();

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterprisecode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaEmployeecode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findParaEmployeecode.Value = SqlDataMediator.SqlSetString(employeeCode);

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    unCstChngDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNCSTCHNGDIVRF"));
                    stckCntChngDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STCKCNTCHNGDIVRF"));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }
        //-------- ADD �c���� K2013/03/18 Redmine#35071 -------<<<<<
        # endregion

        # region --- �o�q�h�u�`�s�d��` ---

        # region --- ��֌������C������ ---
        /// <summary>
        /// ��֌������C������
        /// </summary>
        /// <param name="inWork"></param>
        /// <param name="retWork"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int UsrPartsSubstMain(ArrayList inWork, out ArrayList retWork, SqlConnection sqlConnection)
        {
            int status = 0;

            retWork = new ArrayList();
            if (inWork == null || inWork.Count == 0)
            {
                return status;
            }

            foreach (UsrPartsNoSearchCondWork condWk in inWork)
            {
                UsrPartsNoSearchCondWork usrSearchCondWk = new UsrPartsNoSearchCondWork(condWk);

                for (int ix = 1; ix < 11; ix++) // ��փ}�X�^�@�F�@�d�l�ōő�10����܂ŊǗ����邽�߁B
                {
                    if ((usrSearchCondWk.MakerCode == 0) || (string.IsNullOrEmpty(usrSearchCondWk.PrtsNo)))
                    {
                        break;
                    }

                    UsrPartsSubstRetWork _retwork;
                    status = UsrPartsSubstSearch(usrSearchCondWk, out _retwork, sqlConnection);
                    if (status == 0)
                    {
                        _retwork.MakerCode = condWk.MakerCode;
                        _retwork.PrtsNoWithHyphen = condWk.PrtsNo;
                        _retwork.SubstOrder = ix; // ��֏��ʂ�ݒ肷��B��֏���1�͏����𒼐ڑ�ւ�����́B2�͂��̑�֕i���ւ���Ƃ������Ƃ�10����܂ł����B

                        retWork.Add(_retwork);

                        //�������֕i�����̂��߁A���[�J�R�[�h�A�i�Ԃ����݂̑�֕i�ɐݒ肷��B
                        usrSearchCondWk.MakerCode = _retwork.SubstDestMakerCd;
                        usrSearchCondWk.PrtsNo = _retwork.SubstDestPartsNo;
                    }
                    else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        status = 0;
                        break;
                    }
                    else
                    {
                        return (status);
                    }
                }
            }
            return (status);
        }

        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� ------------------------------------------------->>>>>
        /// <summary>
        /// ��֌������C�������i�����񓚏�����p�j
        /// </summary>
        /// <param name="inWork"></param>
        /// <param name="retWork"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int UsrPartsSubstMainForAutoAnswer(ArrayList inWork, out ArrayList retWork, SqlConnection sqlConnection)
        {
            int status = 0;

            retWork = new ArrayList();
            if (inWork == null || inWork.Count == 0)
            {
                return status;
            }

            Dictionary<int, UsrPartsNoSearchCondWork> inWorkDic = new Dictionary<int, UsrPartsNoSearchCondWork>();
            Dictionary<int, UsrPartsNoSearchCondWork> usrSearchCondWkDic = new Dictionary<int, UsrPartsNoSearchCondWork>();
            string enterpriseCode = string.Empty;

            for (int i = 0; i < inWork.Count; i++)
            {
                UsrPartsNoSearchCondWork usrSearchCondWk = new UsrPartsNoSearchCondWork();
                usrSearchCondWk = inWork[i] as UsrPartsNoSearchCondWork;
                usrSearchCondWkDic.Add(i, usrSearchCondWk);
                inWorkDic.Add(i, usrSearchCondWk);
                if (i == 0) enterpriseCode = usrSearchCondWk.EnterpriseCode;
            }

            for (int ix = 1; ix < 11; ix++) // ��փ}�X�^�@�F�@�d�l�ōő�10����܂ŊǗ����邽�߁B
            {
                Dictionary<int, UsrPartsSubstRetWork> retWorkList;

                status = UsrPartsSubstSearch(enterpriseCode, usrSearchCondWkDic, out retWorkList, sqlConnection);
                if (status == 0)
                {
                    foreach (int key in retWorkList.Keys)
                    {
                        retWorkList[key].MakerCode = inWorkDic[key].MakerCode;
                        retWorkList[key].PrtsNoWithHyphen = inWorkDic[key].PrtsNo;
                        retWorkList[key].SubstOrder = ix; // ��֏��ʂ�ݒ肷��B��֏���1�͏����𒼐ڑ�ւ�����́B2�͂��̑�֕i���ւ���Ƃ������Ƃ�10����܂ł����B
                    }
                    retWork.AddRange(retWorkList.Values);

                    //�������֕i�����̂��߁A���[�J�R�[�h�A�i�Ԃ����݂̑�֕i�ɐݒ肷��B
                    usrSearchCondWkDic.Clear();
                    foreach (int key in retWorkList.Keys)
                    {
                        UsrPartsNoSearchCondWork usrSearchCondWk = new UsrPartsNoSearchCondWork();
                        usrSearchCondWk.MakerCode = retWorkList[key].SubstDestMakerCd;
                        usrSearchCondWk.PrtsNo = retWorkList[key].SubstDestPartsNo;
                        usrSearchCondWkDic.Add(key, usrSearchCondWk);
                    }
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    status = 0;
                    break;
                }
                else
                {
                    return (status);
                }
            }
            return (status);
        }
        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� -------------------------------------------------<<<<<
        # endregion

        # region --- ��֌������� ---

        private const string ctQuerySubst =
                 "SELECT "
                 + " PARTSSUBSTURF.CHGSRCMAKERCDRF, "
                 + " PARTSSUBSTURF.CHGSRCGOODSNORF, "
                 + " PARTSSUBSTURF.CHGDESTMAKERCDRF, "
                 + " PARTSSUBSTURF.CHGDESTGOODSNORF, "
                 + " PARTSSUBSTURF.APPLYSTADATERF, "
                 + " PARTSSUBSTURF.APPLYENDDATERF "
                 + " FROM PARTSSUBSTURF ";

        /// <summary>
        /// ��֌�������
        /// </summary>
        /// <param name="usrSearchCondWork">�����������[�N</param>
        /// <param name="retWork"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int UsrPartsSubstSearch(UsrPartsNoSearchCondWork usrSearchCondWork, out UsrPartsSubstRetWork retWork, SqlConnection sqlConnection)
        {
            SqlDataReader myReader = null;
            int status = 0;
            string selectstr = ctQuerySubst;

            retWork = new UsrPartsSubstRetWork();

            try
            {
                //�v�g�d�q�d�m����
                selectstr += "WHERE ENTERPRISECODERF = '" + usrSearchCondWork.EnterpriseCode;
                selectstr += "' AND LOGICALDELETECODERF = 0";

                //���[�J�[�R�[�h�E�i�� 
                selectstr += " AND ( PARTSSUBSTURF.CHGSRCMAKERCDRF = " + usrSearchCondWork.MakerCode + " AND ";
                selectstr += "PARTSSUBSTURF.CHGSRCGOODSNORF = '" + usrSearchCondWork.PrtsNo + "' ) ";

                SqlCommand sqlCommand = new SqlCommand(selectstr, sqlConnection);
                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read()) // �������ʂ͍ő�1��
                {
                    retWork.SubstSorMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CHGSRCMAKERCDRF"));
                    retWork.SubstSorPartsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGSRCGOODSNORF"));
                    retWork.SubstDestMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CHGDESTMAKERCDRF"));
                    retWork.SubstDestPartsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGDESTGOODSNORF"));
                    retWork.ApplyStDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("APPLYSTADATERF"));
                    retWork.ApplyEdDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("APPLYENDDATERF"));
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
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UsrJoinPartsSearchDB.UsrPartsSubstSearch�ɂăG���[���� Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed) myReader.Close();
            }
            return status;
        }

        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� ------------------------------------------------->>>>>
        /// <summary>
        /// ��֌�������
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="usrSearchCondWorkDic"></param>
        /// <param name="retWorkDic"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int UsrPartsSubstSearch(string enterpriseCode, Dictionary<int, UsrPartsNoSearchCondWork> usrSearchCondWorkDic, out Dictionary<int, UsrPartsSubstRetWork> retWorkDic, SqlConnection sqlConnection)
        {
            SqlDataReader myReader = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            string selectstr = ctQuerySubst;
            retWorkDic = new Dictionary<int, UsrPartsSubstRetWork>();

            if (usrSearchCondWorkDic == null || usrSearchCondWorkDic.Count == 0) return status;

            try
            {
                //�v�g�d�q�d�m����
                selectstr += "WHERE ENTERPRISECODERF = '" + enterpriseCode;
                selectstr += "' AND LOGICALDELETECODERF = 0";

                //���[�J�[�R�[�h�E�i�� 
                selectstr += " AND ( ";
                bool flgContinue = false;
                foreach (int key in usrSearchCondWorkDic.Keys)
                {
                    if (flgContinue) selectstr += " OR ";
                    selectstr += " ( PARTSSUBSTURF.CHGSRCMAKERCDRF = " + usrSearchCondWorkDic[key].MakerCode.ToString().Trim() + " AND ";
                    selectstr += "PARTSSUBSTURF.CHGSRCGOODSNORF = '" + usrSearchCondWorkDic[key].PrtsNo + "' ) ";
                    flgContinue = true;
                }
                selectstr += " ) ";

                SqlCommand sqlCommand = new SqlCommand(selectstr, sqlConnection);
                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    UsrPartsSubstRetWork retWork = new UsrPartsSubstRetWork();
                    retWork.SubstSorMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CHGSRCMAKERCDRF"));
                    retWork.SubstSorPartsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGSRCGOODSNORF"));
                    retWork.SubstDestMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CHGDESTMAKERCDRF"));
                    retWork.SubstDestPartsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGDESTGOODSNORF"));
                    retWork.ApplyStDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("APPLYSTADATERF"));
                    retWork.ApplyEdDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("APPLYENDDATERF"));

                    foreach (KeyValuePair<int, UsrPartsNoSearchCondWork> wk in usrSearchCondWorkDic)
                    {
                        if (retWork.SubstSorMakerCd == wk.Value.MakerCode && retWork.SubstSorPartsNo == wk.Value.PrtsNo)
                        {
                            retWorkDic.Add(wk.Key, retWork);
                            break;
                        }
                    }
                }
                if (retWorkDic.Count != 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UsrJoinPartsSearchDB.UsrPartsSubstSearch�ɂăG���[���� Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed) myReader.Close();
            }
            return status;
        }
        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� -------------------------------------------------<<<<<

        # endregion

        # region --- ������������ ---

        private const string ctQueryJoin =
                 "SELECT "
                 + " JOINPARTSURF.JOINDISPORDERRF, "
                 + " JOINPARTSURF.JOINSOURCEMAKERCODERF, "
                 + " JOINPARTSURF.JOINSOURPARTSNOWITHHRF, "
                 + " JOINPARTSURF.JOINSOURPARTSNONONEHRF, "
                 + " JOINPARTSURF.JOINDESTMAKERCDRF, "
                 + " JOINPARTSURF.JOINDESTPARTSNORF, "
                 + " JOINPARTSURF.JOINQTYRF, "
                 + " JOINPARTSURF.JOINSPECIALNOTERF "
                 + " FROM JOINPARTSURF ";

        /// <summary>
        /// ������������
        /// </summary>
        /// <param name="inWork">���������Ώە��i���X�g</param>
        /// <param name="retWork">�����������ʃ��X�g</param>
        /// <param name="sqlConnection">SQL Connection</param>
        /// <returns>DB Status</returns>
        private int UsrJoinPartsSearch(ArrayList inWork, out ArrayList retWork, SqlConnection sqlConnection)
        {
            SqlDataReader myReader = null;
            int status = 0;
            string selectstr = ctQueryJoin;

            retWork = new ArrayList();
            if (inWork == null || inWork.Count == 0) // ��{�I�ɍŏ��������i1�͂��邽�߁A���肦�Ȃ��P�[�X�����A�O�̂��߃`�F�b�N����B
            {
                return status;
            }
            StringBuilder wherestr = new StringBuilder(500);

            try
            {
                //�v�g�d�q�d�m����
                selectstr += "WHERE ENTERPRISECODERF = '" + ((UsrPartsNoSearchCondWork)inWork[0]).EnterpriseCode;
                selectstr += "' AND LOGICALDELETECODERF = 0 AND (";

                //�����惁�[�J�[�R�[�h�E������i�� 
                foreach (UsrPartsNoSearchCondWork wk in inWork)
                {
                    wherestr.Append("OR ( JOINPARTSURF.JOINSOURCEMAKERCODERF = " + wk.MakerCode + " AND ");
                    wherestr.AppendLine("JOINPARTSURF.JOINSOURPARTSNOWITHHRF = '" + wk.PrtsNo + "' ) ");
                }
                selectstr += wherestr.Remove(0, 2).ToString() + " )"; // �擪��OR����

                SqlCommand sqlCommand = new SqlCommand(selectstr, sqlConnection);

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    UsrJoinPartsRetWork mf = new UsrJoinPartsRetWork();

                    mf.JoinDispOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOINDISPORDERRF"));
                    mf.JoinSourceMakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOINSOURCEMAKERCODERF"));
                    mf.JoinSourPartsNoWithH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINSOURPARTSNOWITHHRF"));
                    mf.JoinSourPartsNoNoneH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINSOURPARTSNONONEHRF"));
                    mf.JoinDestMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOINDESTMAKERCDRF"));
                    mf.JoinDestPartsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINDESTPARTSNORF"));
                    mf.JoinQty = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("JOINQTYRF"));
                    mf.JoinSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINSPECIALNOTERF"));

                    retWork.Add(mf);
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UsrJoinPartsSearchDB.UsrJoinPartsSearch�ɂăG���[���� Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        # endregion

        # region --- �Z�b�g�}�X�^�������� ---

        private const string ctQuerySet =
                 "SELECT "
                 + "GOODSSETRF.PARENTGOODSMAKERCDRF, "
                 + "GOODSSETRF.PARENTGOODSNORF, "
                 + "GOODSSETRF.SUBGOODSMAKERCDRF, "
                 + "GOODSSETRF.SUBGOODSNORF, "
                 + "GOODSSETRF.DISPLAYORDERRF, "
                 + "GOODSSETRF.CNTFLRF, "
            //selectstr += "GOODSSETRF.SETNAMERF, "; // ?
                 + "GOODSSETRF.SETSPECIALNOTERF, "
                 + "GOODSSETRF.CATALOGSHAPENORF "
                 + "FROM GOODSSETRF ";
        /// <summary>
        /// �Z�b�g�}�X�^����
        /// </summary>
        /// <param name="inWork">�Z�b�g�����Ώە��i���X�g</param>
        /// <param name="retWork">�Z�b�g�������ʃ��X�g</param>
        /// <param name="sqlConnection">SQL Connection</param>
        /// <returns>DB Status</returns>
        private int SearchSetParts(ArrayList inWork, out ArrayList retWork, SqlConnection sqlConnection)
        {
            SqlDataReader myReader = null;
            int status = 0;
            string selectstr = ctQuerySet;

            retWork = new ArrayList();
            if (inWork == null || inWork.Count == 0) // ��{�I�ɍŏ��������i1�͂��邽�߁A���肦�Ȃ��P�[�X�����A�O�̂��߃`�F�b�N����B
            {
                return status;
            }
            StringBuilder wherestr = new StringBuilder(500);

            try
            {
                selectstr += "WHERE ENTERPRISECODERF = '" + ((UsrPartsNoSearchCondWork)inWork[0]).EnterpriseCode;
                selectstr += "' AND LOGICALDELETECODERF = 0 AND (";

                //�����惁�[�J�[�R�[�h�E������i�� 
                foreach (UsrPartsNoSearchCondWork wk in inWork)
                {
                    //�Z�b�g�i�ԃt���O���P�̏ꍇ�̂ݑΏ�

                    wherestr.Append("OR ( GOODSSETRF.PARENTGOODSMAKERCDRF = " + wk.MakerCode + " AND ");
                    wherestr.AppendLine("GOODSSETRF.PARENTGOODSNORF = '" + wk.PrtsNo + "' ) ");
                }
                selectstr += wherestr.Remove(0, 2).ToString() + " )"; // �擪��OR����

                SqlCommand sqlCommand = new SqlCommand(selectstr, sqlConnection);

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    UsrSetPartsRetWork mf = new UsrSetPartsRetWork();

                    mf.SetMainMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARENTGOODSMAKERCDRF"));
                    mf.SetMainPartsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARENTGOODSNORF"));
                    mf.SetSubMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBGOODSMAKERCDRF"));
                    mf.SetSubPartsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUBGOODSNORF"));
                    mf.SetDispOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF"));
                    mf.SetQty = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CNTFLRF"));
                    //mf.SetName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SETNAMERF")); // ?
                    mf.SetSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SETSPECIALNOTERF"));
                    mf.CatalogShapeNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CATALOGSHAPENORF"));

                    retWork.Add(mf);
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UsrJoinPartsSearchDB.SearchSetParts�ɂăG���[���� Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed) myReader.Close();
            }
            return status;
        }
        # endregion

        #region << ���i�}�X�^���� >>
        # region --- ���i�}�X�^�擾���ڒ�` ---
        // ���i�}�X�^�擾���ڒ�`
        private string GOODSRFSelectFields = "SELECT "
                + "GOODSURF.CREATEDATETIMERF, "
                + "GOODSURF.UPDATEDATETIMERF, "
                + "GOODSURF.ENTERPRISECODERF, "
                + "GOODSURF.FILEHEADERGUIDRF, "
                + "GOODSURF.UPDEMPLOYEECODERF, "
                + "GOODSURF.UPDASSEMBLYID1RF, "
                + "GOODSURF.UPDASSEMBLYID2RF, "
                + "GOODSURF.LOGICALDELETECODERF, "
                + "GOODSURF.GOODSMAKERCDRF, "
                + "GOODSURF.GOODSNORF, "
                + "GOODSURF.GOODSNAMERF, "
                + "GOODSURF.GOODSNAMEKANARF, "
                + "GOODSURF.JANRF, "
                + "GOODSURF.BLGOODSCODERF, "
                + "GOODSURF.DISPLAYORDERRF, "
                + "GOODSURF.GOODSRATERANKRF, "
                + "GOODSURF.GOODSSPECIALNOTERF, "
                + "GOODSURF.OFFERDATERF, "
                + "GOODSURF.TAXATIONDIVCDRF, "
                + "GOODSURF.GOODSNONONEHYPHENRF, "
                + "GOODSURF.OFFERDATERF, "
                + "GOODSURF.GOODSKINDCODERF, "
                + "GOODSURF.GOODSNOTE1RF, "
                + "GOODSURF.GOODSNOTE2RF, "
                + "GOODSURF.ENTERPRISEGANRECODERF, "
                + "GOODSURF.UPDATEDATERF, "
                + "GOODSURF.OFFERDATADIVRF, "
                + "BLGROUPURF.GOODSMGROUPRF "
                + "FROM GOODSURF LEFT JOIN BLGOODSCDURF ON GOODSURF.ENTERPRISECODERF = BLGOODSCDURF.ENTERPRISECODERF "
                + "AND GOODSURF.BLGOODSCODERF = BLGOODSCDURF.BLGOODSCODERF LEFT JOIN BLGROUPURF "
                + "ON BLGOODSCDURF.ENTERPRISECODERF = BLGROUPURF.ENTERPRISECODERF "
                + "AND BLGOODSCDURF.BLGROUPCODERF = BLGROUPURF.BLGROUPCODERF "
                + "WHERE GOODSURF.ENTERPRISECODERF = @FINDENTERPRISECODE AND ";
                //+ "GOODSURF.LOGICALDELETECODERF = 0 AND ( "; // 2009/09/04 DEL
        // ---- ADD START zhangy3 2012/05/22 FOR Redmine#29871 --------->>>>>
        //���[�J�[�R�[�h�˕i�Ԃ̏��Ń\�[�g���Ă���D�Ǖ��i(���[�U�[)���擾����
        private string GOODSMAKERCDANDGOODSNOSort = " ORDER BY GOODSMAKERCDRF,GOODSNORF ";
        // ---- ADD END   zhangy3 2012/05/22 FOR Redmine#29871 ---------<<<<<
        # endregion

        # region --- ���i�}�X�^���� ---
        /// <summary>
        /// ���i�}�X�^����
        /// </summary>
        /// <param name="inWork"></param>
        /// <param name="logicalMode"></param>
        /// <param name="retWork"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        //private int SearchUsrGoods(ArrayList inWork, out ArrayList retWork, SqlConnection sqlConnection)
        private int SearchUsrGoods(ArrayList inWork, ConstantManagement.LogicalMode logicalMode, out ArrayList retWork, SqlConnection sqlConnection) // 2009/09/04
        {
            int status = 0;
            int whereCnt = 0;
            string wherestr = string.Empty;

            retWork = new ArrayList();
            if (inWork == null || inWork.Count == 0)
            {
                return status;
            }
            try
            {
                string enterpriseCode = ((UsrPartsNoSearchCondWork)inWork[0]).EnterpriseCode;

                //���[�J�[�R�[�h�E�i�� 
                foreach (UsrPartsNoSearchCondWork wk in inWork)
                {
                    if (wk.PrtsNo == string.Empty)
                    {
                        continue;
                    }

                    if (wk.MakerCode == 0)
                    {
                        wherestr += "OR ( GOODSURF.GOODSNORF = '" + wk.PrtsNo + "' ) ";
                    }
                    else
                    {
                        wherestr += "OR ( GOODSURF.GOODSMAKERCDRF = " + wk.MakerCode + " AND ";
                        wherestr += "GOODSURF.GOODSNORF = '" + wk.PrtsNo + "' ) ";
                    }
                    whereCnt++;

                    if (whereCnt == 20)
                    {
                        //status = ExecuteUsrPartsQuery(enterpriseCode, wherestr, retWork, sqlConnection); // 2009/09/04 DEL
                        status = ExecuteUsrPartsQuery(enterpriseCode, logicalMode, wherestr, retWork, sqlConnection); // 2009/09/04 ADD
                        if (status != 0)
                            return status;
                        whereCnt = 0;
                        wherestr = string.Empty;
                    }
                }
                if (whereCnt > 0)
                {
                    //status = ExecuteUsrPartsQuery(enterpriseCode, wherestr, retWork, sqlConnection); // 2009/09/04 DEL
                    status = ExecuteUsrPartsQuery(enterpriseCode, logicalMode, wherestr, retWork, sqlConnection); // 2009/09/04 ADD
                }

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UsrJoinPartsSearchDB.SearchUsrGoods�ɂăG���[���� Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// �������i����
        /// </summary>
        /// <param name="partsNoSearchCondWork"></param>
        /// <param name="retWork"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int SearchJoinSrcGoods(UsrPartsNoSearchCondWork partsNoSearchCondWork, out ArrayList retWork, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            string partsNoRF = string.Empty;
            string selectstr = string.Empty;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            retWork = new ArrayList();

            try
            {
                //�i��
                string prtsNoWithHyphen = partsNoSearchCondWork.PrtsNo;
                if (prtsNoWithHyphen.Length <= 0)
                {
                    return (0);
                }

                sqlCommand = new SqlCommand();

                //�擾�}�X�^����
                selectstr = "SELECT "
                        + "GOODSURF.CREATEDATETIMERF, "
                        + "GOODSURF.UPDATEDATETIMERF, "
                        + "GOODSURF.ENTERPRISECODERF, "
                        + "GOODSURF.FILEHEADERGUIDRF, "
                        + "GOODSURF.UPDEMPLOYEECODERF, "
                        + "GOODSURF.UPDASSEMBLYID1RF, "
                        + "GOODSURF.UPDASSEMBLYID2RF, "
                        + "GOODSURF.LOGICALDELETECODERF, "
                        + "JOINPARTSURF.JOINSOURCEMAKERCODERF AS GOODSMAKERCDRF, "
                        + "JOINPARTSURF.JOINSOURPARTSNOWITHHRF AS GOODSNORF, "
                        + "GOODSURF.GOODSNAMERF, "
                        + "GOODSURF.GOODSNAMEKANARF, "
                        + "GOODSURF.JANRF, "
                        + "GOODSURF.BLGOODSCODERF, "
                        + "GOODSURF.DISPLAYORDERRF, "
                        + "GOODSURF.GOODSRATERANKRF, "
                        + "GOODSURF.GOODSSPECIALNOTERF, "
                        + "GOODSURF.OFFERDATERF, "
                        + "GOODSURF.TAXATIONDIVCDRF, "
                        + "GOODSURF.GOODSNONONEHYPHENRF, "
                        + "GOODSURF.OFFERDATERF, "
                        + "GOODSURF.GOODSKINDCODERF, "
                        + "GOODSURF.GOODSNOTE1RF, "
                        + "GOODSURF.GOODSNOTE2RF, "
                        + "GOODSURF.ENTERPRISEGANRECODERF, "
                        + "GOODSURF.UPDATEDATERF, "
                        + "GOODSURF.OFFERDATADIVRF, "
                        + "BLGROUPURF.GOODSMGROUPRF "
                        + "FROM JOINPARTSURF "
                        //+ "LEFT JOIN GOODSURF ON GOODSURF.GOODSNORF = JOINPARTSURF.JOINSOURPARTSNOWITHHRF "        // DEL huangt 2013/03/27 Redmine#35019
                        // --- ADD huangt 2013/03/27 Redmine#35019 ---------- >>>>> 
                        + "LEFT JOIN GOODSURF ON GOODSURF.ENTERPRISECODERF = JOINPARTSURF.ENTERPRISECODERF "
                        + "AND GOODSURF.GOODSNORF = JOINPARTSURF.JOINSOURPARTSNOWITHHRF "
                        // --- ADD huangt 2013/03/27 Redmine#35019 ---------- <<<<<
                        + "AND GOODSURF.GOODSMAKERCDRF = JOINPARTSURF.JOINSOURCEMAKERCODERF "
                        + "LEFT JOIN BLGOODSCDURF ON GOODSURF.ENTERPRISECODERF = BLGOODSCDURF.ENTERPRISECODERF "
                        + "AND GOODSURF.BLGOODSCODERF = BLGOODSCDURF.BLGOODSCODERF LEFT JOIN BLGROUPURF "
                        + "ON BLGOODSCDURF.ENTERPRISECODERF = BLGROUPURF.ENTERPRISECODERF "
                        + "AND BLGOODSCDURF.BLGROUPCODERF = BLGROUPURF.BLGROUPCODERF "
                        //+ "FROM GOODSURF LEFT JOIN BLGOODSCDURF ON GOODSURF.ENTERPRISECODERF = BLGOODSCDURF.ENTERPRISECODERF "
                        //+ "AND GOODSURF.BLGOODSCODERF = BLGOODSCDURF.BLGOODSCODERF LEFT JOIN BLGROUPURF "
                        //+ "ON BLGOODSCDURF.ENTERPRISECODERF = BLGROUPURF.ENTERPRISECODERF "
                        //+ "AND BLGOODSCDURF.BLGROUPCODERF = BLGROUPURF.BLGROUPCODERF "
                        //+ "INNER JOIN JOINPARTSURF ON GOODSURF.GOODSNORF = JOINPARTSURF.JOINSOURPARTSNOWITHHRF "
                        //+ "AND GOODSURF.GOODSMAKERCDRF = JOINPARTSURF.JOINSOURCEMAKERCODERF "
                        + "WHERE JOINPARTSURF.ENTERPRISECODERF = @FINDENTERPRISECODE AND "
                        + "JOINPARTSURF.JOINDESTMAKERCDRF = @FINDJOINDESTMAKERCD AND "
                        + "JOINPARTSURF.JOINDESTPARTSNORF = @FINDJOINDESTPARTSNO ";                        

                ((SqlParameter)sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar)).Value
                    = SqlDataMediator.SqlSetString(partsNoSearchCondWork.EnterpriseCode);
                //���[�J�[�R�[�h�E�i�� 
                ((SqlParameter)sqlCommand.Parameters.Add("@FINDJOINDESTMAKERCD", SqlDbType.Int)).Value = SqlDataMediator.SqlSetInt32(partsNoSearchCondWork.MakerCode);
                ((SqlParameter)sqlCommand.Parameters.Add("@FINDJOINDESTPARTSNO", SqlDbType.NVarChar)).Value = SqlDataMediator.SqlSetString(partsNoSearchCondWork.PrtsNo);

                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = selectstr;

                myReader = sqlCommand.ExecuteReader();
                SetUsrGoodsRetWork(myReader, retWork);

                if (retWork.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UsrJoinPartsSearchDB.SearchUsrGoods�ɂăG���[���� Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed) myReader.Close();
                if (sqlCommand != null) sqlCommand.Dispose();
            }
            return status;
        }

        //private int ExecuteUsrPartsQuery(string enterpriseCode, string wherestr, ArrayList retWork, SqlConnection sqlConnection) // 2009/09/04 DEL
        private int ExecuteUsrPartsQuery(string enterpriseCode, ConstantManagement.LogicalMode logicalMode, string wherestr, ArrayList retWork, SqlConnection sqlConnection) // 2009/09/04 ADD
        {
            int status = 0;
            SqlDataReader myReader = null;

            try
            {
                //�擾�}�X�^����
                string selectstr = GOODSRFSelectFields;
                // 2009/09/04 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    selectstr = selectstr + "GOODSURF.LOGICALDELETECODERF = @FINDLOGICALDELETECODE AND ( ";
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    selectstr = selectstr + "GOODSURF.LOGICALDELETECODERF < @FINDLOGICALDELETECODE AND ( ";
                }
                // 2009/09/04 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                
                wherestr = wherestr.Substring(2) + " )"; // �擪��OR����                

                SqlCommand sqlCommand = new SqlCommand(selectstr + wherestr, sqlConnection);
                ((SqlParameter)sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar)).Value
                    = SqlDataMediator.SqlSetString(enterpriseCode);

                // 2009/09/04 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                ((SqlParameter)sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int)).Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                // 2009/09/04 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                myReader = sqlCommand.ExecuteReader();
                SetUsrGoodsRetWork(myReader, retWork);
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed) myReader.Close();
            }
            return status;
        }
        # endregion

        # region --- ���i�}�X�^�������B�������� ---
        /// <summary>
        /// ���i�}�X�^�������B��������
        /// </summary>
        /// <param name="partsNoSearchCondWork"></param>
        /// <param name="searchType"></param>
        /// <param name="logicalMode"></param>
        /// <param name="retWork"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        /// <br>Update Note: 2012/05/22 zhangy3 </br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 2012/06/27�z�M��</br>
        /// <br>             Redmine#29871 ����`�[���́@�u*�v���g�p�����i�Ԍ����̌��ʂ�����قȂ�</br>
        //private int SearchUsrGoods(UsrPartsNoSearchCondWork partsNoSearchCondWork, int searchType, out ArrayList retWork, SqlConnection sqlConnection) // 2009/09/04 DEL
        private int SearchUsrGoods(UsrPartsNoSearchCondWork partsNoSearchCondWork, int searchType, ConstantManagement.LogicalMode logicalMode, out ArrayList retWork, SqlConnection sqlConnection) // 2009/09/04 ADD
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            string partsNoRF = string.Empty;
            string selectstr = string.Empty;
            string wherestr = string.Empty;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            retWork = new ArrayList();

            try
            {
                //�i��
                string prtsNoWithHyphen = partsNoSearchCondWork.PrtsNo;
                if (prtsNoWithHyphen.Length <= 0)
                {
                    return (0);
                }

                sqlCommand = new SqlCommand();

                //�擾�}�X�^����
                selectstr = GOODSRFSelectFields;
                // 2009/09/04 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    selectstr = selectstr + "GOODSURF.LOGICALDELETECODERF = @FINDLOGICALDELETECODE AND ( ";
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    selectstr = selectstr + "GOODSURF.LOGICALDELETECODERF < @FINDLOGICALDELETECODE AND ( ";
                }
                // 2009/09/04 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                selectstr = selectstr.Insert(6, " TOP (100) ");

                ((SqlParameter)sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar)).Value
                    = SqlDataMediator.SqlSetString(partsNoSearchCondWork.EnterpriseCode);

                // 2009/09/04 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                ((SqlParameter)sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int)).Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                // 2009/09/04 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                //���[�J�[�R�[�h�E�i�� 
                if (partsNoSearchCondWork.MakerCode != 0)
                {
                    wherestr += " GOODSURF.GOODSMAKERCDRF = @MAKERCDRF AND ";
                    ((SqlParameter)sqlCommand.Parameters.Add("@MAKERCDRF", SqlDbType.Int)).Value = SqlDataMediator.SqlSetInt32(partsNoSearchCondWork.MakerCode);
                }

                if (prtsNoWithHyphen.Contains("-") == true) //�i�ԃn�C�t������
                {
                    partsNoRF = "GOODSURF.GOODSNORF";
                }
                else                                        //�i�ԃn�C�t���Ȃ�
                {
                    partsNoRF = "GOODSURF.GOODSNONONEHYPHENRF";
                }

                switch (searchType)
                {
                    case 0: // ���S��v
                        wherestr += "GOODSURF.GOODSNORF = @GOODSNOWITHHYPRF )";
                        break;
                    case 1: // �O����v
                        prtsNoWithHyphen = prtsNoWithHyphen + "%";
                        wherestr += partsNoRF + " LIKE @GOODSNOWITHHYPRF )";
                        break;
                    case 2: // �����v
                        prtsNoWithHyphen = "%" + prtsNoWithHyphen;
                        wherestr += partsNoRF + " LIKE @GOODSNOWITHHYPRF )";
                        break;
                    case 3: // �B������
                        prtsNoWithHyphen = "%" + prtsNoWithHyphen + "%";
                        wherestr += partsNoRF + " LIKE @GOODSNOWITHHYPRF )";
                        break;
                    case 4: // �n�C�t���������S��v
                        wherestr += "GOODSURF.GOODSNONONEHYPHENRF = @GOODSNOWITHHYPRF )";
                        break;
                }
                ///////////////////////////////////////////////////////

                // �o�C���h�ϐ��Ƀp�����[�^��ݒ�                
                ((SqlParameter)sqlCommand.Parameters.Add("@GOODSNOWITHHYPRF", SqlDbType.NChar)).Value = SqlDataMediator.SqlSetString(prtsNoWithHyphen);

                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.Text;
                //sqlCommand.CommandText = selectstr + wherestr;//Del zhangy3 2012/05/22 FOR Redmine#29871
                sqlCommand.CommandText = selectstr + wherestr + GOODSMAKERCDANDGOODSNOSort;//ADD zhangy3 2012/05/22 FOR Redmine#29871

                myReader = sqlCommand.ExecuteReader();
                SetUsrGoodsRetWork(myReader, retWork);

                if (retWork.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UsrJoinPartsSearchDB.SearchUsrGoods�ɂăG���[���� Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed) myReader.Close();
                if (sqlCommand != null) sqlCommand.Dispose();
            }
            return status;
        }
        # endregion

        private int SearchUsrGoodsPriceProc(ArrayList inSetParts, out ArrayList usrGoodsPrice, ConstantManagement.LogicalMode logicalMode, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            int whereCnt = 0;
            string wherestr = string.Empty;

            usrGoodsPrice = new ArrayList();
            if (inSetParts == null)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            else if (inSetParts.Count == 0)
            {
                return 0;
            }
            try
            {
                string enterpriseCode = ((UsrPartsNoSearchCondWork)inSetParts[0]).EnterpriseCode;
                //----- ADD YANGMJ 2012/09/04 REDMINE#32095 ----->>>>>
                Dictionary<string, int> makerCodeParamDic = new Dictionary<string, int>();
                Dictionary<string, string> goodsNoParamDic = new Dictionary<string, string>();
                //----- ADD YANGMJ 2012/09/04 REDMINE#32095 -----<<<<<

                //���[�J�[�R�[�h�E�i�� 
                foreach (UsrPartsNoSearchCondWork wk in inSetParts)
                {
                    if ((wk.PrtsNo == string.Empty) || (wk.MakerCode == 0))
                    {
                        continue;
                    }
                    //----- ADD YANGMJ 2012/09/04 REDMINE#32095 ----->>>>>
                    string makerCodeParam = "@FINDGOODSMAKERCDRF" + whereCnt.ToString();
                    string GoodsNoParam = "@FINDGOODSNORF" + whereCnt.ToString();
                    //----- ADD YANGMJ 2012/09/04 REDMINE#32095 -----<<<<<
                    //----- DEL YANGMJ 2012/09/04 REDMINE#32095 ----->>>>>
                    //wherestr += "OR ( GOODSPRICEURF.GOODSMAKERCDRF = " + wk.MakerCode + " AND ";
                    //wherestr += "GOODSPRICEURF.GOODSNORF = '" + wk.PrtsNo + "' ) ";
                    //----- DEL YANGMJ 2012/09/04 REDMINE#32095 ----->>>>>
                    //----- ADD YANGMJ 2012/09/04 REDMINE#32095 ----->>>>>
                    wherestr += "OR ( GOODSPRICEURF.GOODSMAKERCDRF = " + makerCodeParam + " AND ";
                    wherestr += "GOODSPRICEURF.GOODSNORF = " + GoodsNoParam + " ) ";

                    if (makerCodeParamDic.ContainsKey(makerCodeParam))
                    {
                        makerCodeParamDic[makerCodeParam] = wk.MakerCode;
                    }
                    else
                    {
                        makerCodeParamDic.Add(makerCodeParam, wk.MakerCode);
                    }
                    if (goodsNoParamDic.ContainsKey(GoodsNoParam))
                    {
                        goodsNoParamDic[GoodsNoParam] = wk.PrtsNo;
                    }
                    else
                    {
                        goodsNoParamDic.Add(GoodsNoParam, wk.PrtsNo);
                    }
                    //----- ADD YANGMJ 2012/09/04 REDMINE#32095 -----<<<<<
                    whereCnt++;

                    if (whereCnt == 30)
                    {
                        //status = ExecutePriceQuery(enterpriseCode, wherestr, usrGoodsPrice, logicalMode, sqlConnection);//DEL YANGMJ 2012/09/04 REDMINE#32095
                        status = ExecutePriceQuery(enterpriseCode, wherestr, usrGoodsPrice, logicalMode, sqlConnection, makerCodeParamDic, goodsNoParamDic);//ADD YANGMJ 2012/09/04 REDMINE#32095
                        if (status != 0)
                            return status;
                        whereCnt = 0;
                        wherestr = string.Empty;
                        makerCodeParamDic = new Dictionary<string, int>();
                        goodsNoParamDic = new Dictionary<string, string>();
                    }
                }
                if (whereCnt > 0)
                {
                    //status = ExecutePriceQuery(enterpriseCode, wherestr, usrGoodsPrice, logicalMode, sqlConnection);//DEL YANGMJ 2012/09/04 REDMINE#32095
                    status = ExecutePriceQuery(enterpriseCode, wherestr, usrGoodsPrice, logicalMode, sqlConnection, makerCodeParamDic, goodsNoParamDic);//ADD YANGMJ 2012/09/04 REDMINE#32095
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UsrJoinPartsSearchDB.SearchUsrGoodsPrice�ɂăG���[���� Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        //private int ExecutePriceQuery(string enterpriseCode, string wherestr, ArrayList usrGoodsPrice, ConstantManagement.LogicalMode logicalMode, SqlConnection sqlConnection)//DEL YANGMJ 2012/09/04 REDMINE#32095
        private int ExecutePriceQuery(string enterpriseCode, string wherestr, ArrayList usrGoodsPrice, ConstantManagement.LogicalMode logicalMode, SqlConnection sqlConnection, Dictionary<string, int> makerCodeParamDic, Dictionary<string, string> goodsNoParamDic)//ADD YANGMJ 2012/09/04 REDMINE#32095
        {
            int status = 0;
            SqlDataReader myReader = null;
            //�擾�}�X�^����
            string selectstr = "SELECT "
                        + "GOODSPRICEURF.CREATEDATETIMERF, "
                        + "GOODSPRICEURF.UPDATEDATETIMERF, "
                        + "GOODSPRICEURF.ENTERPRISECODERF, "
                        + "GOODSPRICEURF.FILEHEADERGUIDRF, "
                        + "GOODSPRICEURF.UPDEMPLOYEECODERF, "
                        + "GOODSPRICEURF.UPDASSEMBLYID1RF, "
                        + "GOODSPRICEURF.UPDASSEMBLYID2RF, "
                        + "GOODSPRICEURF.LOGICALDELETECODERF, "

                        + "GOODSPRICEURF.GOODSMAKERCDRF, "
                        + "GOODSPRICEURF.GOODSNORF, "
                        + "GOODSPRICEURF.PRICESTARTDATERF, "
                        + "GOODSPRICEURF.LISTPRICERF, "
                        + "GOODSPRICEURF.SALESUNITCOSTRF, "
                        + "GOODSPRICEURF.STOCKRATERF, "
                        + "GOODSPRICEURF.OPENPRICEDIVRF, "
                        + "GOODSPRICEURF.OFFERDATERF, "
                        + "GOODSPRICEURF.UPDATEDATERF "
                        + "FROM GOODSPRICEURF "
                        + "WHERE ENTERPRISECODERF = @FINDENTERPRISECODE AND ";

            //----- ADD 2020/06/18 杍^ PMKOBETSU-4005 ---------->>>>>
            // �ϊ����Ăяo��
            ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

            // �ϊ���񏉊���
            convertDoubleRelease.ReleaseInitLib();
            //----- ADD 2020/06/18 杍^ PMKOBETSU-4005 ----------<<<<<

            try
            {
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    selectstr = selectstr + "LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND ( ";
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    selectstr = selectstr + "LOGICALDELETECODERF<@FINDLOGICALDELETECODE AND ( ";
                }
                else
                {
                    selectstr = selectstr + "( ";
                }

                wherestr = wherestr.Substring(2) + " ) "; // �擪��OR����
                string orderStr = " ORDER BY PRICESTARTDATERF DESC, GOODSNORF";

                SqlCommand sqlCommand = new SqlCommand(selectstr + wherestr + orderStr, sqlConnection);
                ((SqlParameter)sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar)).Value
                    = SqlDataMediator.SqlSetString(enterpriseCode);
                ((SqlParameter)sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int)).Value
                                    = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                //----- ADD YANGMJ 2012/09/04 REDMINE#32095 ----->>>>>
                foreach (string key in makerCodeParamDic.Keys)
                {
                    ((SqlParameter)sqlCommand.Parameters.Add(key, SqlDbType.Int)).Value
                        = SqlDataMediator.SqlSetInt32((Int32)makerCodeParamDic[key]);
                }
                foreach (string keyGoodsNo in goodsNoParamDic.Keys)
                {
                    string temp = goodsNoParamDic[keyGoodsNo];
                    ((SqlParameter)sqlCommand.Parameters.Add(keyGoodsNo, SqlDbType.Char)).Value
                        = SqlDataMediator.SqlSetString(temp);
                }
                //----- ADD YANGMJ 2012/09/04 REDMINE#32095 -----<<<<<
                // 2011/11/29 Add >>>
                sqlCommand.CommandTimeout = 60;
                // 2011/11/29 Add <<<

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    //UsrGoodsPriceWork mf = new UsrGoodsPriceWork();
                    GoodsPriceUWork mf = new GoodsPriceUWork();

                    mf.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    mf.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    mf.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    mf.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    mf.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    mf.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    mf.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    mf.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                    mf.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    mf.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    mf.PriceStartDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICESTARTDATERF"));               
                    //----- UPD 2020/06/18 杍^ PMKOBETSU-4005 ---------->>>>>
                    //mf.ListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF"));
                    convertDoubleRelease.EnterpriseCode = mf.EnterpriseCode;
                    convertDoubleRelease.GoodsMakerCd = mf.GoodsMakerCd;
                    convertDoubleRelease.GoodsNo = mf.GoodsNo;
                    convertDoubleRelease.ConvertSetParam = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF"));

                    // �ϊ��������s
                    convertDoubleRelease.ReleaseProc();

                    mf.ListPrice = convertDoubleRelease.ConvertInfParam.ConvertGetParam;
                    //----- UPD 2020/06/18 杍^ PMKOBETSU-4005 ----------<<<<<
                    mf.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));
                    mf.StockRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKRATERF"));
                    mf.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
                    mf.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    mf.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));
                    usrGoodsPrice.Add(mf);
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed) myReader.Close();
                //----- ADD 2020/06/18 杍^ PMKOBETSU-4005 ---------->>>>>
                // ���
                convertDoubleRelease.Dispose();
                //----- ADD 2020/06/18 杍^ PMKOBETSU-4005 ----------<<<<<
            }
            return status;
        }

        # region --- ���i�}�X�^���i�[���� ---
        /// <summary>
        /// ���i�}�X�^���i�[����
        /// </summary>
        /// <param name="myReader"></param>
        /// <param name="retWork"></param>
        /// <returns></returns>
        private void SetUsrGoodsRetWork(SqlDataReader myReader, ArrayList retWork)
        {
            while (myReader.Read())
            {
                UsrGoodsRetWork mf = new UsrGoodsRetWork();
                mf.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                mf.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                mf.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                mf.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                mf.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                mf.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                mf.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                mf.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                mf.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                mf.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                mf.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                mf.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
                mf.Jan = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JANRF"));
                mf.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                mf.DisplayOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF"));
                mf.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));
                mf.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));
                mf.GoodsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNONONEHYPHENRF"));
                mf.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
                mf.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSKINDCODERF"));
                mf.GoodsNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNOTE1RF"));
                mf.GoodsNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNOTE2RF"));
                mf.GoodsSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSSPECIALNOTERF"));
                mf.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));
                mf.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));
                mf.OfferDataDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATADIVRF"));
                mf.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));

                retWork.Add(mf);
            }
        }
        # endregion
        #endregion

        # endregion
        #endregion

        #region [ ���i�\���擾DB�����[�g�I�u�W�F�N�g ]
        #region [Search]
        // 2009.02.19 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        #region �폜
        ///// <summary>
        ///// �w�肳�ꂽ�����̏��i�\���擾���LIST��߂��܂�
        ///// </summary>
        ///// <param name="retObj">��������</param>
        ///// <param name="paraObj">�����p�����[�^</param>
        ///// <param name="readMode">�����敪(���ݖ��g�p)</param>
        ///// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : �w�肳�ꂽ�����̏��i�\���擾���LIST��߂��܂�</br>
        ///// <br>Programmer : 21015�@�����@�F��</br>
        ///// <br>Date       : 2006.12.06</br>
        //public int Search(ref object retObj, object paraObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
        //    SqlConnection sqlConnection = null;
        //    SqlTransaction sqlTransaction = null;

        //    try
        //    {
        //        //�R�l�N�V��������
        //        sqlConnection = CreateSqlConnection();
        //        if (sqlConnection == null) return status;
        //        sqlConnection.Open();

        //        status = SearchProc(ref retObj, paraObj, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        //    }
        //    catch (Exception ex)
        //    {
        //        base.WriteErrorLog(ex, "GoodsURelationDataDB.Search");
        //        status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
        //    }
        //    finally
        //    {
        //        if (sqlTransaction != null)
        //        {
        //            if (sqlTransaction.Connection != null)
        //            {
        //                sqlTransaction.Commit();
        //            }

        //            sqlTransaction.Dispose();
        //        }

        //        if (sqlConnection != null)
        //        {
        //            sqlConnection.Dispose();
        //        }
        //    }
        //    return status;
        //}

        ///// <summary>
        ///// �w�肳�ꂽ�����̏��i�\���擾���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        ///// </summary>
        ///// <param name="retObj">��������</param>
        ///// <param name="paraObj">�����p�����[�^</param>
        ///// <param name="readMode">�����敪(���ݖ��g�p)</param>
        ///// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        ///// <param name="sqlConnection">sqlConnection</param>
        ///// <param name="sqlTransaction">sqlTransaction</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : �w�肳�ꂽ�����̏��i�\���擾���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        ///// <br>Programmer : 21015�@�����@�F��</br>
        ///// <br>Date       : 2006.12.06</br>
        ///// <br></br>
        ///// <br>Update Note: 2007.08.27 ���� DC.NS�p�ɏC��</br>
        //public int SearchProc(ref object retObj, object paraObj, int readMode, ConstantManagement.LogicalMode logicalMode,
        //    ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        //{
        //    return SearchProcP(ref retObj, paraObj, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        //}

        //private int SearchProcP(ref object retObj, object paraObj, int readMode, ConstantManagement.LogicalMode logicalMode,
        //    ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
        //    GoodsUCndtnWork goodsrelationdataWork = null;

        //    CustomSerializeArrayList retCSAList = new CustomSerializeArrayList();

        //    ArrayList goodsrelationdataWorkList = paraObj as ArrayList;
        //    if (goodsrelationdataWorkList == null)
        //    {
        //        goodsrelationdataWork = paraObj as GoodsUCndtnWork;
        //    }
        //    else
        //    {
        //        if (goodsrelationdataWorkList.Count > 0)
        //            goodsrelationdataWork = goodsrelationdataWorkList[0] as GoodsUCndtnWork;
        //    }

        //    CustomSerializeArrayList paraList = retObj as CustomSerializeArrayList;
        //    for (int i = 0; i < paraList.Count; i++)
        //    {
        //        Type wktype = paraList[i].GetType();
        //        switch (wktype.Name)
        //        {
        //            //����S�̐ݒ�
        //            case "SalesTtlStWork":
        //                {
        //                    SalesTtlStDB salesTtlStDB = new SalesTtlStDB();
        //                    ArrayList retal = new ArrayList();
        //                    SalesTtlStWork salesTtlStWork = paraList[i] as SalesTtlStWork;
        //                    salesTtlStWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
        //                    status = salesTtlStDB.SearchSalesTtlStProc(out retal, salesTtlStWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        //                    retCSAList.Add(retal);
        //                }
        //                break;
        //            //���i������
        //            case "GoodsGroupUWork":
        //                {
        //                    GoodsGroupUDB goodsGroupUDB = new GoodsGroupUDB();
        //                    ArrayList retal = new ArrayList();
        //                    GoodsGroupUWork goodsGroupUWork = paraList[i] as GoodsGroupUWork;
        //                    goodsGroupUWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
        //                    status = goodsGroupUDB.Search(ref retal, goodsGroupUWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        //                    retCSAList.Add(retal);
        //                }
        //                break;

        //            //�D�ǐݒ�
        //            case "PrmSettingUWork":
        //                {
        //                    PrmSettingUDB prmSettingUDB = new PrmSettingUDB();
        //                    ArrayList retal = new ArrayList();
        //                    PrmSettingUWork prmSettingUWork = paraList[i] as PrmSettingUWork;
        //                    prmSettingUWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
        //                    status = prmSettingUDB.Search(ref retal, prmSettingUWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        //                    retCSAList.Add(retal);
        //                }
        //                break;

        //            //���[�J�[
        //            case "MakerUWork":
        //                {
        //                    MakerUDB makerUDB = new MakerUDB();
        //                    ArrayList retal = null;
        //                    MakerUWork makerUWork = new MakerUWork();
        //                    makerUWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
        //                    status = makerUDB.SearchMakerProc(out retal, makerUWork, readMode, logicalMode, ref sqlConnection);
        //                    retCSAList.Add(retal);
        //                }
        //                break;

        //            //BL�O���[�v 
        //            case "BLGroupUWork":
        //                {
        //                    BLGroupUDB bLGroupUDB = new BLGroupUDB();
        //                    ArrayList retal = new ArrayList();
        //                    BLGroupUWork bLGroupUWork = paraList[i] as BLGroupUWork;
        //                    bLGroupUWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
        //                    status = bLGroupUDB.Search(ref retal, bLGroupUWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        //                    retCSAList.Add(retal);
        //                }
        //                break;

        //            //BL�R�[�h               
        //            case "BLGoodsCdUWork":
        //                {
        //                    BLGoodsCdUDB bLGoodsCdUDB = new BLGoodsCdUDB();
        //                    ArrayList retal = null;
        //                    BLGoodsCdUWork bLGoodsCdUWork = paraList[i] as BLGoodsCdUWork;
        //                    bLGoodsCdUWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
        //                    status = bLGoodsCdUDB.SearchBLGoodsCdProc(out retal, bLGoodsCdUWork, readMode, logicalMode, ref sqlConnection);
        //                    retCSAList.Add(retal);
        //                }
        //                break;

        //            //���i�Ǘ�
        //            case "GoodsMngWork":
        //                {
        //                    GoodsMngDB goodsMngDB = new GoodsMngDB();
        //                    ArrayList retal = new ArrayList();
        //                    GoodsMngWork goodsMngWork = paraList[i] as GoodsMngWork;
        //                    goodsMngWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
        //                    status = goodsMngDB.SearchGoodsMngProc(out retal, goodsMngWork, readMode, logicalMode, ref sqlConnection);
        //                    retCSAList.Add(retal);
        //                }
        //                break;

        //            //���[�U�[�K�C�h
        //            case "UserGdBdUWork":
        //                {
        //                    UserGdBdUDB userGdBdUDB = new UserGdBdUDB();
        //                    //UserGdBdUWork userGdBdUWork = paraList[i] as UserGdBdUWork;
        //                    UserGdBdUWork[] usrGdBdLst = new UserGdBdUWork[1];
        //                    usrGdBdLst[0] = paraList[i] as UserGdBdUWork;

        //                    //���i�啪��(���[�U�[�K�C�h �K�C�h�敪:70)
        //                    ArrayList retal = null;
        //                    //userGdBdUWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
        //                    //userGdBdUWork.UserGuideDivCd = 70;
        //                    //status = userGdBdUDB.Search(out retal, userGdBdUWork, 0, logicalMode, ref sqlConnection);
        //                    usrGdBdLst[0].EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
        //                    usrGdBdLst[0].UserGuideDivCd = 70;
        //                    status = userGdBdUDB.Search(out retal, usrGdBdLst, 0, logicalMode, ref sqlConnection);
        //                    retCSAList.Add(retal);

        //                    //���Е���(���[�U�[�K�C�h �K�C�h�敪:41)
        //                    retal = null;
        //                    //userGdBdUWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
        //                    //userGdBdUWork.UserGuideDivCd = 41;
        //                    //status = userGdBdUDB.Search(out retal, userGdBdUWork, 0, logicalMode, ref sqlConnection);
        //                    usrGdBdLst[0].UserGuideDivCd = 41;
        //                    status = userGdBdUDB.Search(out retal, usrGdBdLst, 0, logicalMode, ref sqlConnection);
        //                    retCSAList.Add(retal);

        //                    //�̔��敪(���[�U�[�K�C�h �K�C�h�敪:71)
        //                    retal = null;
        //                    //userGdBdUWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
        //                    //userGdBdUWork.UserGuideDivCd = 71;
        //                    //status = userGdBdUDB.Search(out retal, userGdBdUWork, 0, logicalMode, ref sqlConnection);
        //                    usrGdBdLst[0].UserGuideDivCd = 71;
        //                    status = userGdBdUDB.Search(out retal, usrGdBdLst, 0, logicalMode, ref sqlConnection);
        //                    retCSAList.Add(retal);
        //                }
        //                break;

        //            //���i�A��
        //            case "GoodsUnitDataWork":
        //                {
        //                    ArrayList retal = null;
        //                    status = SearchGoodsURelationDataProc(out retal, wktype, goodsrelationdataWork, null, readMode, logicalMode, ref sqlConnection);
        //                    retCSAList.Add(retal);
        //                }
        //                break;

        //        }
        //    }

        //    retObj = retCSAList;

        //    // �� 2008.03.24 980081 c
        //    //return status;
        //    if (retCSAList.Count == 0)
        //    {
        //        return (int)ConstantManagement.DB_Status.ctDB_EOF;
        //    }
        //    else
        //    {
        //        return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //    }
        //    // �� 2008.03.24 980081 c
        //}
        #endregion

        /// <summary>
        /// �w�肳�ꂽ�����̏��i�\���擾���LIST��߂��܂�
        /// </summary>
        /// <param name="retObj">��������</param>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�\���擾���LIST��߂��܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2006.12.06</br>
        public int Search(ref object retObj, object paraObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            return Search(ref retObj, paraObj, readMode, 0, logicalMode);
        }

        /// <summary>
        /// �w�肳�ꂽ�����̏��i�\���擾���LIST��߂��܂�
        /// </summary>
        /// <param name="retObj">��������</param>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="maxCount">�擾MAX����(���i���)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        public int Search(ref object retObj, object paraObj, int readMode, int maxCount, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = SearchProc(ref retObj, paraObj, readMode, maxCount, logicalMode, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsURelationDataDB.Search");
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        sqlTransaction.Commit();
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̏��i�\���擾���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="retObj">��������</param>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="maxCount">�擾MAX����(���i���)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�\���擾���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2006.12.06</br>
        /// <br></br>
        /// <br>Update Note: 2007.08.27 ���� DC.NS�p�ɏC��</br>
        public int SearchProc(ref object retObj, object paraObj, int readMode, int maxCount, ConstantManagement.LogicalMode logicalMode,
            ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return SearchProcP(ref retObj, paraObj, readMode, maxCount, logicalMode, ref sqlConnection, ref sqlTransaction);
        }

        private int SearchProcP(ref object retObj, object paraObj, int readMode, int maxCount, ConstantManagement.LogicalMode logicalMode,
            ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            GoodsUCndtnWork goodsrelationdataWork = null;

            CustomSerializeArrayList retCSAList = new CustomSerializeArrayList();

            ArrayList goodsrelationdataWorkList = paraObj as ArrayList;
            if (goodsrelationdataWorkList == null)
            {
                goodsrelationdataWork = paraObj as GoodsUCndtnWork;
            }
            else
            {
                if (goodsrelationdataWorkList.Count > 0)
                    goodsrelationdataWork = goodsrelationdataWorkList[0] as GoodsUCndtnWork;
            }

            CustomSerializeArrayList paraList = retObj as CustomSerializeArrayList;
            for (int i = 0; i < paraList.Count; i++)
            {
                Type wktype = paraList[i].GetType();
                switch (wktype.Name)
                {
                    //����S�̐ݒ�
                    case "SalesTtlStWork":
                        {
                            SalesTtlStDB salesTtlStDB = new SalesTtlStDB();
                            ArrayList retal = new ArrayList();
                            SalesTtlStWork salesTtlStWork = paraList[i] as SalesTtlStWork;
                            salesTtlStWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
                            status = salesTtlStDB.SearchSalesTtlStProc(out retal, salesTtlStWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
                            retCSAList.Add(retal);
                        }
                        break;
                    //���i������
                    case "GoodsGroupUWork":
                        {
                            GoodsGroupUDB goodsGroupUDB = new GoodsGroupUDB();
                            ArrayList retal = new ArrayList();
                            GoodsGroupUWork goodsGroupUWork = paraList[i] as GoodsGroupUWork;
                            goodsGroupUWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
                            status = goodsGroupUDB.Search(ref retal, goodsGroupUWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
                            retCSAList.Add(retal);
                        }
                        break;

                    //�D�ǐݒ�
                    case "PrmSettingUWork":
                        {
                            PrmSettingUDB prmSettingUDB = new PrmSettingUDB();
                            ArrayList retal = new ArrayList();
                            PrmSettingUWork prmSettingUWork = paraList[i] as PrmSettingUWork;
                            prmSettingUWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
                            status = prmSettingUDB.Search(ref retal, prmSettingUWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
                            retCSAList.Add(retal);
                        }
                        break;

                    //���[�J�[
                    case "MakerUWork":
                        {
                            MakerUDB makerUDB = new MakerUDB();
                            ArrayList retal = null;
                            MakerUWork makerUWork = new MakerUWork();
                            makerUWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
                            status = makerUDB.SearchMakerProc(out retal, makerUWork, readMode, logicalMode, ref sqlConnection);
                            retCSAList.Add(retal);
                        }
                        break;

                    //BL�O���[�v 
                    case "BLGroupUWork":
                        {
                            BLGroupUDB bLGroupUDB = new BLGroupUDB();
                            ArrayList retal = new ArrayList();
                            BLGroupUWork bLGroupUWork = paraList[i] as BLGroupUWork;
                            bLGroupUWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
                            status = bLGroupUDB.Search(ref retal, bLGroupUWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
                            retCSAList.Add(retal);
                        }
                        break;

                    //BL�R�[�h               
                    case "BLGoodsCdUWork":
                        {
                            BLGoodsCdUDB bLGoodsCdUDB = new BLGoodsCdUDB();
                            ArrayList retal = null;
                            BLGoodsCdUWork bLGoodsCdUWork = paraList[i] as BLGoodsCdUWork;
                            bLGoodsCdUWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
                            status = bLGoodsCdUDB.SearchBLGoodsCdProc(out retal, bLGoodsCdUWork, readMode, logicalMode, ref sqlConnection);
                            retCSAList.Add(retal);
                        }
                        break;

                    //���i�Ǘ�
                    case "GoodsMngWork":
                        {
                            GoodsMngDB goodsMngDB = new GoodsMngDB();
                            ArrayList retal = new ArrayList();
                            GoodsMngWork goodsMngWork = paraList[i] as GoodsMngWork;
                            goodsMngWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
                            status = goodsMngDB.SearchGoodsMngProc(out retal, goodsMngWork, readMode, logicalMode, ref sqlConnection);
                            retCSAList.Add(retal);
                        }
                        break;

                    //���[�U�[�K�C�h
                    case "UserGdBdUWork":
                        {
                            UserGdBdUDB userGdBdUDB = new UserGdBdUDB();
                            //UserGdBdUWork userGdBdUWork = paraList[i] as UserGdBdUWork;
                            UserGdBdUWork[] usrGdBdLst = new UserGdBdUWork[1];
                            usrGdBdLst[0] = paraList[i] as UserGdBdUWork;

                            //���i�啪��(���[�U�[�K�C�h �K�C�h�敪:70)
                            ArrayList retal = null;
                            //userGdBdUWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
                            //userGdBdUWork.UserGuideDivCd = 70;
                            //status = userGdBdUDB.Search(out retal, userGdBdUWork, 0, logicalMode, ref sqlConnection);
                            usrGdBdLst[0].EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
                            usrGdBdLst[0].UserGuideDivCd = 70;
                            status = userGdBdUDB.Search(out retal, usrGdBdLst, 0, logicalMode, ref sqlConnection);
                            retCSAList.Add(retal);

                            //���Е���(���[�U�[�K�C�h �K�C�h�敪:41)
                            retal = null;
                            //userGdBdUWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
                            //userGdBdUWork.UserGuideDivCd = 41;
                            //status = userGdBdUDB.Search(out retal, userGdBdUWork, 0, logicalMode, ref sqlConnection);
                            usrGdBdLst[0].UserGuideDivCd = 41;
                            status = userGdBdUDB.Search(out retal, usrGdBdLst, 0, logicalMode, ref sqlConnection);
                            retCSAList.Add(retal);

                            //�̔��敪(���[�U�[�K�C�h �K�C�h�敪:71)
                            retal = null;
                            //userGdBdUWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
                            //userGdBdUWork.UserGuideDivCd = 71;
                            //status = userGdBdUDB.Search(out retal, userGdBdUWork, 0, logicalMode, ref sqlConnection);
                            usrGdBdLst[0].UserGuideDivCd = 71;
                            status = userGdBdUDB.Search(out retal, usrGdBdLst, 0, logicalMode, ref sqlConnection);
                            retCSAList.Add(retal);
                        }
                        break;

                    // 2009.02.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    // �������i
                    case "IsolIslandPrcWork":
                        {
                            IsolIslandPrcDB isolIslandPrcDB = new IsolIslandPrcDB();
                            ArrayList retal = new ArrayList();
                            IsolIslandPrcWork isolIslandPrcWork = paraList[i] as IsolIslandPrcWork;
                            isolIslandPrcWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
                            status = isolIslandPrcDB.Search(ref retal, isolIslandPrcWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
                            retCSAList.Add(retal);
                        }
                        break;
                    // 2009.02.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                    // 2009.04.09 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    // �d����
                    case "SupplierWork":
                        {
                            SupplierDB supplierDB = new SupplierDB();
                            ArrayList retal = new ArrayList();
                            SupplierWork supplierWork = paraList[i] as SupplierWork;
                            supplierWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
                            status = supplierDB.Search(out retal, supplierWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
                            retCSAList.Add(retal);
                        }
                        break;
                    // 2009.04.09 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                    //���i�A��
                    case "GoodsUnitDataWork":
                        {
                            ArrayList retal = null;
                            status = SearchGoodsURelationDataProc(out retal, wktype, goodsrelationdataWork, null, readMode, maxCount, logicalMode, ref sqlConnection);
                            retCSAList.Add(retal);
                        }
                        break;

                }
            }

            retObj = retCSAList;

            // �� 2008.03.24 980081 c
            //return status;

            // 2011/11/29 Add >>>
            // �R�}���h�^�C���A�E�g�̏ꍇ�A�X�e�[�^�X�����̂܂ܕԂ�
            if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                return status;
            // 2011/11/29 Add <<<
            if (retCSAList.Count == 0)
            {
                return (int)ConstantManagement.DB_Status.ctDB_EOF;
            }
            else
            {
                return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            // �� 2008.03.24 980081 c
        }
        // 2009.02.19 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// �w�肳�ꂽ�����̏��i�\���擾���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="goodsrelationdataWorkList">��������</param>
        /// <param name="trgType">�擾�Ώۋ敪</param>
        /// <param name="goodsrelationdataWork">���o����</param>
        /// <param name="paralist">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�\���擾���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2006.12.06</br>
        /// <br></br>
        /// <br>Update Note: 2007.08.27 ���� DC.NS�p�ɏC��</br>
        public int SearchGoodsURelationDataProc(out ArrayList goodsrelationdataWorkList, Type trgType, GoodsUCndtnWork goodsrelationdataWork,
            ArrayList paralist, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {

            // -- UPD 2011/03/17 -------------------------------------------------------->>>
            //// 2009.02.19 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //return SearchGoodsURelationDataProcP(out goodsrelationdataWorkList, trgType, goodsrelationdataWork, paralist, readMode, 0, logicalMode, ref sqlConnection);
            //// 2009.02.19 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            return SearchGoodsURelationDataProcP(out goodsrelationdataWorkList, trgType, goodsrelationdataWork, paralist, readMode, 0, logicalMode, 0,ref sqlConnection);
            // -- UPD 2011/03/17 --------------------------------------------------------<<<
        }

        // 2009.02.19 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// �w�肳�ꂽ�����̏��i�\���擾���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="goodsrelationdataWorkList">��������</param>
        /// <param name="trgType">�擾�Ώۋ敪</param>
        /// <param name="goodsrelationdataWork">���o����</param>
        /// <param name="paralist">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="maxCount">�擾MAX����(���i���)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        public int SearchGoodsURelationDataProc(out ArrayList goodsrelationdataWorkList, Type trgType, GoodsUCndtnWork goodsrelationdataWork,
            ArrayList paralist, int readMode, int maxCount, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            // -- UPD 2011/03/17 -------------------------------------------------------->>>
            //return SearchGoodsURelationDataProcP(out goodsrelationdataWorkList, trgType, goodsrelationdataWork, paralist, readMode, maxCount, logicalMode, ref sqlConnection);
            return SearchGoodsURelationDataProcP(out goodsrelationdataWorkList, trgType, goodsrelationdataWork, paralist, readMode, maxCount, logicalMode, 0, ref sqlConnection);
            // -- UPD 2011/03/17 --------------------------------------------------------<<<
        }
        // 2009.02.19 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        // -- UPD 2011/03/17 -------------------------------------------------------->>>
        /// <summary>
        /// ���[�U�[���i�}�X�^�Ɖ��i�}�X�^�݂̂��擾���܂��B
        /// </summary>
        /// <param name="retObj">��������</param>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="maxCount">�擾MAX����(���i���)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        public int UsrGoodsOnlySearch(ref object retObj, object paraObj, int readMode, int maxCount, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            GoodsUCndtnWork goodsrelationdataWork = null;
            CustomSerializeArrayList retCSAList = new CustomSerializeArrayList();

            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                ArrayList goodsrelationdataWorkList = paraObj as ArrayList;
                if (goodsrelationdataWorkList == null)
                {
                    goodsrelationdataWork = paraObj as GoodsUCndtnWork;
                }
                else
                {
                    if (goodsrelationdataWorkList.Count > 0)
                        goodsrelationdataWork = goodsrelationdataWorkList[0] as GoodsUCndtnWork;
                }

                CustomSerializeArrayList paraList = retObj as CustomSerializeArrayList;
                Type wktype = paraList[0].GetType();

                ArrayList retal = null;
                status = SearchGoodsURelationDataProcP(out retal, wktype, goodsrelationdataWork, null, readMode, maxCount, logicalMode, 1, ref sqlConnection);
                retCSAList.Add(retal);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsURelationDataDB.Search");
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                    sqlConnection = null;
                }
            }

            retObj = retCSAList;

            if (retCSAList.Count == 0)
            {
                return (int)ConstantManagement.DB_Status.ctDB_EOF;
            }
            else
            {
                return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

        }
        // -- UPD 2011/03/17 --------------------------------------------------------<<<

        // -- UPD 2011/03/17 -------------------------------------------------------->>>
        //// 2009.02.19 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ////private int SearchGoodsURelationDataProcP(out ArrayList goodsrelationdataWorkList, Type trgType, GoodsUCndtnWork goodsrelationdataWork, ArrayList paralist, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        //private int SearchGoodsURelationDataProcP(out ArrayList goodsrelationdataWorkList, Type trgType, GoodsUCndtnWork goodsrelationdataWork, ArrayList paralist, int readMode, int maxCount, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        //// 2009.02.19 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        private int SearchGoodsURelationDataProcP(out ArrayList goodsrelationdataWorkList, Type trgType, GoodsUCndtnWork goodsrelationdataWork, ArrayList paralist, int readMode, int maxCount, ConstantManagement.LogicalMode logicalMode, int stockSearchDiv ,ref SqlConnection sqlConnection)
        // -- UPD 2011/03/17 --------------------------------------------------------<<<
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            // 2009.02.19 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            string sMaxCount = string.Empty;
            if (maxCount != 0) sMaxCount = "TOP(" + maxCount.ToString() + ") ";
            // 2009.02.19 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            // -------- ADD START 2014.02.10 ���z -------->>>>>
            // ���i�}�X�^�\���p�I�v�V����
            bool optKonmanGoodsMstCtl = false;
            ServerLoginInfoAcquisition loginInfo = new ServerLoginInfoAcquisition();
            PurchaseStatus ps = loginInfo.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_KonmanGoodsMstCtl);
            if (ps == PurchaseStatus.Contract)
            {
                optKonmanGoodsMstCtl = true;
            }
            else
            {
                optKonmanGoodsMstCtl = false;
            }
            // -------- ADD END 2014.02.10 ���z --------<<<<<

            string selectstring = "";
            try
            {
                // 2009.02.19 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //selectstring += "SELECT GOODS.CREATEDATETIMERF" + Environment.NewLine;
                selectstring += "SELECT " + sMaxCount + "GOODS.CREATEDATETIMERF" + Environment.NewLine;
                // 2009.02.19 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                selectstring += "    ,GOODS.UPDATEDATETIMERF" + Environment.NewLine;
                selectstring += "    ,GOODS.ENTERPRISECODERF" + Environment.NewLine;
                selectstring += "    ,GOODS.FILEHEADERGUIDRF" + Environment.NewLine;
                selectstring += "    ,GOODS.UPDEMPLOYEECODERF" + Environment.NewLine;
                selectstring += "    ,GOODS.UPDASSEMBLYID1RF" + Environment.NewLine;
                selectstring += "    ,GOODS.UPDASSEMBLYID2RF" + Environment.NewLine;
                selectstring += "    ,GOODS.LOGICALDELETECODERF" + Environment.NewLine;
                selectstring += "    ,GOODS.GOODSMAKERCDRF" + Environment.NewLine;
                selectstring += "    ,GOODS.GOODSNORF" + Environment.NewLine;
                selectstring += "    ,GOODS.GOODSNAMERF" + Environment.NewLine;
                selectstring += "    ,GOODS.GOODSNAMEKANARF" + Environment.NewLine;
                selectstring += "    ,GOODS.JANRF" + Environment.NewLine;
                selectstring += "    ,GOODS.BLGOODSCODERF" + Environment.NewLine;
                selectstring += "    ,GOODS.DISPLAYORDERRF" + Environment.NewLine;
                selectstring += "    ,GOODS.GOODSRATERANKRF" + Environment.NewLine;
                selectstring += "    ,GOODS.TAXATIONDIVCDRF" + Environment.NewLine;
                selectstring += "    ,GOODS.GOODSNONONEHYPHENRF" + Environment.NewLine;
                selectstring += "    ,GOODS.OFFERDATERF" + Environment.NewLine;
                selectstring += "    ,GOODS.GOODSKINDCODERF" + Environment.NewLine;
                selectstring += "    ,GOODS.GOODSNOTE1RF" + Environment.NewLine;
                selectstring += "    ,GOODS.GOODSNOTE2RF" + Environment.NewLine;
                selectstring += "    ,GOODS.GOODSSPECIALNOTERF" + Environment.NewLine;
                selectstring += "    ,GOODS.ENTERPRISEGANRECODERF" + Environment.NewLine;
                selectstring += "    ,GOODS.UPDATEDATERF" + Environment.NewLine;
                selectstring += "    ,GOODS.OFFERDATADIVRF" + Environment.NewLine;
                // -------- ADD START 2014/02/10 ���z -------->>>>>
                // ���i�}�X�^�\���p�I�v�V��������
                if (optKonmanGoodsMstCtl)
                {
                    selectstring += "    ,GOODSA.STANDARDRF" + Environment.NewLine;
                    selectstring += "    ,GOODSA.PACKINGRF" + Environment.NewLine;
                    selectstring += "    ,GOODSA.POSNORF" + Environment.NewLine;
                    selectstring += "    ,GOODSA.MAKERGOODSNORF" + Environment.NewLine;
                    selectstring += "    ,GOODSA.CREATEDATETIMERF AS CREATEDATETIMEARF" + Environment.NewLine;
                    selectstring += "    ,GOODSA.UPDATEDATETIMERF AS UPDATEDATETIMEARF" + Environment.NewLine;
                    selectstring += "    ,GOODSA.FILEHEADERGUIDRF AS FILEHEADERGUIDARF" + Environment.NewLine;
                }
                // -------- ADD END 2014/02/10 ���z --------<<<<<
                selectstring += "FROM GOODSURF AS GOODS" + Environment.NewLine;
                // -------- ADD START 2014/02/10 ���z -------->>>>>
                // ���i�}�X�^�\���p�I�v�V��������
                if (optKonmanGoodsMstCtl)
                {
                    selectstring += "LEFT JOIN GOODSUARF AS GOODSA ON" + Environment.NewLine;
                    selectstring += "    GOODS.ENTERPRISECODERF = GOODSA.ENTERPRISECODERF" + Environment.NewLine;
                    selectstring += "AND GOODS.GOODSNORF = GOODSA.GOODSNORF" + Environment.NewLine;
                    selectstring += "AND GOODS.GOODSMAKERCDRF = GOODSA.GOODSMAKERCDRF" + Environment.NewLine;
                    selectstring += "AND GOODS.LOGICALDELETECODERF = GOODSA.LOGICALDELETECODERF" + Environment.NewLine;
                }
                // -------- ADD END 2014/02/10 ���z --------<<<<<

                sqlCommand = new SqlCommand(selectstring, sqlConnection);

                if (paralist != null)
                    sqlCommand.CommandText += MakeWhereStringMultiCondition(ref sqlCommand, trgType, paralist, logicalMode);
                else
                    sqlCommand.CommandText += MakeWhereString(ref sqlCommand, trgType, goodsrelationdataWork, logicalMode);

                sqlCommand.CommandText += "ORDER BY GOODS.GOODSMAKERCDRF ASC, GOODS.GOODSNORF ASC" + Environment.NewLine;

                // 2011/11/29 Add >>>
                sqlCommand.CommandTimeout = 60;
                // 2011/11/29 Add <<<

                myReader = sqlCommand.ExecuteReader();

                // ADD gezh 2013/01/24 Redmine#33361 ���C�ćA -------->>>>>
                ArrayList priceList = new ArrayList();
                ArrayList usrGoodsPrice;
                // ADD gezh 2013/01/24 Redmine#33361 ���C�ćA --------<<<<<
                while (myReader.Read())
                {
                    //al.Add(CopyToGoodsUnitDataWorkFromReader(ref myReader));// DEL 2014.02.10 ���z
                    al.Add(CopyToGoodsUnitDataWorkFromReader(ref myReader, optKonmanGoodsMstCtl));// ADD 2014.02.10 ���z

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    // ADD gezh 2013/01/24 Redmine#33361 ���C�ćA -------->>>>>
                    GoodsUnitDataWork usrGoodsWork = (GoodsUnitDataWork)al[al.Count - 1];
                    UsrPartsNoSearchCondWork wk = new UsrPartsNoSearchCondWork();
                    wk.EnterpriseCode = usrGoodsWork.EnterpriseCode;
                    wk.MakerCode = usrGoodsWork.GoodsMakerCd;
                    wk.PrtsNo = usrGoodsWork.GoodsNo;
                    priceList.Add(wk);
                    // ADD gezh 2013/01/24 Redmine#33361 ���C�ćA --------<<<<<
                }
                /* ---------------- DEL gezh 2013/01/24 Redmine#33361 ���C�ćA -------->>>>>
                ArrayList priceList = new ArrayList();
                ArrayList usrGoodsPrice;
                foreach (GoodsUnitDataWork usrGoodsWork in al)
                {
                    UsrPartsNoSearchCondWork wk = new UsrPartsNoSearchCondWork();
                    wk.EnterpriseCode = usrGoodsWork.EnterpriseCode;
                    wk.MakerCode = usrGoodsWork.GoodsMakerCd;
                    wk.PrtsNo = usrGoodsWork.GoodsNo;
                    priceList.Add(wk);
                }
                <<<<<-------------- DEL gezh 2013/01/24 Redmine#33361 ���C�ćA ---------- */
                myReader.Close();
                status = SearchUsrGoodsPriceProc(priceList, out usrGoodsPrice, logicalMode, sqlConnection);
                if (status == 0)
                {
                    // ADD gezh 2013/01/24 Redmine#33361 ���C�ćB -------->>>>>
                    Dictionary<string, ArrayList> priceDic = new Dictionary<string, ArrayList>();

                    foreach (GoodsPriceUWork prc in usrGoodsPrice)
                    {
                        ArrayList priceListNew;

                        string key = prc.GoodsMakerCd + prc.GoodsNo;

                        if (priceDic.TryGetValue(key, out priceListNew))
                        {
                            priceListNew.Add(prc);
                        }
                        else
                        {
                            priceListNew = new ArrayList();
                            priceListNew.Add(prc);
                            priceDic.Add(key, priceListNew);
                        }
                    }
                    // ADD gezh 2013/01/24 Redmine#33361 ���C�ćB --------<<<<<
                    foreach (GoodsUnitDataWork usrGoodsWork in al)
                    {
                        /* ---------------- DEL gezh 2013/01/24 Redmine#33361 ���C�ćB -------->>>>>
                        usrGoodsWork.PriceList = new ArrayList();
                        //foreach (UsrGoodsPriceWork prc in usrGoodsPrice)
                        foreach (GoodsPriceUWork prc in usrGoodsPrice)
                        {
                            if (usrGoodsWork.GoodsMakerCd == prc.GoodsMakerCd &&
                                usrGoodsWork.GoodsNo == prc.GoodsNo)
                            {
                                usrGoodsWork.PriceList.Add(prc);
                            }
                        }
                        <<<<<-------------- DEL gezh 2013/01/24 Redmine#33361 ���C�ćB ---------- */
                        // ADD gezh 2013/01/24 Redmine#33361 -------->>>>>
                        ArrayList priceListNew;
                        usrGoodsWork.PriceList = new ArrayList();
                        string key = usrGoodsWork.GoodsMakerCd + usrGoodsWork.GoodsNo;
                        if (priceDic.TryGetValue(key, out priceListNew))
                        {
                            usrGoodsWork.PriceList.AddRange(priceListNew);
                        }
                        // ADD gezh 2013/01/24 Redmine#33361 --------<<<<<
                    }
                }
                else
                {
                    foreach (GoodsUnitDataWork usrGoodsWork in al)
                    {
                        usrGoodsWork.PriceList = new ArrayList();
                    }
                }

                // -- ADD 2011/03/17 ------------->>>
                if (stockSearchDiv == 0)
                {
                // -- ADD 2011/03/17 -------------<<<
                    foreach (GoodsUnitDataWork usrGoodsWork in al)
                    {
                        ArrayList stockRetList;
                        StockDB stockDB = new StockDB();

                        StockWork stockWk = new StockWork();
                        stockWk.EnterpriseCode = usrGoodsWork.EnterpriseCode;
                        stockWk.GoodsMakerCd = usrGoodsWork.GoodsMakerCd;
                        stockWk.GoodsNo = usrGoodsWork.GoodsNo;
                        status = stockDB.SearchStockProc(out stockRetList, stockWk, 0, logicalMode, ref sqlConnection);
                        if (status == 0)
                        {
                            usrGoodsWork.StockList = stockRetList;
                        }
                        else
                        {
                            usrGoodsWork.StockList = new ArrayList();
                        }
                    }
                }  // -- ADD 2011/03/17
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            goodsrelationdataWorkList = al;

            return status;
        }

        #region [�d�l�ύX�ɂ�艺�L���\�b�h�����S�ɏ����������������{���c���B]
        /*
        public int SearchGoodsURelationDataProc(out ArrayList goodsrelationdataWorkList, Type trgType, GoodsUCndtnWork goodsrelationdataWork, ArrayList paralist, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            string selectstring = "";
            try
            {
                selectstring += "SELECT GOODS.CREATEDATETIMERF" + Environment.NewLine;
                selectstring += "    ,GOODS.UPDATEDATETIMERF" + Environment.NewLine;
                selectstring += "    ,GOODS.ENTERPRISECODERF" + Environment.NewLine;
                selectstring += "    ,GOODS.FILEHEADERGUIDRF" + Environment.NewLine;
                selectstring += "    ,GOODS.UPDEMPLOYEECODERF" + Environment.NewLine;
                selectstring += "    ,GOODS.UPDASSEMBLYID1RF" + Environment.NewLine;
                selectstring += "    ,GOODS.UPDASSEMBLYID2RF" + Environment.NewLine;
                selectstring += "    ,GOODS.LOGICALDELETECODERF" + Environment.NewLine;
                selectstring += "    ,GOODS.GOODSMAKERCDRF" + Environment.NewLine;
                selectstring += "    ,MAKERU.MAKERNAMERF AS MAKERNAME" + Environment.NewLine;
                selectstring += "    ,GOODS.GOODSNORF" + Environment.NewLine;
                selectstring += "    ,GOODS.GOODSNAMERF" + Environment.NewLine;
                selectstring += "    ,GOODS.GOODSNAMEKANARF" + Environment.NewLine;
                selectstring += "    ,GOODS.JANRF" + Environment.NewLine;
                selectstring += "    ,GOODS.BLGOODSCODERF" + Environment.NewLine;
                selectstring += "    ,BLGOODS.BLGOODSFULLNAMERF" + Environment.NewLine;
                selectstring += "    ,GOODS.DISPLAYORDERRF" + Environment.NewLine;
                selectstring += "    ,BLGROUPU.GOODSLGROUPRF AS GOODSLGROUP" + Environment.NewLine;
                selectstring += "    ,USERGD.GUIDENAMERF AS GOODSLGROUPNAME" + Environment.NewLine;
                selectstring += "    ,BLGROUPU.GOODSMGROUPRF AS GOODSMGROUP" + Environment.NewLine;
                selectstring += "    ,GOODSGROUPU.GOODSMGROUPNAMERF AS GOODSMGROUPNAME" + Environment.NewLine;
                selectstring += "    ,BLGROUPU.BLGROUPCODERF AS BLGROUPCODE" + Environment.NewLine;
                selectstring += "    ,BLGROUPU.BLGROUPNAMERF AS BLGROUPNAME" + Environment.NewLine;
                selectstring += "    ,GOODS.GOODSRATERANKRF" + Environment.NewLine;
                selectstring += "    ,GOODS.TAXATIONDIVCDRF" + Environment.NewLine;
                selectstring += "    ,GOODS.GOODSNONONEHYPHENRF" + Environment.NewLine;
                selectstring += "    ,GOODS.OFFERDATERF" + Environment.NewLine;
                selectstring += "    ,GOODS.GOODSKINDCODERF" + Environment.NewLine;
                selectstring += "    ,GOODS.GOODSNOTE1RF" + Environment.NewLine;
                selectstring += "    ,GOODS.GOODSNOTE2RF" + Environment.NewLine;
                selectstring += "    ,GOODS.GOODSSPECIALNOTERF" + Environment.NewLine;
                selectstring += "    ,GOODS.ENTERPRISEGANRECODERF" + Environment.NewLine;
                selectstring += "    ,USERGD01.GUIDENAMERF AS ENTERPRISEGANRENAME" + Environment.NewLine;
                selectstring += "    ,GOODS.UPDATEDATERF" + Environment.NewLine;
                selectstring += "    ,BLGOODS.GOODSRATEGRPCODERF" + Environment.NewLine;
                selectstring += "    ,BLGROUPU.SALESCODERF" + Environment.NewLine;
                selectstring += "    ,GOODSPRICE.CREATEDATETIMERF AS GOODSPCREATEDATETIME" + Environment.NewLine;
                selectstring += "    ,GOODSPRICE.UPDATEDATETIMERF AS GOODSPUPDATEDATETIME" + Environment.NewLine;
                selectstring += "    ,GOODSPRICE.ENTERPRISECODERF AS GOODSPENTERPRISECODE" + Environment.NewLine;
                selectstring += "    ,GOODSPRICE.FILEHEADERGUIDRF AS GOODSPFILEHEADERGUID" + Environment.NewLine;
                selectstring += "    ,GOODSPRICE.UPDEMPLOYEECODERF AS GOODSPUPDEMPLOYEECODE" + Environment.NewLine;
                selectstring += "    ,GOODSPRICE.UPDASSEMBLYID1RF AS GOODSPUPDASSEMBLYID1" + Environment.NewLine;
                selectstring += "    ,GOODSPRICE.UPDASSEMBLYID2RF AS GOODSPUPDASSEMBLYID2" + Environment.NewLine;
                selectstring += "    ,GOODSPRICE.PRICESTARTDATERF AS GOODSPPRICESTARTDATE" + Environment.NewLine;
                selectstring += "    ,GOODSPRICE.LISTPRICERF AS GOODSPLISTPRICE" + Environment.NewLine;
                selectstring += "    ,GOODSPRICE.SALESUNITCOSTRF AS GOODSPSALESUNITCOST" + Environment.NewLine;
                selectstring += "    ,GOODSPRICE.STOCKRATERF AS GOODSPSTOCKRATE" + Environment.NewLine;
                selectstring += "    ,GOODSPRICE.OPENPRICEDIVRF AS GOODSPOPENPRICEDIV" + Environment.NewLine;
                selectstring += "    ,GOODSPRICE.OFFERDATERF AS GOODSPOFFERDATE" + Environment.NewLine;
                selectstring += "    ,GOODSPRICE.UPDATEDATERF AS GOODSPUPDATEDATE" + Environment.NewLine;
                selectstring += "    ,STOCK.WAREHOUSECODERF AS WAREHOUSECODE" + Environment.NewLine;
                selectstring += "    ,WAREHOUSE.WAREHOUSENAMERF AS WAREHOUSENAME" + Environment.NewLine;
                selectstring += "    ,STOCK.SHIPMENTPOSCNTRF AS SHIPMENTPOSCNT" + Environment.NewLine;
                selectstring += "    ,STOCK.WAREHOUSESHELFNORF AS WAREHOUSESHELFNO" + Environment.NewLine;
                selectstring += "FROM GOODSURF AS GOODS" + Environment.NewLine;
                selectstring += "LEFT JOIN GOODSPRICEURF AS GOODSPRICE" + Environment.NewLine;
                selectstring += "ON" + Environment.NewLine;
                selectstring += "     GOODSPRICE.ENTERPRISECODERF=GOODS.ENTERPRISECODERF" + Environment.NewLine;
                selectstring += " AND GOODSPRICE.GOODSMAKERCDRF=GOODS.GOODSMAKERCDRF" + Environment.NewLine;
                selectstring += " AND GOODSPRICE.GOODSNORF=GOODS.GOODSNORF" + Environment.NewLine;
                selectstring += "LEFT JOIN MAKERURF AS MAKERU" + Environment.NewLine;
                selectstring += "ON" + Environment.NewLine;
                selectstring += "     MAKERU.ENTERPRISECODERF=GOODS.ENTERPRISECODERF" + Environment.NewLine;
                selectstring += " AND MAKERU.GOODSMAKERCDRF=GOODS.GOODSMAKERCDRF" + Environment.NewLine;
                selectstring += "LEFT JOIN BLGOODSCDURF AS BLGOODS" + Environment.NewLine;
                selectstring += "ON" + Environment.NewLine;
                selectstring += "     BLGOODS.ENTERPRISECODERF=GOODS.ENTERPRISECODERF" + Environment.NewLine;
                selectstring += " AND BLGOODS.BLGOODSCODERF=GOODS.BLGOODSCODERF" + Environment.NewLine;
                selectstring += "LEFT JOIN USERGDBDURF AS USERGD" + Environment.NewLine;
                selectstring += "ON" + Environment.NewLine;
                selectstring += "     USERGD.ENTERPRISECODERF=GOODS.ENTERPRISECODERF" + Environment.NewLine;
                selectstring += " AND USERGD.USERGUIDEDIVCDRF=70" + Environment.NewLine;
                selectstring += " AND USERGD.GUIDECODERF=GOODS.ENTERPRISEGANRECODERF" + Environment.NewLine;
                selectstring += "LEFT JOIN STOCKRF AS STOCK" + Environment.NewLine;
                selectstring += "ON" + Environment.NewLine;
                selectstring += "     STOCK.ENTERPRISECODERF=GOODS.ENTERPRISECODERF" + Environment.NewLine;
                selectstring += " AND STOCK.GOODSMAKERCDRF=GOODS.GOODSMAKERCDRF" + Environment.NewLine;
                selectstring += " AND STOCK.GOODSNORF=GOODS.GOODSNORF" + Environment.NewLine;
                selectstring += "LEFT JOIN WAREHOUSERF AS WAREHOUSE" + Environment.NewLine;
                selectstring += "ON" + Environment.NewLine;
                selectstring += "     WAREHOUSE.ENTERPRISECODERF=STOCK.ENTERPRISECODERF" + Environment.NewLine;
                selectstring += " AND WAREHOUSE.WAREHOUSECODERF=STOCK.WAREHOUSECODERF" + Environment.NewLine;
                selectstring += "LEFT JOIN BLGROUPURF AS BLGROUPU" + Environment.NewLine;
                selectstring += "ON" + Environment.NewLine;
                selectstring += "     BLGROUPU.ENTERPRISECODERF=BLGOODS.ENTERPRISECODERF" + Environment.NewLine;
                selectstring += " AND BLGROUPU.BLGROUPCODERF=BLGOODS.BLGROUPCODERF" + Environment.NewLine;
                selectstring += "LEFT JOIN USERGDBDURF AS USERGD01" + Environment.NewLine;
                selectstring += "ON" + Environment.NewLine;
                selectstring += "     USERGD01.ENTERPRISECODERF=BLGROUPU.ENTERPRISECODERF" + Environment.NewLine;
                selectstring += " AND USERGD01.USERGUIDEDIVCDRF=71" + Environment.NewLine;
                selectstring += " AND USERGD01.GUIDECODERF=BLGROUPU.GOODSLGROUPRF" + Environment.NewLine;
                selectstring += "LEFT JOIN GOODSGROUPURF AS GOODSGROUPU" + Environment.NewLine;
                selectstring += "ON" + Environment.NewLine;
                selectstring += "     GOODSGROUPU.ENTERPRISECODERF=BLGROUPU.ENTERPRISECODERF" + Environment.NewLine;
                selectstring += " AND GOODSGROUPU.GOODSMGROUPRF=BLGROUPU.GOODSMGROUPRF" + Environment.NewLine;

                sqlCommand = new SqlCommand(selectstring, sqlConnection);

                if (paralist != null)
                    sqlCommand.CommandText += MakeWhereStringMultiCondition(ref sqlCommand, trgType, paralist, logicalMode);
                else
                    sqlCommand.CommandText += MakeWhereString(ref sqlCommand, trgType, goodsrelationdataWork, logicalMode);

                sqlCommand.CommandText += "ORDER BY GOODSPRICE.PRICESTARTDATERF DESC, GOODS.GOODSMAKERCDRF ASC, GOODS.GOODSNORF ASC" + Environment.NewLine;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToGoodsUnitDataWorkFromReader(ref myReader));

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
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            goodsrelationdataWorkList = al;

            return status;
        }
        */
        #endregion

        /// <summary>
        /// �w�肳�ꂽ�����̏��i�\���擾���LIST��߂��܂�
        /// </summary>
        /// <param name="retObj">��������</param>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�\���擾���LIST��߂��܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2006.12.06</br>
        public int SearchMultiCondition(out object retObj, object paraObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            retObj = null;

            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = SearchMultiConditionProc(out retObj, paraObj, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsURelationDataDB.Search");
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̏��i�\���擾���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="retObj">��������</param>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�\���擾���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2006.12.06</br>
        public int SearchMultiConditionProc(out object retObj, object paraObj, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            CustomSerializeArrayList retCSAList = new CustomSerializeArrayList();

            ArrayList goodsrelationdataWorkList = paraObj as ArrayList;
            if (goodsrelationdataWorkList != null)
            {
            }

            CustomSerializeArrayList paraList = null;
            ArrayList retal = null;
            object paratype = new GoodsUCndtnWork();
            status = SearchGoodsURelationDataProc(out retal, null, null, paraList, readMode, logicalMode, ref sqlConnection);
            retCSAList.Add(retal);

            retObj = retCSAList;

            return status;
        }

        #endregion

        #region [Where���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="trgType">�擾�Ώۋ敪</param>
        /// <param name="goodsRelationDataWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2006.12.06</br>
        /// <br></br>
        /// <br>Update Note: 2007.08.27 ���� DC.NS�p�ɏC��</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, Type trgType, GoodsUCndtnWork goodsRelationDataWork, ConstantManagement.LogicalMode logicalMode)
        {
            string joinQuery = " LEFT JOIN BLGOODSCDURF ON GOODS.ENTERPRISECODERF = BLGOODSCDURF.ENTERPRISECODERF "
                        + "AND GOODS.BLGOODSCODERF = BLGOODSCDURF.BLGOODSCODERF LEFT JOIN BLGROUPURF "
                        + "ON BLGOODSCDURF.ENTERPRISECODERF = BLGROUPURF.ENTERPRISECODERF "
                        + "AND BLGOODSCDURF.BLGROUPCODERF = BLGROUPURF.BLGROUPCODERF ";
            string wkstring = string.Empty;
            StringBuilder whereString = new StringBuilder();
            whereString.Append("WHERE ");
            string maintable = "";

            maintable = "GOODS";
            //��ƃR�[�h
            whereString.Append(maintable + ".ENTERPRISECODERF=@ENTERPRISECODE ");
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsRelationDataWork.EnterpriseCode);

            //�_���폜�敪
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "AND " + maintable + ".LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "AND " + maintable + ".LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
            }
            if (wkstring != "")
            {
                whereString.Append(wkstring);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            //���i�R�[�h
            if (SqlDataMediator.SqlSetString(goodsRelationDataWork.GoodsNo) != DBNull.Value)
            {
                if (goodsRelationDataWork.GoodsNoSrchTyp != 0)
                {
                    //�n�C�t�������i�Ԃɕϊ�
                    string goodsNoNoneHyphen = goodsRelationDataWork.GoodsNo.Replace("-", "");

                    if (goodsRelationDataWork.GoodsNoSrchTyp != 4)
                    {
                        whereString.Append("AND GOODS.GOODSNONONEHYPHENRF LIKE @GOODSNONONEHYPHEN ");
                        //�O����v�����̏ꍇ
                        if (goodsRelationDataWork.GoodsNoSrchTyp == 1) goodsNoNoneHyphen = goodsNoNoneHyphen + "%";
                        //�����v�����̏ꍇ
                        if (goodsRelationDataWork.GoodsNoSrchTyp == 2) goodsNoNoneHyphen = "%" + goodsNoNoneHyphen;
                        //�����܂������̏ꍇ
                        if (goodsRelationDataWork.GoodsNoSrchTyp == 3) goodsNoNoneHyphen = "%" + goodsNoNoneHyphen + "%";

                    }
                    else
                    {
                        //�n�C�t�������i�Ԋ��S��v�����̏ꍇ
                        whereString.Append("AND GOODS.GOODSNONONEHYPHENRF=@GOODSNONONEHYPHEN ");
                    }

                    SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNONONEHYPHEN", SqlDbType.NChar);
                    paraGoodsNo.Value = SqlDataMediator.SqlSetString(goodsNoNoneHyphen);
                }
                else
                {
                    whereString.Append("AND GOODS.GOODSNORF=@GOODSNO ");

                    SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NChar);
                    paraGoodsNo.Value = SqlDataMediator.SqlSetString(goodsRelationDataWork.GoodsNo);
                }

            }

            //���[�J�[�R�[�h
            if (goodsRelationDataWork.GoodsMakerCd > 0)
            {
                whereString.Append("AND GOODS.GOODSMAKERCDRF=@GOODSMAKERCD ");
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsRelationDataWork.GoodsMakerCd);
            }

            //���i����
            if (string.IsNullOrEmpty(goodsRelationDataWork.GoodsName) == false)
            {
                whereString.Append("AND GOODS.GOODSNAMERF LIKE @GOODSNAME ");
                SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@GOODSNAME", SqlDbType.NVarChar);
                //�O����v�����̏ꍇ
                if (goodsRelationDataWork.GoodsNameSrchTyp == 1) goodsRelationDataWork.GoodsName = goodsRelationDataWork.GoodsName + "%";
                //�����v�����̏ꍇ
                if (goodsRelationDataWork.GoodsNameSrchTyp == 2) goodsRelationDataWork.GoodsName = "%" + goodsRelationDataWork.GoodsName;
                //�����܂������̏ꍇ
                if (goodsRelationDataWork.GoodsNameSrchTyp == 3) goodsRelationDataWork.GoodsName = "%" + goodsRelationDataWork.GoodsName + "%";
                paraGoodsName.Value = SqlDataMediator.SqlSetString(goodsRelationDataWork.GoodsName);
            }

            //���i���̃J�i
            if (string.IsNullOrEmpty(goodsRelationDataWork.GoodsNameKana) == false)
            {
                whereString.Append("AND GOODS.GOODSNAMEKANARF LIKE @GOODSNAMEKANA ");
                SqlParameter paraGoodsNameKana = sqlCommand.Parameters.Add("@GOODSNAMEKANA", SqlDbType.NVarChar);
                //�O����v�����̏ꍇ
                if (goodsRelationDataWork.GoodsNameKanaSrchTyp == 1) goodsRelationDataWork.GoodsNameKana = goodsRelationDataWork.GoodsNameKana + "%";
                //�����v�����̏ꍇ
                if (goodsRelationDataWork.GoodsNameKanaSrchTyp == 2) goodsRelationDataWork.GoodsNameKana = "%" + goodsRelationDataWork.GoodsNameKana;
                //�����܂������̏ꍇ
                if (goodsRelationDataWork.GoodsNameKanaSrchTyp == 3) goodsRelationDataWork.GoodsNameKana = "%" + goodsRelationDataWork.GoodsNameKana + "%";
                paraGoodsNameKana.Value = SqlDataMediator.SqlSetString(goodsRelationDataWork.GoodsNameKana);
            }

            //JAN�R�[�h
            if (string.IsNullOrEmpty(goodsRelationDataWork.Jan) == false)
            {
                whereString.Append("AND GOODS.JANRF=@JAN ");
                SqlParameter paraJan = sqlCommand.Parameters.Add("@JAN", SqlDbType.NVarChar);
                paraJan.Value = SqlDataMediator.SqlSetString(goodsRelationDataWork.Jan);
            }

            //BL���i�R�[�h
            if (goodsRelationDataWork.BLGoodsCode > 0)
            {
                whereString.Append("AND GOODS.BLGOODSCODERF=@BLGOODSCODE ");
                SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(goodsRelationDataWork.BLGoodsCode);
            }

            //���i�啪�ރR�[�h(BL�O���[�v���Q��)
            if (goodsRelationDataWork.GoodsLGroup > 0)
            {
                whereString.Append("AND BLGROUPURF.GOODSLGROUPRF=@GOODSLGROUP ");
                SqlParameter paraGoodsLGroup = sqlCommand.Parameters.Add("@GoodsLGroup", SqlDbType.Int);
                paraGoodsLGroup.Value = SqlDataMediator.SqlSetInt32(goodsRelationDataWork.GoodsLGroup);
            }

            //���i�����ރR�[�h
            if (goodsRelationDataWork.GoodsMGroup > 0)
            {
                whereString.Append("AND BLGROUPURF.GOODSMGROUPRF=@GOODSMGROUP ");
                SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@GOODSMGROUP", SqlDbType.Int);
                paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(goodsRelationDataWork.GoodsMGroup);
            }

            //�O���[�v�R�[�h
            if (goodsRelationDataWork.BLGroupCode > 0)
            {
                whereString.Append("AND BLGROUPURF.BLGROUPCODERF=@BLGROUPCODE ");
                SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@BLGROUPCODE", SqlDbType.Int);
                paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(goodsRelationDataWork.BLGroupCode);
            }

            //���i����
            if (goodsRelationDataWork.GoodsKindCode != 9)
            {
                whereString.Append("AND GOODS.GOODSKINDCODERF=@GOODSKINDCODE ");
                SqlParameter paraDetailGoodsKindCode = sqlCommand.Parameters.Add("@GOODSKINDCODE", SqlDbType.Int);
                paraDetailGoodsKindCode.Value = SqlDataMediator.SqlSetInt32(goodsRelationDataWork.GoodsKindCode);
            }
            string ret = string.Empty;
            if (goodsRelationDataWork.GoodsLGroup > 0 || goodsRelationDataWork.GoodsMGroup > 0 || goodsRelationDataWork.BLGroupCode > 0)
            {
                ret = joinQuery;
            }
            ret += whereString.ToString();
            return ret;
        }

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="trgType">�擾�Ώۋ敪</param>
        /// <param name="paraList">�����p�����[�^</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2006.12.06</br>
        /// <br></br>
        /// <br>Update Note: 2007.08.27 ���� DC.NS�p�ɏC��</br>
        private string MakeWhereStringMultiCondition(ref SqlCommand sqlCommand, Type trgType, ArrayList paraList, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = string.Empty;
            string countstr = string.Empty;
            StringBuilder retstring = new StringBuilder();
            retstring.Append("WHERE ");
            GoodsUCndtnWork wkcond = null;

            if (paraList == null || paraList.Count < 1)
                return string.Empty;

            wkcond = paraList[0] as GoodsUCndtnWork;

            //��ƃR�[�h
            retstring.Append("GOODS.ENTERPRISECODERF=@ENTERPRISECODE ");
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(wkcond.EnterpriseCode);

            //�_���폜�敪
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "AND GOODS.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "AND GOODS.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
            }
            if (wkstring != "")
            {
                retstring.Append(wkstring);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            for (int i = 0; i < paraList.Count; i++)
            {
                wkcond = paraList[i] as GoodsUCndtnWork;
                countstr = i.ToString();
                if (wkstring != "") wkstring += "OR ";
                wkstring += "( GOODS.GOODSMAKERCDRF=@GOODSMAKERCD" + countstr + " AND GOODS.GOODSNONONEHYPHENRF LIKE @GOODSNONONEHYPHEN" + countstr + " ) ";

                //���[�J�[�R�[�h
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD" + countstr, SqlDbType.Int);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(wkcond.GoodsMakerCd);

                //���i�R�[�h
                SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNONONEHYPHEN" + countstr, SqlDbType.NChar);


                if (SqlDataMediator.SqlSetString(wkcond.GoodsNo) != DBNull.Value)
                {
                    paraGoodsNo.Value = SqlDataMediator.SqlSetString(wkcond.GoodsNo);
                }
                else
                {
                    paraGoodsNo.Value = "";
                }
            }
            retstring.Append(wkstring);

            return retstring.ToString();
        }
        #endregion

        #region [�N���X�i�[����]

        #region [���i�A���f�[�^�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� GoodsUnitDataWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="optKonmanGoodsMstCtl">���i�}�X�^�\���p�I�v�V����</param>
        /// <returns>GoodsUnitDataWork</returns>
        /// <remarks>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2006.12.06</br>
        /// <br></br>
        /// <br>Update Note: 2007.08.27 ���� DC.NS�p�ɏC��</br>
        /// <br>Update Note: 2014/02/10 ���z</br>
        /// <br>           : Redmine#41976 ���i�}�X�^�U�̒ǉ�</br>
        /// </remarks>
        //private GoodsUnitDataWork CopyToGoodsUnitDataWorkFromReader(ref SqlDataReader myReader)// DEL 2014.02.10 ���z
        private GoodsUnitDataWork CopyToGoodsUnitDataWorkFromReader(ref SqlDataReader myReader, bool optKonmanGoodsMstCtl)// ADD 2014.02.10 ���z
        {
            GoodsUnitDataWork wkGoodsUnitDataWork = new GoodsUnitDataWork();

            #region �N���X�֊i�[
            wkGoodsUnitDataWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkGoodsUnitDataWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkGoodsUnitDataWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkGoodsUnitDataWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkGoodsUnitDataWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkGoodsUnitDataWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkGoodsUnitDataWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkGoodsUnitDataWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkGoodsUnitDataWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            wkGoodsUnitDataWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            wkGoodsUnitDataWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            wkGoodsUnitDataWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
            wkGoodsUnitDataWork.Jan = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JANRF"));
            wkGoodsUnitDataWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            wkGoodsUnitDataWork.DisplayOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF"));
            wkGoodsUnitDataWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));
            wkGoodsUnitDataWork.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));
            wkGoodsUnitDataWork.GoodsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNONONEHYPHENRF"));
            wkGoodsUnitDataWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
            wkGoodsUnitDataWork.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSKINDCODERF"));
            wkGoodsUnitDataWork.GoodsNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNOTE1RF"));
            wkGoodsUnitDataWork.GoodsNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNOTE2RF"));
            wkGoodsUnitDataWork.GoodsSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSSPECIALNOTERF"));
            wkGoodsUnitDataWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));
            wkGoodsUnitDataWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));
            wkGoodsUnitDataWork.OfferDataDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATADIVRF"));
            // -------- ADD START 2014/02/10 ���z -------->>>>>
            // ���i�}�X�^�\���p�I�v�V��������
            if (optKonmanGoodsMstCtl)
            {
                wkGoodsUnitDataWork.Standard = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STANDARDRF"));
                wkGoodsUnitDataWork.Packing = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PACKINGRF"));
                wkGoodsUnitDataWork.PosNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("POSNORF"));
                wkGoodsUnitDataWork.MakerGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERGOODSNORF"));
                wkGoodsUnitDataWork.CreateDateTimeA = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMEARF"));
                wkGoodsUnitDataWork.UpdateDateTimeA = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMEARF"));
                wkGoodsUnitDataWork.FileHeaderGuidA = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDARF"));
            }
            // -------- ADD END 2014/02/10 ���z --------<<<<<
            #endregion

            return wkGoodsUnitDataWork;
        }

        #region [�d�l�ύX�ɂ��ȉ����R�����g����]
        /*
        private GoodsUnitDataWork CopyToGoodsUnitDataWorkFromReader(ref SqlDataReader myReader)
        {
            GoodsUnitDataWork wkGoodsUnitDataWork = new GoodsUnitDataWork();

            #region �N���X�֊i�[
            wkGoodsUnitDataWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkGoodsUnitDataWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkGoodsUnitDataWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkGoodsUnitDataWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkGoodsUnitDataWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkGoodsUnitDataWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkGoodsUnitDataWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkGoodsUnitDataWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkGoodsUnitDataWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            wkGoodsUnitDataWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAME"));
            wkGoodsUnitDataWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            wkGoodsUnitDataWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            wkGoodsUnitDataWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
            wkGoodsUnitDataWork.Jan = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JANRF"));
            wkGoodsUnitDataWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            wkGoodsUnitDataWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
            wkGoodsUnitDataWork.DisplayOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF"));
            wkGoodsUnitDataWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSLGROUP"));
            wkGoodsUnitDataWork.GoodsLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSLGROUPNAME"));
            wkGoodsUnitDataWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUP"));
            wkGoodsUnitDataWork.GoodsMGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMGROUPNAME"));
            wkGoodsUnitDataWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODE"));
            wkGoodsUnitDataWork.BLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPNAME"));
            wkGoodsUnitDataWork.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));
            wkGoodsUnitDataWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));
            wkGoodsUnitDataWork.GoodsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNONONEHYPHENRF"));
            wkGoodsUnitDataWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
            wkGoodsUnitDataWork.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSKINDCODERF"));
            wkGoodsUnitDataWork.GoodsNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNOTE1RF"));
            wkGoodsUnitDataWork.GoodsNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNOTE2RF"));
            wkGoodsUnitDataWork.GoodsSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSSPECIALNOTERF"));
            wkGoodsUnitDataWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));
            wkGoodsUnitDataWork.EnterpriseGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISEGANRENAME"));
            wkGoodsUnitDataWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));
            wkGoodsUnitDataWork.GoodsRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSRATEGRPCODERF"));
            wkGoodsUnitDataWork.SalesCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCODERF"));
            wkGoodsUnitDataWork.GoodsPriceCreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("GOODSPCREATEDATETIME"));
            wkGoodsUnitDataWork.GoodsPriceUpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("GOODSPUPDATEDATETIME"));
            wkGoodsUnitDataWork.GoodsPriceEnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSPENTERPRISECODE"));
            wkGoodsUnitDataWork.GoodsPriceFileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("GOODSPFILEHEADERGUID"));
            wkGoodsUnitDataWork.GoodsPriceUpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSPUPDEMPLOYEECODE"));
            wkGoodsUnitDataWork.GoodsPriceUpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSPUPDASSEMBLYID1"));
            wkGoodsUnitDataWork.GoodsPriceUpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSPUPDASSEMBLYID2"));
            wkGoodsUnitDataWork.GoodsPricePriceStartDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("GOODSPPRICESTARTDATE"));
            wkGoodsUnitDataWork.GoodsPriceListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GOODSPLISTPRICE"));
            wkGoodsUnitDataWork.GoodsPriceSalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GOODSPSALESUNITCOST"));
            wkGoodsUnitDataWork.GoodsPriceStockRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GOODSPSTOCKRATE"));
            wkGoodsUnitDataWork.GoodsPriceOpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSPOPENPRICEDIV"));
            wkGoodsUnitDataWork.GoodsPriceOfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("GOODSPOFFERDATE"));
            wkGoodsUnitDataWork.GoodsPriceUpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("GOODSPUPDATEDATE"));
            wkGoodsUnitDataWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODE"));
            wkGoodsUnitDataWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAME"));
            wkGoodsUnitDataWork.ShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTPOSCNT"));
            wkGoodsUnitDataWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNO"));
            #endregion

            return wkGoodsUnitDataWork;
        }
        */
        #endregion
        #endregion

        #endregion

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2006.12.06</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (string.IsNullOrEmpty(connectionText)) return null;

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion

        #region ���i�n�f�[�^���ꊇ���Ĉ�������
        /// <summary>
        /// ���i�E���i�E�݌Ɂ^��ց^�����^�Z�b�g�̓o�^�E�X�V���s���܂��B
        /// ��ւȂǂł͌�����2���i�����i�[���邽��
        /// �i���i�E���i�E�݌Ɂj���̂�ArrayList�ɐݒ肵�A���̏��͒���CustomSerializeArrayList��Add����B
        /// </summary>
        /// <param name="goodsWork">GoodsWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2006.12.08</br>
        /// <br></br>
        /// <br>Update Note: 2007.08.27 ���� DC.NS�p�ɏC��</br>
        public int WriteRelation(ref object goodsWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            CustomSerializeArrayList retList = new CustomSerializeArrayList();
            try
            {
                //�p�����[�^�̃L���X�g
                CustomSerializeArrayList csaList = goodsWork as CustomSerializeArrayList;
                if (csaList == null || csaList.Count == 0)
                    return (int)ConstantManagement.MethodResult.ctFNC_ERROR;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null)
                    return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //status = WriteRelationProc(csaList, ref retList, sqlConnection, sqlTransaction);    // DEL huangt 2014/01/15 Redmine#40998 �ݏo���̕ύX���\�ɂ���悤�ɏC�� 
                status = WriteRelationProc(csaList, ref retList, sqlConnection, sqlTransaction, false);    // ADD huangt 2014/01/15 Redmine#40998 �ݏo���̕ύX���\�ɂ���悤�ɏC�� 

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)    // �R�~�b�g
                {
                    sqlTransaction.Commit();
                }
                else�@  // ���[���o�b�N
                {
                    if (sqlTransaction.Connection != null)
                        sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsDB.Write(ref object goodsWork)");
                // ���[���o�b�N
                if (sqlTransaction.Connection != null)
                    sqlTransaction.Rollback();
            }
            finally
            {
                goodsWork = retList;
                if (sqlTransaction != null)
                    sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        // ----- ADD huangt 2014/01/15 Redmine#40998 �ݏo���̕ύX���\�ɂ���悤�ɏC�� ----- >>>>>
        /// <summary>
        /// ���i�E���i�E�݌Ɂ^��ց^�����^�Z�b�g�̓o�^�E�X�V���s���܂��B
        /// ��ւȂǂł͌�����2���i�����i�[���邽��
        /// �i���i�E���i�E�݌Ɂj���̂�ArrayList�ɐݒ肵�A���̏��͒���CustomSerializeArrayList��Add����B
        /// </summary>
        /// <param name="goodsWork">GoodsWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2014/01/15</br>
        /// <br></br>
        public int WriteRelationForShipmentCnt(ref object goodsWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            CustomSerializeArrayList retList = new CustomSerializeArrayList();
            try
            {
                //�p�����[�^�̃L���X�g
                CustomSerializeArrayList csaList = goodsWork as CustomSerializeArrayList;
                if (csaList == null || csaList.Count == 0)
                    return (int)ConstantManagement.MethodResult.ctFNC_ERROR;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null)
                    return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = WriteRelationProc(csaList, ref retList, sqlConnection, sqlTransaction, true);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)    // �R�~�b�g
                {
                    sqlTransaction.Commit();
                }
                else�@  // ���[���o�b�N
                {
                    if (sqlTransaction.Connection != null)
                        sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UsrJoinPartsSearchDB.WriteRelationForShipmentCnt(ref object goodsWork)");
                // ���[���o�b�N
                if (sqlTransaction.Connection != null)
                    sqlTransaction.Rollback();
            }
            finally
            {
                goodsWork = retList;
                if (sqlTransaction != null)
                    sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                }
            }

            return status;
        }
        // ----- ADD huangt 2014/01/15 Redmine#40998 �ݏo���̕ύX���\�ɂ���悤�ɏC�� ----- <<<<<

        /// <summary>
        /// ���i�E���i�E�݌Ɂ^��ց^�����^�Z�b�g�̓o�^�E�X�V���s���܂��B
        /// ��ւȂǂł͌�����2���i�����i�[���邽��
        /// �i���i�E���i�E�݌Ɂj���̂�ArrayList�ɐݒ肵�A���̏��͒���CustomSerializeArrayList��Add����B
        /// </summary>
        /// <param name="csaList">�X�V�Ώۃ��X�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        public int WriteRelationProc(ref CustomSerializeArrayList csaList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            CustomSerializeArrayList retList = new CustomSerializeArrayList();
            //int status = WriteRelationProc(csaList, ref retList, sqlConnection, sqlTransaction);   // DEL huangt 2014/01/15 Redmine#40998 �ݏo���̕ύX���\�ɂ���悤�ɏC�� 
            int status = WriteRelationProc(csaList, ref retList, sqlConnection, sqlTransaction, false);    // ADD huangt 2014/01/15 Redmine#40998 �ݏo���̕ύX���\�ɂ���悤�ɏC��
            csaList = retList;
            return status;
        }

        //private int WriteRelationProc(CustomSerializeArrayList csaList, ref CustomSerializeArrayList retList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)      // DEL huangt 2014/01/15 Redmine#40998 �ݏo���̕ύX���\�ɂ���悤�ɏC�� 
        private int WriteRelationProc(CustomSerializeArrayList csaList, ref CustomSerializeArrayList retList, SqlConnection sqlConnection, SqlTransaction sqlTransaction, bool shipmentCntChangeFlg)        // ADD huangt 2014/01/15 Redmine#40998 �ݏo���̕ύX���\�ɂ���悤�ɏC��
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            retList = new CustomSerializeArrayList();

            status = 0; // �ŏ��̏����̂��߁A�X�e�[�^�X0��ݒ肵�Ă����B

            ArrayList goodsList = new ArrayList();
            ArrayList goodsPriceList = new ArrayList();
            ArrayList goodsStockList = new ArrayList();
            //ArrayList StockAdjustList = null;
            //ArrayList StockAdjustDtlList = null;
            ArrayList RateWork = new ArrayList();

            // �V�X�e�����b�N(�q��) //2009/1/27 Add sakurai >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            ArrayList infoList = new ArrayList(); //�V�F�A�`�F�b�N��񃊃X�g
            Dictionary<string, string> dic = new Dictionary<string, string>(); //�q�Ƀ��X�g 
            string _enterPriseCode = string.Empty;
            for (int i = 0; i < csaList.Count; i++)
            {
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) // �e�����̐擪�ł��̃`�F�b�N�ɂ��
                    break; // DB�ُ�ɂȂ��Ă���͏����������A���[���o�b�N����悤�ɂȂ�B
                Type wktype = csaList[i].GetType();
                switch (wktype.Name)
                {
                    case "CustomSerializeArrayList":
                        {
                            foreach (ArrayList csList in  csaList[i] as CustomSerializeArrayList)
                            {
                                ArrayList stworkList = ListUtils.Find(csList, typeof(StockAdjustDtlWork), ListUtils.FindType.Array) as ArrayList;

                                if (stworkList == null) continue; //�݌ɒ������ׂ��Ȃ��ꍇ�͐��ʂ̕ϓ��͂Ȃ�

                                foreach(StockAdjustDtlWork stwork in stworkList)
                                {
                                    if (stwork != null)
                                    {
                                        if (dic.ContainsKey(stwork.WarehouseCode) == false)
                                        {
                                            _enterPriseCode = stwork.EnterpriseCode;
                                            dic.Add(stwork.WarehouseCode, stwork.WarehouseCode);
                                        }
                                    }

                                }

                            }
                        }
                        break;
                }
            }
            foreach (string wCode in dic.Keys)
            {
                ShareCheckInfo info = new ShareCheckInfo();
                info.Keys.Add(_enterPriseCode, ShareCheckType.WareHouse, "", wCode);
                status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);
                infoList.Add(info);
                if (status != 0) return status;
            }
            // �V�X�e�����b�N(�q��) //2009/1/27 Add sakurai <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            CustomSerializeArrayList stockAdjustCsList = null;


            for (int i = 0; i < csaList.Count; i++)
            {
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) // �e�����̐擪�ł��̃`�F�b�N�ɂ��
                    break; // DB�ُ�ɂȂ��Ă���͏����������A���[���o�b�N����悤�ɂȂ�B
                Type wktype = csaList[i].GetType();
                switch (wktype.Name)
                {
                    case "ArrayList": // ArrayList�ɐݒ肳���̂͏��i���݂̂ƋK�񂷂�B
                        #region [ CustomSerializeArrayList���ɂ����ArrayList�̏ꍇ ]
                        {
                            ArrayList wkal = csaList[i] as ArrayList;

                            if (wkal.Count == 0)
                                continue;
                            Type wktype2 = wkal[0].GetType();

                            switch (wktype2.Name)
                            {
                                case "GoodsUnitDataWork": // ���i
                                    #region [ ���i ]
                                    {
                                        //���i�}�X�^
                                        CopyToGoodsAndPriceWork(wkal, ref goodsList, ref goodsPriceList, ref goodsStockList, true);
                                        //���i�}�X�^�X�V����
                                        if (goodsList != null)
                                        {
                                            GoodsUDB goodsUDB = new GoodsUDB();
                                            status = goodsUDB.WriteGoodsUProc(ref goodsList, ref sqlConnection, ref sqlTransaction);
                                        }

                                        //���i�}�X�^�X�V����
                                        if (goodsPriceList != null && goodsPriceList.Count > 0 && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                        {
                                            ArrayList writeErrorList = new ArrayList();
                                            GoodsPriceUDB goodsPriceDB = new GoodsPriceUDB();
                                            //int indPrice = 0;
                                            //foreach (GoodsUnitDataWork goodsUnitDataWork in wkal)
                                            //{
                                            //for (; indPrice < goodsPriceList.Count; indPrice++)
                                            for (int indPrice = 0; indPrice < goodsPriceList.Count; indPrice++)
                                            {
                                                GoodsPriceUWork tmp = goodsPriceList[indPrice] as GoodsPriceUWork;
                                                //if (goodsUnitDataWork.GoodsMakerCd == tmp.GoodsMakerCd &&
                                                //    goodsUnitDataWork.GoodsNo == tmp.GoodsNo)
                                                //{
                                                DeleteOldPrice(tmp, ref sqlConnection, ref sqlTransaction);
                                                //    break;
                                                //}
                                            }
                                            //}

                                            status = goodsPriceDB.WriteGoodsPriceProc(ref goodsPriceList, out writeErrorList, ref sqlConnection, ref sqlTransaction);
                                        }

                                        //�݌Ƀ}�X�^�X�V���� 
                                        //if ((goodsStockList != null && goodsStockList.Count > 0) && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                        //{
                                        //    StockDB goodsStockDB = new StockDB();
                                        //    status = goodsStockDB.WriteStockProc(ref goodsStockList, ref sqlConnection, ref sqlTransaction);
                                        //}

                                        //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                        //{
                                        //    //�߂�l�Z�b�g
                                        //    retList.Add(CopyToGoodsUnitDataList(goodsList, goodsPriceList, goodsStockList));
                                        //}
                                    }
                                    break;
                                    #endregion
                                case "JoinPartsUWork": // ����
                                    #region [ ���� ]
                                    {
                                        JoinPartsUDB joinPartsUDB = new JoinPartsUDB();
                                        JoinPartsUWork tmp = (JoinPartsUWork)wkal[0];
                                        //status = joinPartsUDB.Write(ref wkal, ref sqlConnection, ref sqlTransaction);
                                        status = joinPartsUDB.DeleteInsert(ref wkal, tmp.EnterpriseCode, tmp.JoinSourceMakerCode, tmp.JoinSourPartsNoWithH,
                                                ref sqlConnection, ref sqlTransaction);

                                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                        {
                                            retList.Add(wkal);
                                        }

                                    }
                                    break;
                                    #endregion
                                case "GoodsSetWork": // ���i�Z�b�g
                                    #region [ ���i�Z�b�g ]
                                    {
                                        GoodsSetDB goodsSetDB = new GoodsSetDB();
                                        GoodsSetWork tmp = (GoodsSetWork)wkal[0];
                                        //status = goodsSetDB.WriteGoodsSetProc(ref wkal, ref sqlConnection, ref sqlTransaction);
                                        status = goodsSetDB.DeleteInsert(ref wkal, tmp.EnterpriseCode, tmp.ParentGoodsMakerCd, tmp.ParentGoodsNo,
                                                ref sqlConnection, ref sqlTransaction);

                                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                        {
                                            retList.Add(wkal);
                                        }
                                    }
                                    break;
                                    #endregion
                                //case "StockAdjustWork": // �݌ɒ����f�[�^���[�N
                                //    #region [ �݌ɒ����f�[�^���[�N ]
                                //    {
                                //        StockAdjustList = wkal;
                                //    }
                                //    break;
                                //    #endregion
                                //case "StockAdjustDtlWork": // �݌ɒ������׃f�[�^���[�N
                                //    #region [ �݌ɒ������׃f�[�^���[�N ]
                                //    {
                                //        StockAdjustDtlList = wkal;
                                //    }
                                //    break;
                                //    #endregion
                                case "RateWork": // �|�����[�N
                                    #region [ �|�����[�N ]
                                    RateDB rateDB = new RateDB();
                                    status = rateDB.WriteSubSectionProc(ref wkal, ref sqlConnection, ref sqlTransaction);
                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        retList.Add(wkal);
                                    }
                                    break;
                                    #endregion
                                case "TBOSearchUWork": // TBO
                                    #region [ TBO ]
                                    {
                                        TBOSearchUDB tBOSearchUDB = new TBOSearchUDB();
                                        TBOSearchUWork tmp = (TBOSearchUWork)wkal[0];
                                        status = tBOSearchUDB.DeleteInsert(ref wkal, tmp.EnterpriseCode, tmp.EquipGenreCode, tmp.EquipName,
                                                ref sqlConnection, ref sqlTransaction);

                                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                        {
                                            retList.Add(wkal);
                                        }
                                    }
                                    break;
                                    #endregion
                            }
                        }
                        break;
                        #endregion

                    case "PartsSubstUWork":
                        #region [ ���i��� ]
                        { // ���i���
                            PartsSubstUDB partsSubstUDB = new PartsSubstUDB();
                            ArrayList retal = new ArrayList();
                            PartsSubstUWork partsSubstUWork = csaList[i] as PartsSubstUWork;
                            retal.Add(partsSubstUWork);
                            status = partsSubstUDB.Write(ref retal, ref sqlConnection, ref sqlTransaction);

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retList.Add(retal[0] as PartsSubstUWork);
                            }
                        }
                        break;
                        #endregion

                    case "JoinPartsUWork":
                        #region [ ���� ]
                        {// ����
                            JoinPartsUDB joinPartsUDB = new JoinPartsUDB();
                            ArrayList retal = new ArrayList();
                            JoinPartsUWork joinPartsUWork = csaList[i] as JoinPartsUWork;
                            retal.Add(joinPartsUWork);
                            status = joinPartsUDB.Write(ref retal, ref sqlConnection, ref sqlTransaction);

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retList.Add(retal[0] as JoinPartsUWork);
                            }
                        }
                        break;
                        #endregion

                    case "GoodsSetWork":
                        #region [ ���i�Z�b�g ]
                        {// ���i�Z�b�g
                            GoodsSetDB goodsSetDB = new GoodsSetDB();
                            ArrayList retal = new ArrayList();
                            GoodsSetWork goodsSetWork = csaList[i] as GoodsSetWork;
                            retal.Add(goodsSetWork);
                            status = goodsSetDB.WriteGoodsSetProc(ref retal, ref sqlConnection, ref sqlTransaction);

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retList.Add(retal[0] as GoodsSetWork);
                            }
                        }
                        break;
                        #endregion
                    case "CustomSerializeArrayList": // �݌ɒ����f�[�^
                        #region [ �݌ɒ����f�[�^,�݌ɒ������׃f�[�^�A�݌Ƀf�[�^ ]
                        {
                            stockAdjustCsList = csaList[i] as CustomSerializeArrayList;
                        }
                        break;
                        #endregion

                    //Add Start 2012/12/01 zhangy3 for Redmine#33231 ----->>>>>
                    case "GoodsMngWork"://���i���Ǘ�
                        #region [ ���i���Ǘ� ]
                        {
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                GoodsMngDB goodsMngDB = new GoodsMngDB();
                                GoodsMngWork goodsMngWork = csaList[i] as GoodsMngWork;
                                int SupplierCd = goodsMngWork.SupplierCd;
                                string supplierSnm = goodsMngWork.SupplierSnm; // ADD 2013/08/13 �c���� Redmdine#39794
                                int EditLogicalDeleteCode = goodsMngWork.LogicalDeleteCode;
                                GoodsMngWork serGoodsMngWork = goodsMngWork.Clone();
                                if (goodsMngWork.CreateDateTime.Equals(DateTime.MinValue))
                                {
                                    goodsMngDB.ReadProc(ref serGoodsMngWork, 0, ref sqlConnection, ref sqlTransaction);
                                }
                                if (serGoodsMngWork != null && serGoodsMngWork.SupplierCd != 0)
                                {
                                    goodsMngWork = serGoodsMngWork;
                                    goodsMngWork.SupplierCd = SupplierCd;
                                    goodsMngWork.SupplierSnm = supplierSnm; // ADD 2013/08/13 �c���� Redmdine#39794
                                    goodsMngWork.LogicalDeleteCode = 0;
                                }
                                ArrayList arr = new ArrayList();
                                arr.Add(goodsMngWork);
                                if (EditLogicalDeleteCode == 3)
                                {
                                    status = goodsMngDB.DeleteGoodsMngProc(arr, ref sqlConnection, ref sqlTransaction);
                                }
                                else
                                {
                                    status = goodsMngDB.WriteGoodsMngProc(ref arr, ref sqlConnection, ref sqlTransaction);
                                }

                                //----- ADD 2013/08/13 �c���� Redmdine#39794 ----->>>>>
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    if (EditLogicalDeleteCode != 3)
                                    {
                                        retList.Add(arr[0] as GoodsMngWork);
                                    }
                                }
                                //----- ADD 2013/08/13 �c���� Redmdine#39794 -----<<<<<
                            }
                        }
                        break;
                        #endregion
                    //Add End   2012/12/01 zhangy3 for Redmine#33231 -----<<<<<
                }
            }
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (!shipmentCntChangeFlg)�@�@�@// ADD huangt 2014/01/15 Redmine#40998 �ݏo���̕ύX���\�ɂ���悤�ɏC��
                {   // ADD huangt 2014/01/15 Redmine#40998 �ݏo���̕ύX���\�ɂ���悤�ɏC��
                //if (goodsStockList.Count > 0)// && StockAdjustList != null && StockAdjustDtlList != null)
                if (stockAdjustCsList != null)// && StockAdjustList != null && StockAdjustDtlList != null)
                {
                    string retMsg;
                    //CustomSerializeArrayList lstStock = new CustomSerializeArrayList();
                    //lstStock.Add(goodsStockList);
                    //if (StockAdjustList != null)
                    //{
                    //    lstStock.Add(StockAdjustList);
                    //    lstStock.Add(StockAdjustDtlList);
                    //}
                    //object objStockAdjustCustList = lstStock;

                    object objStockAdjustCustList = stockAdjustCsList;

                    StockAdjustDB stockAdjustDB = new StockAdjustDB();
                    status = stockAdjustDB.WriteBatch(ref objStockAdjustCustList, out retMsg, ref sqlConnection, ref sqlTransaction);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        stockAdjustCsList = objStockAdjustCustList as CustomSerializeArrayList;
                        goodsStockList.Clear();

                        for (int i = 0; i < stockAdjustCsList.Count; i++)
                        {
                            ArrayList retStockList = ListUtils.Find(stockAdjustCsList[i] as CustomSerializeArrayList, typeof(StockWork), ListUtils.FindType.Array) as ArrayList;

                            foreach (StockWork stockWork in retStockList)
                            {
                                //�݌Ɏd�������[�g���Ԃ��ꂽ�݌Ƀ��X�g�ɍX�V����
                                goodsStockList.Add(stockWork);
                            }

                            //if (lstStock[i] is ArrayList && ((ArrayList)lstStock[i])[0] is StockWork)
                            //{
                            //    goodsStockList = (ArrayList)lstStock[i];
                            //    break;
                            //}
                        }

                        //�߂�l�Z�b�g
                        //retList.Add(CopyToGoodsUnitDataList(goodsList, goodsPriceList, goodsStockList)); // DEL 2013/02/08 �c���� Redmine#34640
                        //----- ADD 2013/02/08 �c���� Redmine#34640 ---------->>>>>
                        if (goodsList.Count == 0)
                        {
                            if (goodsStockList.Count > 0)
                            {
                                retList.Add(goodsStockList);
                            }
                        }
                        else
                        {
                            retList.Add(CopyToGoodsUnitDataList(goodsList, goodsPriceList, goodsStockList));
                        }
                        //----- ADD 2013/02/08 �c���� Redmine#34640 ----------<<<<<
                    }
                }
                else
                {
                    //�߂�l�Z�b�g
                    retList.Add(CopyToGoodsUnitDataList(goodsList, goodsPriceList, goodsStockList));
                }
                // ----- ADD huangt 2014/01/15 Redmine#40998 �ݏo���̕ύX���\�ɂ���悤�ɏC�� ----- >>>>>
                }
                else
                {
                    // �ݏo���ύX�̏ꍇ
                    if (goodsStockList != null)
                    {
                        StockDB stockDB = new StockDB();
                        string retMsg;
                        stockDB.WriteStock(ref goodsStockList, ref sqlConnection, ref sqlTransaction, out retMsg);

                    }
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        //�߂�l�Z�b�g
                        retList.Add(CopyToGoodsUnitDataList(goodsList, goodsPriceList, goodsStockList));
                    }
                }
                // ----- ADD huangt 2014/01/15 Redmine#40998 �ݏo���̕ύX���\�ɂ���悤�ɏC�� ----- <<<<<
            }

            // �V�X�e�����b�N����(�q��) //2009/1/27 Add sakurai >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //�X�V���̔r���G���[�����邽�߁A�V�F�A�`�F�b�N�͕ʂ̃X�e�[�^�X�Ƃ���
            int chkstatus = 0;

            foreach (ShareCheckInfo info in infoList)
            {
                chkstatus = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);
            }
            
            //�X�V�̃G���[������ꍇ�́A�������D�悵�Ė߂�l�Ƃ���
            if (status == 0)
            {
                status = chkstatus;
            }
            // �V�X�e�����b�N����(�q��) //2009/1/27 Add sakurai <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            return status;
        }

        private int DeleteOldPrice(GoodsPriceUWork GoodsPriceUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            SqlCommand sqlCommand = null;
            int status = 0;
            try
            {
                string sqlText = "DELETE" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  GOODSPRICEURF" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                sqlText += "  AND GOODSNORF = @FINDGOODSNO" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);
                sqlCommand.CommandText = sqlText;

                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                //KEY�R�}���h���Đݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.EnterpriseCode);
                findParaMakerCd.Value = SqlDataMediator.SqlSetInt32(GoodsPriceUWork.GoodsMakerCd);
                findParaGoodsNo.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.GoodsNo);
                status = sqlCommand.ExecuteNonQuery();
            }
            catch
            {
            }
            finally
            {
                sqlCommand.Dispose();
            }
            return status;
        }

        /// <summary>
        /// GoodsUWork,GoodsPriceUWork �� �A���N���X 
        /// </summary>
        /// <param name="goodsList">���i�}�X�^���X�g</param>
        /// <param name="goodsPriceList">���i���i���X�g</param>
        /// <param name="goodsStockList">���i�݌Ƀ��X�g(��񂪂Ȃ��Ƃ���NULL)</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2007.08.27</br>
        /// <br>Update Note: 2014/02/10 ���z Redmine#41976 ���i�}�X�^�U�̒ǉ�</br>
        /// </remarks>
        private ArrayList CopyToGoodsUnitDataList(ArrayList goodsList, ArrayList goodsPriceList, ArrayList goodsStockList)
        {
            ArrayList al = new ArrayList();

            foreach (GoodsUWork goodsUWork in goodsList)
            {
                GoodsUnitDataWork goodsUnitDataWork = new GoodsUnitDataWork();

                //���i�}�X�^
                goodsUnitDataWork.CreateDateTime = goodsUWork.CreateDateTime;
                goodsUnitDataWork.UpdateDateTime = goodsUWork.UpdateDateTime;
                goodsUnitDataWork.EnterpriseCode = goodsUWork.EnterpriseCode;
                goodsUnitDataWork.FileHeaderGuid = goodsUWork.FileHeaderGuid;
                goodsUnitDataWork.UpdEmployeeCode = goodsUWork.UpdEmployeeCode;
                goodsUnitDataWork.UpdAssemblyId1 = goodsUWork.UpdAssemblyId1;
                goodsUnitDataWork.UpdAssemblyId2 = goodsUWork.UpdAssemblyId2;
                goodsUnitDataWork.LogicalDeleteCode = goodsUWork.LogicalDeleteCode;
                goodsUnitDataWork.GoodsMakerCd = goodsUWork.GoodsMakerCd;
                goodsUnitDataWork.GoodsNo = goodsUWork.GoodsNo;
                goodsUnitDataWork.GoodsName = goodsUWork.GoodsName;
                goodsUnitDataWork.GoodsNameKana = goodsUWork.GoodsNameKana;
                goodsUnitDataWork.Jan = goodsUWork.Jan;
                goodsUnitDataWork.BLGoodsCode = goodsUWork.BLGoodsCode;
                goodsUnitDataWork.DisplayOrder = goodsUWork.DisplayOrder;
                goodsUnitDataWork.TaxationDivCd = goodsUWork.TaxationDivCd;
                goodsUnitDataWork.GoodsRateRank = goodsUWork.GoodsRateRank;
                goodsUnitDataWork.GoodsNoNoneHyphen = goodsUWork.GoodsNoNoneHyphen;
                goodsUnitDataWork.OfferDate = goodsUWork.OfferDate;
                goodsUnitDataWork.GoodsKindCode = goodsUWork.GoodsKindCode;
                goodsUnitDataWork.GoodsNote1 = goodsUWork.GoodsNote1;
                goodsUnitDataWork.GoodsNote2 = goodsUWork.GoodsNote2;
                goodsUnitDataWork.GoodsSpecialNote = goodsUWork.GoodsSpecialNote;
                goodsUnitDataWork.EnterpriseGanreCode = goodsUWork.EnterpriseGanreCode;
                goodsUnitDataWork.UpdateDate = goodsUWork.UpdateDate;
                goodsUnitDataWork.OfferDataDiv = goodsUWork.OfferDataDiv;
                // -------- ADD START 2014/02/10 ���z -------->>>>>
                goodsUnitDataWork.OptKonmanGoodsMstCtl = goodsUWork.OptKonmanGoodsMstCtl;
                goodsUnitDataWork.Standard = goodsUWork.Standard;
                goodsUnitDataWork.Packing = goodsUWork.Packing;
                goodsUnitDataWork.PosNo = goodsUWork.PosNo;
                goodsUnitDataWork.MakerGoodsNo = goodsUWork.MakerGoodsNo;
                goodsUnitDataWork.CreateDateTimeA = goodsUWork.CreateDateTimeA;
                goodsUnitDataWork.UpdateDateTimeA = goodsUWork.UpdateDateTimeA;
                goodsUnitDataWork.FileHeaderGuidA = goodsUWork.FileHeaderGuidA;
                // -------- ADD END 2014/02/10 ���z --------<<<<<

                goodsUnitDataWork.PriceList = new ArrayList();
                //���i�}�X�^�X�V���ڃZ�b�g
                foreach (GoodsPriceUWork goodsPrice in goodsPriceList)
                {
                    if (goodsPrice.PriceStartDate != DateTime.MinValue &&
                        goodsUnitDataWork.GoodsNo == goodsPrice.GoodsNo &&
                        goodsUnitDataWork.GoodsMakerCd == goodsPrice.GoodsMakerCd)
                    {
                        //UsrGoodsPriceWork goodsPriceUWork = new UsrGoodsPriceWork();
                        GoodsPriceUWork goodsPriceUWork = new GoodsPriceUWork();

                        goodsPriceUWork.CreateDateTime = goodsPrice.CreateDateTime;
                        goodsPriceUWork.UpdateDateTime = goodsPrice.UpdateDateTime;
                        goodsPriceUWork.EnterpriseCode = goodsPrice.EnterpriseCode;
                        goodsPriceUWork.FileHeaderGuid = goodsPrice.FileHeaderGuid;
                        goodsPriceUWork.UpdEmployeeCode = goodsPrice.UpdEmployeeCode;
                        goodsPriceUWork.UpdAssemblyId1 = goodsPrice.UpdAssemblyId1;
                        goodsPriceUWork.UpdAssemblyId2 = goodsPrice.UpdAssemblyId2;
                        goodsPriceUWork.LogicalDeleteCode = goodsPrice.LogicalDeleteCode;
                        goodsPriceUWork.GoodsNo = goodsPrice.GoodsNo;
                        goodsPriceUWork.GoodsMakerCd = goodsPrice.GoodsMakerCd;
                        goodsPriceUWork.PriceStartDate = goodsPrice.PriceStartDate;
                        goodsPriceUWork.ListPrice = goodsPrice.ListPrice;
                        goodsPriceUWork.SalesUnitCost = goodsPrice.SalesUnitCost;
                        goodsPriceUWork.StockRate = goodsPrice.StockRate;
                        goodsPriceUWork.OpenPriceDiv = goodsPrice.OpenPriceDiv;
                        goodsPriceUWork.OfferDate = goodsPrice.OfferDate;
                        goodsPriceUWork.UpdateDate = goodsPrice.UpdateDate;

                        goodsUnitDataWork.PriceList.Add(goodsPriceUWork);
                    }
                }

                goodsUnitDataWork.StockList = new ArrayList();
                if (goodsStockList != null)
                {
                    //�݌Ƀ}�X�^�X�V���ڃZ�b�g
                    foreach (StockWork goodsStock in goodsStockList)
                    {
                        if (goodsUnitDataWork.GoodsNo == goodsStock.GoodsNo &&
                            goodsUnitDataWork.GoodsMakerCd == goodsStock.GoodsMakerCd)
                        {
                            StockWork stockUWork = new StockWork();

                            stockUWork.CreateDateTime = goodsStock.CreateDateTime;
                            stockUWork.UpdateDateTime = goodsStock.UpdateDateTime;
                            stockUWork.EnterpriseCode = goodsStock.EnterpriseCode;
                            stockUWork.FileHeaderGuid = goodsStock.FileHeaderGuid;
                            stockUWork.UpdEmployeeCode = goodsStock.UpdEmployeeCode;
                            stockUWork.UpdAssemblyId1 = goodsStock.UpdAssemblyId1;
                            stockUWork.UpdAssemblyId2 = goodsStock.UpdAssemblyId2;
                            stockUWork.LogicalDeleteCode = goodsStock.LogicalDeleteCode;
                            stockUWork.SectionCode = goodsStock.SectionCode;
                            stockUWork.SectionGuideNm = goodsStock.SectionGuideNm;
                            stockUWork.WarehouseCode = goodsStock.WarehouseCode;
                            stockUWork.WarehouseName = goodsStock.WarehouseName;
                            stockUWork.GoodsMakerCd = goodsStock.GoodsMakerCd;
                            stockUWork.GoodsNo = goodsStock.GoodsNo;
                            stockUWork.StockUnitPriceFl = goodsStock.StockUnitPriceFl;
                            stockUWork.SupplierStock = goodsStock.SupplierStock;
                            stockUWork.AcpOdrCount = goodsStock.AcpOdrCount;
                            stockUWork.MonthOrderCount = goodsStock.MonthOrderCount;
                            stockUWork.SalesOrderCount = goodsStock.SalesOrderCount;
                            stockUWork.StockDiv = goodsStock.StockDiv;
                            stockUWork.MovingSupliStock = goodsStock.MovingSupliStock;
                            stockUWork.ShipmentPosCnt = goodsStock.ShipmentPosCnt;
                            stockUWork.StockTotalPrice = goodsStock.StockTotalPrice;
                            stockUWork.LastStockDate = goodsStock.LastStockDate;
                            stockUWork.LastSalesDate = goodsStock.LastSalesDate;
                            stockUWork.LastInventoryUpdate = goodsStock.LastInventoryUpdate;
                            stockUWork.MinimumStockCnt = goodsStock.MinimumStockCnt;
                            stockUWork.MaximumStockCnt = goodsStock.MaximumStockCnt;
                            stockUWork.NmlSalOdrCount = goodsStock.NmlSalOdrCount;
                            stockUWork.SalesOrderUnit = goodsStock.SalesOrderUnit;
                            stockUWork.StockSupplierCode = goodsStock.StockSupplierCode;
                            stockUWork.GoodsNoNoneHyphen = goodsStock.GoodsNoNoneHyphen;
                            stockUWork.WarehouseShelfNo = goodsStock.WarehouseShelfNo;
                            stockUWork.DuplicationShelfNo1 = goodsStock.DuplicationShelfNo1;
                            stockUWork.DuplicationShelfNo2 = goodsStock.DuplicationShelfNo2;
                            stockUWork.PartsManagementDivide1 = goodsStock.PartsManagementDivide1;
                            stockUWork.PartsManagementDivide2 = goodsStock.PartsManagementDivide2;
                            stockUWork.StockNote1 = goodsStock.StockNote1;
                            stockUWork.StockNote2 = goodsStock.StockNote2;
                            stockUWork.ShipmentCnt = goodsStock.ShipmentCnt;
                            stockUWork.ArrivalCnt = goodsStock.ArrivalCnt;
                            stockUWork.StockCreateDate = goodsStock.StockCreateDate;
                            stockUWork.UpdateDate = goodsStock.UpdateDate;

                            goodsUnitDataWork.StockList.Add(stockUWork);
                        }
                    }
                }

                al.Add(goodsUnitDataWork);
            }

            return al;
        }

        /// <summary>
        /// �A���N���X �� GoodsUWork,GoodsPriceUWork
        /// </summary>
        /// <param name="goodsUnitDataList">�A�����X�g</param>
        /// <param name="goodsList">���i���X�g</param>
        /// <param name="goodsPriceList">���i���i���X�g</param>
        /// <param name="goodsStockList">���i�݌Ƀ��X�g</param>
        /// <param name="flg">���i�A�b�v�f�[�g�f�[�g�^�C���ݒ�t���O</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2007.08.27</br>
        /// <br>Update Note: 2014/02/10 ���z</br>
        /// <br>             ���i�}�X�^�U�̒ǉ�</br>
        /// </remarks>
        private ArrayList CopyToGoodsAndPriceWork(ArrayList goodsUnitDataList, ref ArrayList goodsList, ref ArrayList goodsPriceList, ref ArrayList goodsStockList, bool flg)
        {
            ArrayList al = new ArrayList();
            string goodsNo = "";
            Int32 goodsMakerCd = 0;

            foreach (GoodsUnitDataWork goodsUnitDataWork in goodsUnitDataList)
            {
                GoodsUWork goodsUWork = new GoodsUWork();

                //���i�}�X�^�X�V���ڃZ�b�g
                goodsUWork.CreateDateTime = goodsUnitDataWork.CreateDateTime;
                goodsUWork.UpdateDateTime = goodsUnitDataWork.UpdateDateTime;
                goodsUWork.EnterpriseCode = goodsUnitDataWork.EnterpriseCode;
                goodsUWork.FileHeaderGuid = goodsUnitDataWork.FileHeaderGuid;
                goodsUWork.UpdEmployeeCode = goodsUnitDataWork.UpdEmployeeCode;
                goodsUWork.UpdAssemblyId1 = goodsUnitDataWork.UpdAssemblyId1;
                goodsUWork.UpdAssemblyId2 = goodsUnitDataWork.UpdAssemblyId2;
                goodsUWork.LogicalDeleteCode = goodsUnitDataWork.LogicalDeleteCode;
                goodsUWork.GoodsMakerCd = goodsUnitDataWork.GoodsMakerCd;
                goodsUWork.GoodsNo = goodsUnitDataWork.GoodsNo;
                goodsUWork.GoodsName = goodsUnitDataWork.GoodsName;
                goodsUWork.GoodsNameKana = goodsUnitDataWork.GoodsNameKana;
                goodsUWork.Jan = goodsUnitDataWork.Jan;
                goodsUWork.BLGoodsCode = goodsUnitDataWork.BLGoodsCode;
                goodsUWork.DisplayOrder = goodsUnitDataWork.DisplayOrder;
                goodsUWork.GoodsRateRank = goodsUnitDataWork.GoodsRateRank;
                goodsUWork.TaxationDivCd = goodsUnitDataWork.TaxationDivCd;
                goodsUWork.GoodsNoNoneHyphen = goodsUnitDataWork.GoodsNoNoneHyphen;
                goodsUWork.OfferDate = goodsUnitDataWork.OfferDate;
                goodsUWork.GoodsKindCode = goodsUnitDataWork.GoodsKindCode;
                goodsUWork.GoodsNote1 = goodsUnitDataWork.GoodsNote1;
                goodsUWork.GoodsNote2 = goodsUnitDataWork.GoodsNote2;
                goodsUWork.GoodsSpecialNote = goodsUnitDataWork.GoodsSpecialNote;
                goodsUWork.EnterpriseGanreCode = goodsUnitDataWork.EnterpriseGanreCode;
                goodsUWork.UpdateDate = goodsUnitDataWork.UpdateDate;
                goodsUWork.OfferDataDiv = goodsUnitDataWork.OfferDataDiv;
                // -------- ADD START 2014/02/10 ���z -------->>>>>
                goodsUWork.OptKonmanGoodsMstCtl = goodsUnitDataWork.OptKonmanGoodsMstCtl;
                goodsUWork.Standard = goodsUnitDataWork.Standard;
                goodsUWork.Packing = goodsUnitDataWork.Packing;
                goodsUWork.PosNo = goodsUnitDataWork.PosNo;
                goodsUWork.MakerGoodsNo = goodsUnitDataWork.MakerGoodsNo;
                goodsUWork.CreateDateTimeA = goodsUnitDataWork.CreateDateTimeA;
                goodsUWork.UpdateDateTimeA = goodsUnitDataWork.UpdateDateTimeA;
                goodsUWork.FileHeaderGuidA = goodsUnitDataWork.FileHeaderGuidA;
                // -------- ADD END 2014/02/10 ���z --------<<<<<

                if ((goodsNo != goodsUWork.GoodsNo) || (goodsMakerCd != goodsUWork.GoodsMakerCd))
                    goodsList.Add(goodsUWork);
                goodsNo = goodsUWork.GoodsNo;
                goodsMakerCd = goodsUWork.GoodsMakerCd;

                //���i�}�X�^�X�V���ڃZ�b�g
                //foreach (UsrGoodsPriceWork goodsPrice in goodsUnitDataWork.PriceList)
                foreach (GoodsPriceUWork goodsPrice in goodsUnitDataWork.PriceList)
                {
                    if (goodsPrice.PriceStartDate != DateTime.MinValue)
                    {
                        GoodsPriceUWork goodsPriceUWork = new GoodsPriceUWork();

                        goodsPriceUWork.CreateDateTime = goodsPrice.CreateDateTime;
                        if (flg == false)
                            goodsPriceUWork.UpdateDateTime = goodsPrice.UpdateDateTime;
                        goodsPriceUWork.EnterpriseCode = goodsPrice.EnterpriseCode;
                        goodsPriceUWork.FileHeaderGuid = goodsPrice.FileHeaderGuid;
                        goodsPriceUWork.UpdEmployeeCode = goodsPrice.UpdEmployeeCode;
                        goodsPriceUWork.UpdAssemblyId1 = goodsPrice.UpdAssemblyId1;
                        goodsPriceUWork.UpdAssemblyId2 = goodsPrice.UpdAssemblyId2;
                        goodsPriceUWork.LogicalDeleteCode = goodsPrice.LogicalDeleteCode;
                        goodsPriceUWork.GoodsNo = goodsPrice.GoodsNo;
                        goodsPriceUWork.GoodsMakerCd = goodsPrice.GoodsMakerCd;
                        goodsPriceUWork.PriceStartDate = goodsPrice.PriceStartDate;
                        goodsPriceUWork.ListPrice = goodsPrice.ListPrice;
                        goodsPriceUWork.SalesUnitCost = goodsPrice.SalesUnitCost;
                        goodsPriceUWork.StockRate = goodsPrice.StockRate;
                        goodsPriceUWork.OpenPriceDiv = goodsPrice.OpenPriceDiv;
                        goodsPriceUWork.OfferDate = goodsPrice.OfferDate;
                        goodsPriceUWork.UpdateDate = goodsPrice.UpdateDate;

                        goodsPriceList.Add(goodsPriceUWork);
                    }
                }

                //�݌Ƀ}�X�^�X�V���ڃZ�b�g
                #region �݌Ƀ}�X�^�X�V���ڃZ�b�g
                if (goodsUnitDataWork.StockList != null)
                {
                    foreach (StockWork goodsStock in goodsUnitDataWork.StockList)
                    {
                        StockWork stockUWork = new StockWork();

                        stockUWork.CreateDateTime = goodsStock.CreateDateTime;
                        stockUWork.UpdateDateTime = goodsStock.UpdateDateTime;
                        stockUWork.EnterpriseCode = goodsStock.EnterpriseCode;
                        stockUWork.FileHeaderGuid = goodsStock.FileHeaderGuid;
                        stockUWork.UpdEmployeeCode = goodsStock.UpdEmployeeCode;
                        stockUWork.UpdAssemblyId1 = goodsStock.UpdAssemblyId1;
                        stockUWork.UpdAssemblyId2 = goodsStock.UpdAssemblyId2;
                        stockUWork.LogicalDeleteCode = goodsStock.LogicalDeleteCode;
                        stockUWork.SectionCode = goodsStock.SectionCode;
                        stockUWork.SectionGuideNm = goodsStock.SectionGuideNm;
                        stockUWork.WarehouseCode = goodsStock.WarehouseCode;
                        stockUWork.WarehouseName = goodsStock.WarehouseName;
                        stockUWork.GoodsMakerCd = goodsStock.GoodsMakerCd;
                        stockUWork.GoodsNo = goodsStock.GoodsNo;
                        stockUWork.StockUnitPriceFl = goodsStock.StockUnitPriceFl;
                        stockUWork.SupplierStock = goodsStock.SupplierStock;
                        stockUWork.AcpOdrCount = goodsStock.AcpOdrCount;
                        stockUWork.MonthOrderCount = goodsStock.MonthOrderCount;
                        stockUWork.SalesOrderCount = goodsStock.SalesOrderCount;
                        stockUWork.StockDiv = goodsStock.StockDiv;
                        stockUWork.MovingSupliStock = goodsStock.MovingSupliStock;
                        stockUWork.ShipmentPosCnt = goodsStock.ShipmentPosCnt;
                        stockUWork.StockTotalPrice = goodsStock.StockTotalPrice;
                        stockUWork.LastStockDate = goodsStock.LastStockDate;
                        stockUWork.LastSalesDate = goodsStock.LastSalesDate;
                        stockUWork.LastInventoryUpdate = goodsStock.LastInventoryUpdate;
                        stockUWork.MinimumStockCnt = goodsStock.MinimumStockCnt;
                        stockUWork.MaximumStockCnt = goodsStock.MaximumStockCnt;
                        stockUWork.NmlSalOdrCount = goodsStock.NmlSalOdrCount;
                        stockUWork.SalesOrderUnit = goodsStock.SalesOrderUnit;
                        stockUWork.StockSupplierCode = goodsStock.StockSupplierCode;
                        stockUWork.GoodsNoNoneHyphen = goodsStock.GoodsNoNoneHyphen;
                        stockUWork.WarehouseShelfNo = goodsStock.WarehouseShelfNo;
                        stockUWork.DuplicationShelfNo1 = goodsStock.DuplicationShelfNo1;
                        stockUWork.DuplicationShelfNo2 = goodsStock.DuplicationShelfNo2;
                        stockUWork.PartsManagementDivide1 = goodsStock.PartsManagementDivide1;
                        stockUWork.PartsManagementDivide2 = goodsStock.PartsManagementDivide2;
                        stockUWork.StockNote1 = goodsStock.StockNote1;
                        stockUWork.StockNote2 = goodsStock.StockNote2;
                        stockUWork.ShipmentCnt = goodsStock.ShipmentCnt;
                        stockUWork.ArrivalCnt = goodsStock.ArrivalCnt;
                        stockUWork.StockCreateDate = goodsStock.StockCreateDate;
                        stockUWork.UpdateDate = goodsStock.UpdateDate;

                        goodsStockList.Add(stockUWork);
                    }
                }
                #endregion
            }

            return al;
        }

        // 2008.06.12 add start ------------------------------->>
        /// <summary>
        /// �A���N���X �� GoodsUWork,GoodsPriceUWork
        /// </summary>
        /// <param name="goodsUnitDataList">�A�����X�g</param>
        /// <param name="goodsList">���i���X�g</param>
        /// <param name="goodsPriceList">���i���i���X�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Programmer : 20081�@�D�c�@�E�l</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        private int ReadCopyToGoodsAndPriceWork(ArrayList goodsUnitDataList, ref ArrayList goodsList, ref ArrayList goodsPriceList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            int status = 0;
            string goodsNo = "";
            int goodsMakerCd = 0;

            string sqlTxt = string.Empty;
            sqlTxt += "SELECT" + Environment.NewLine;
            sqlTxt += "   GOODS.CREATEDATETIMERF" + Environment.NewLine;
            sqlTxt += "  ,GOODS.UPDATEDATETIMERF" + Environment.NewLine;
            sqlTxt += "  ,GOODS.ENTERPRISECODERF" + Environment.NewLine;
            sqlTxt += "  ,GOODS.FILEHEADERGUIDRF" + Environment.NewLine;
            sqlTxt += "  ,GOODS.UPDEMPLOYEECODERF" + Environment.NewLine;
            sqlTxt += "  ,GOODS.UPDASSEMBLYID1RF" + Environment.NewLine;
            sqlTxt += "  ,GOODS.UPDASSEMBLYID2RF" + Environment.NewLine;
            sqlTxt += "  ,GOODS.LOGICALDELETECODERF" + Environment.NewLine;
            sqlTxt += "FROM GOODSURF AS GOODS" + Environment.NewLine;
            sqlTxt += "WHERE" + Environment.NewLine;
            sqlTxt += "  GOODS.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
            sqlTxt += "  AND GOODS.GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
            sqlTxt += "  AND GOODS.GOODSNORF=@FINDGOODSNO" + Environment.NewLine;

            //Select�R�}���h�̐���
            sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);

            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
            SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
            try
            {
                foreach (GoodsUnitDataWork goodsUnitDataWork in goodsUnitDataList)
                {
                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsUnitDataWork.EnterpriseCode);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsUnitDataWork.GoodsMakerCd);
                    findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsUnitDataWork.GoodsNo);

                    myReader = sqlCommand.ExecuteReader();
                    int flg = 0;
                    if (myReader.Read() == false)
                    {
                        flg = 1;
                    }
                    else
                    {
                        int logicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                        if (logicalDeleteCode == 1)
                        {
                            flg = 2;
                        }
                    }
                    if (flg != 0) // ���i�Ȃ����͘_���폜��Ԃ�
                    {
                        GoodsUWork goodsUWork = new GoodsUWork();

                        //���i�}�X�^�X�V���ڃZ�b�g
                        if (flg == 1)
                        {
                            goodsUWork.CreateDateTime = goodsUnitDataWork.CreateDateTime;
                            goodsUWork.UpdateDateTime = goodsUnitDataWork.UpdateDateTime;
                            goodsUWork.EnterpriseCode = goodsUnitDataWork.EnterpriseCode;
                            goodsUWork.FileHeaderGuid = goodsUnitDataWork.FileHeaderGuid;
                            goodsUWork.UpdEmployeeCode = goodsUnitDataWork.UpdEmployeeCode;
                            goodsUWork.UpdAssemblyId1 = goodsUnitDataWork.UpdAssemblyId1;
                            goodsUWork.UpdAssemblyId2 = goodsUnitDataWork.UpdAssemblyId2;
                            goodsUWork.LogicalDeleteCode = goodsUnitDataWork.LogicalDeleteCode;
                        }
                        else
                        {
                            goodsUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                            goodsUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                            goodsUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                            goodsUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                            goodsUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                            goodsUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                            goodsUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                            goodsUWork.LogicalDeleteCode = 0;
                            myReader.Close();
                        }
                        goodsUWork.GoodsMakerCd = goodsUnitDataWork.GoodsMakerCd;
                        goodsUWork.GoodsNo = goodsUnitDataWork.GoodsNo;
                        goodsUWork.GoodsName = goodsUnitDataWork.GoodsName;
                        goodsUWork.GoodsNameKana = goodsUnitDataWork.GoodsNameKana;
                        goodsUWork.Jan = goodsUnitDataWork.Jan;
                        goodsUWork.BLGoodsCode = goodsUnitDataWork.BLGoodsCode;
                        goodsUWork.DisplayOrder = goodsUnitDataWork.DisplayOrder;
                        goodsUWork.GoodsRateRank = goodsUnitDataWork.GoodsRateRank;
                        goodsUWork.TaxationDivCd = goodsUnitDataWork.TaxationDivCd;
                        goodsUWork.GoodsNoNoneHyphen = goodsUnitDataWork.GoodsNoNoneHyphen;
                        goodsUWork.OfferDate = goodsUnitDataWork.OfferDate;
                        goodsUWork.GoodsKindCode = goodsUnitDataWork.GoodsKindCode;
                        goodsUWork.GoodsNote1 = goodsUnitDataWork.GoodsNote1;
                        goodsUWork.GoodsNote2 = goodsUnitDataWork.GoodsNote2;
                        goodsUWork.GoodsSpecialNote = goodsUnitDataWork.GoodsSpecialNote;
                        goodsUWork.EnterpriseGanreCode = goodsUnitDataWork.EnterpriseGanreCode;
                        goodsUWork.UpdateDate = goodsUnitDataWork.UpdateDate;

                        if ((goodsNo != goodsUWork.GoodsNo) || (goodsMakerCd != goodsUWork.GoodsMakerCd))
                        {
                            goodsList.Add(goodsUWork);
                        }
                        goodsNo = goodsUWork.GoodsNo;
                        goodsMakerCd = goodsUWork.GoodsMakerCd;

                        //���i�}�X�^�X�V���ڃZ�b�g
                        if (goodsUnitDataWork.PriceList != null)
                        {
                            foreach (GoodsPriceUWork goodsPrice in goodsUnitDataWork.PriceList)
                            {
                                if (goodsPrice.PriceStartDate != DateTime.MinValue)
                                {
                                    GoodsPriceUWork goodsPriceUWork = new GoodsPriceUWork();

                                    goodsPriceUWork.CreateDateTime = goodsPrice.CreateDateTime;
                                    goodsPriceUWork.UpdateDateTime = goodsPrice.UpdateDateTime;
                                    goodsPriceUWork.EnterpriseCode = goodsPrice.EnterpriseCode;
                                    goodsPriceUWork.FileHeaderGuid = goodsPrice.FileHeaderGuid;
                                    goodsPriceUWork.UpdEmployeeCode = goodsPrice.UpdEmployeeCode;
                                    goodsPriceUWork.UpdAssemblyId1 = goodsPrice.UpdAssemblyId1;
                                    goodsPriceUWork.UpdAssemblyId2 = goodsPrice.UpdAssemblyId2;
                                    goodsPriceUWork.LogicalDeleteCode = goodsPrice.LogicalDeleteCode;
                                    goodsPriceUWork.GoodsNo = goodsPrice.GoodsNo;
                                    goodsPriceUWork.GoodsMakerCd = goodsPrice.GoodsMakerCd;
                                    goodsPriceUWork.PriceStartDate = goodsPrice.PriceStartDate;
                                    goodsPriceUWork.ListPrice = goodsPrice.ListPrice;
                                    goodsPriceUWork.SalesUnitCost = goodsPrice.SalesUnitCost;
                                    goodsPriceUWork.StockRate = goodsPrice.StockRate;
                                    goodsPriceUWork.OpenPriceDiv = goodsPrice.OpenPriceDiv;
                                    goodsPriceUWork.OfferDate = goodsPrice.OfferDate;
                                    goodsPriceUWork.UpdateDate = goodsPrice.UpdateDate;

                                    goodsPriceList.Add(goodsPriceUWork);
                                    if (flg == 2)
                                    {
                                        DeleteOldPrice(goodsPrice, ref sqlConnection, ref sqlTransaction);
                                    }
                                }
                            }

                        }
                    }
                    if (myReader != null && myReader.IsClosed == false)
                        myReader.Close();
                }
            }
            catch
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (myReader != null && myReader.IsClosed == false)
                    myReader.Close();
            }

            return status;
        }
        // 2008.06.12 add end ---------------------------------<<

        /// <summary>
        /// ���i�}�X�^����_���폜���܂�
        /// </summary>
        /// <param name="goodsWork">GoodsWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�}�X�^����_���폜���܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2006.12.08</br>
        public int LogicalDeleteRelation(ref object goodsWork)
        {
            return LogicalDeleteGoodsRelation(ref goodsWork, 0);
        }

        /// <summary>
        /// �_���폜���i�}�X�^���𕜊����܂�
        /// </summary>
        /// <param name="goodsWork">GoodsWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �_���폜���i�}�X�^���𕜊����܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2006.12.08</br>
        public int RevivalLogicalDeleteRelation(ref object goodsWork)
        {
            return LogicalDeleteGoodsRelation(ref goodsWork, 1);
        }

        /// <summary>
        /// ���i�}�X�^���̘_���폜�𑀍삵�܂�
        /// </summary>
        /// <param name="goodsWork">GoodsWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�}�X�^���̘_���폜�𑀍삵�܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2006.12.08</br>
        private int LogicalDeleteGoodsRelation(ref object goodsWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            CustomSerializeArrayList retList = new CustomSerializeArrayList();
            try
            {
                ArrayList goodsUnitDataList = null;
                ArrayList goodsList = new ArrayList();
                ArrayList goodsPriceList = new ArrayList();
                ArrayList goodsStockList = new ArrayList();

                //�p�����[�^�̃L���X�g
                CustomSerializeArrayList csaList = goodsWork as CustomSerializeArrayList;
                if (csaList == null) return status;

                for (int i = 0; i < csaList.Count; i++)
                {
                    ArrayList wkal = csaList[i] as ArrayList;
                    if (wkal != null)
                    {
                        if (wkal.Count > 0)
                        {
                            //���i�}�X�^
                            if (wkal[0] is GoodsUnitDataWork) goodsUnitDataList = wkal;
                        }
                    }
                }

                if (goodsUnitDataList != null)
                {
                    CopyToGoodsAndPriceWork(goodsUnitDataList, ref goodsList, ref goodsPriceList, ref goodsStockList, false);
                }

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //���i�}�X�^�X�V����
                if (goodsList != null)
                {
                    GoodsUDB goodsUDB = new GoodsUDB();
                    status = goodsUDB.LogicalDeleteGoodsUProc(ref goodsList, procMode, ref sqlConnection, ref sqlTransaction);
                }

                //���i�}�X�^�X�V����
                if (goodsPriceList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    GoodsPriceUDB goodsPriceDB = new GoodsPriceUDB();
                    status = goodsPriceDB.LogicalDeleteGoodsPriceProc(ref goodsPriceList, procMode, ref sqlConnection, ref sqlTransaction);
                }

                //�݌Ƀ}�X�^�X�V����
                //if ((goodsStockList != null && goodsStockList.Count > 0) && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    StockDB goodsStockDB = new StockDB();
                //    status = goodsStockDB.LogicalDeleteStockProc(ref goodsStockList, procMode, ref sqlConnection, ref sqlTransaction);
                //}

                retList.Add(CopyToGoodsUnitDataList(goodsList, goodsPriceList, goodsStockList));

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    sqlTransaction.Commit();
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //�߂�l�Z�b�g
                goodsWork = retList;
            }
            catch (Exception ex)
            {
                string procModestr = "";
                if (procMode == 0)
                    procModestr = "LogicalDelete";
                else
                    procModestr = "RevivalLogicalDelete";
                base.WriteErrorLog(ex, "GoodsDB.LogicalDeleteGoods :" + procModestr);

                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// ���i�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="paraobj">���i�}�X�^���I�u�W�F�N�g</param>
        /// <returns></returns>
        /// <br>Note       : ���i�}�X�^���𕨗��폜���܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2006.12.08</br>
        public int DeleteRelation(object paraobj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null)
                    return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = DeleteRelationProc(paraobj, sqlConnection, sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)    // �R�~�b�g
                {
                    sqlTransaction.Commit();
                }
                else // ���[���o�b�N
                {
                    if (sqlTransaction.Connection != null)
                    {
                        sqlTransaction.Rollback();
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsDB.Delete");
                // ���[���o�b�N
                if (sqlTransaction.Connection != null)
                    sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null)
                    sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        private int DeleteRelationProc(object paraobj, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            ArrayList goodsUnitDataList = null;
            ArrayList goodsList = new ArrayList();
            ArrayList goodsPriceList = new ArrayList();
            ArrayList goodsStockList = new ArrayList();
            ArrayList RateWork = new ArrayList();

            //�p�����[�^�̃L���X�g
            CustomSerializeArrayList csaList = paraobj as CustomSerializeArrayList;
            if (csaList == null)
                return status;

            for (int i = 0; i < csaList.Count; i++)
            {
                ArrayList wkal = csaList[i] as ArrayList;
                if (wkal != null && wkal.Count > 0)
                {
                    if (wkal[0] is GoodsUnitDataWork) // ���i�}�X�^
                    {
                        goodsUnitDataList = wkal;

                        if (goodsUnitDataList != null)
                        {
                            CopyToGoodsAndPriceWork(goodsUnitDataList, ref goodsList, ref goodsPriceList, ref goodsStockList, false);
                        }

                        //���i�}�X�^�폜����
                        if (goodsList != null)
                        {
                            GoodsUDB goodsUDB = new GoodsUDB();
                            status = goodsUDB.DeleteGoodsUProc(goodsList, ref sqlConnection, ref sqlTransaction);
                        }

                        //���i�}�X�^�폜����
                        if (goodsPriceList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            GoodsPriceUDB goodsPriceDB = new GoodsPriceUDB();
                            status = goodsPriceDB.DeleteGoodsPriceProc(goodsPriceList, ref sqlConnection, ref sqlTransaction);
                        }

                        //�݌Ƀ}�X�^�X�V����(MAZAI04134R�łȂ�MAZAI04364R���g���悤�ɏC��:�݌ɂ͍폜��WriteBatch�ŏ���)
                        if ((goodsStockList != null && goodsStockList.Count > 0) && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            string retMsg;
                            StockAdjustDB stockAdjustDB = new StockAdjustDB();
                            CustomSerializeArrayList stockAdjustcsList = new CustomSerializeArrayList();
                            CustomSerializeArrayList lstStock = new CustomSerializeArrayList();

                            lstStock.Add(goodsStockList);

                            stockAdjustcsList.Add(lstStock);
                            object objStockAdjustCustList = stockAdjustcsList;
                            status = stockAdjustDB.WriteBatch(ref objStockAdjustCustList, out retMsg, ref sqlConnection, ref sqlTransaction);
                            // �폜�Ȃ̂Ō㏈���͕s�v
                        }
                    }
                    else if (wkal[0] is RateWork) // �|�����[�N
                    {
                        RateDB rateDB = new RateDB();
                        status = rateDB.DeleteSubSectionProc(wkal, ref sqlConnection, ref sqlTransaction);
                    }
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        break;
                }
            }

            return status;
        }
        #endregion

        // 2008.06.12 add start --------------------------------->>
        /// <summary>
        /// ���i�}�X�^�i���[�U�[�o�^���j����V�K�o�^(���i�}�X�^�ɑ��݂��Ȃ��ꍇ�̂�)
        /// </summary>
        /// <param name="goodsWork">GoodsWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�}�X�^�i���[�U�[�o�^���j����V�K�o�^(���i�}�X�^�ɑ��݂��Ȃ��ꍇ�̂�)</br>
        /// <br>Programmer : 20081�@�D�c�@�E�l</br>
        /// <br>Date       : 2008.06.12</br>
        /// <br></br>
        public int ReadNewWriteRelation(ref object goodsWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            CustomSerializeArrayList retList = new CustomSerializeArrayList();

            try
            {
                //�p�����[�^�̃L���X�g
                CustomSerializeArrayList csaList = goodsWork as CustomSerializeArrayList;
                if (csaList == null)
                    return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null)
                    return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = ReadNewWriteRelationProc(ref csaList, ref retList, sqlConnection, sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)    // �R�~�b�g
                {
                    sqlTransaction.Commit();
                }
                else    // ���[���o�b�N
                {
                    if (sqlTransaction.Connection != null)
                        sqlTransaction.Rollback();
                }

                //�߂�l�Z�b�g
                goodsWork = retList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsDB.Write(ref object goodsWork)");
                // ���[���o�b�N
                if (sqlTransaction.Connection != null)
                    sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null)
                    sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// ���i�}�X�^�i���[�U�[�o�^���j����V�K�o�^(���i�}�X�^�ɑ��݂��Ȃ��ꍇ�̂�)
        /// </summary>
        /// <param name="goodsWork">GoodsWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">�R���l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>STATUS</returns>
        public int ReadNewWriteRelation(ref object goodsWork,
            ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            //�p�����[�^�̃L���X�g
            CustomSerializeArrayList csaList = goodsWork as CustomSerializeArrayList;
            CustomSerializeArrayList retList = new CustomSerializeArrayList();

            if (csaList == null)
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            status = ReadNewWriteRelationProc(ref csaList, ref retList, sqlConnection, sqlTransaction);
            //�߂�l�Z�b�g
            goodsWork = retList;
            return status;
        }

        private int ReadNewWriteRelationProc(ref CustomSerializeArrayList csaList, ref CustomSerializeArrayList retList,
            SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            ArrayList goodsUnitDataList = null;
            ArrayList goodsList = new ArrayList();
            ArrayList goodsPriceList = new ArrayList();

            for (int i = 0; i < csaList.Count; i++)
            {
                ArrayList wkal = csaList[i] as ArrayList;
                if (wkal != null && wkal.Count > 0)
                {
                    //���i�}�X�^
                    if (wkal[0] is GoodsUnitDataWork)
                        goodsUnitDataList = wkal;

                    // ���i���݊m�F
                    if (goodsUnitDataList != null)
                    {
                        status = ReadCopyToGoodsAndPriceWork(goodsUnitDataList, ref goodsList, ref goodsPriceList, ref sqlConnection, ref sqlTransaction);
                    }

                    //���i�}�X�^�X�V����
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && goodsList.Count > 0)
                    {
                        GoodsUDB goodsUDB = new GoodsUDB();
                        status = goodsUDB.WriteGoodsUProc(ref goodsList, ref sqlConnection, ref sqlTransaction);
                    }

                    //���i�}�X�^�X�V����
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && goodsPriceList.Count > 0)
                    {
                        ArrayList writeErrorList = new ArrayList();
                        GoodsPriceUDB goodsPriceDB = new GoodsPriceUDB();
                        status = goodsPriceDB.WriteGoodsPriceProc(ref goodsPriceList, out writeErrorList, ref sqlConnection, ref sqlTransaction);
                    }

                    retList.Add(CopyToGoodsUnitDataList(goodsList, goodsPriceList, null));
                }
            }

            return status;
        }
        // 2008.06.12 add end -----------------------------------<<

        #endregion

        // --- ADD yangyi 2013/03/18 for Redmine#34962 ------->>>>>>>>>>>
        #region �w�肳�ꂽ�����̏��i�\���擾���LIST��߂��܂�(���i�݌Ɉꊇ�o�^�C���p)
        /// <summary>
        /// �w�肳�ꂽ�����̏��i�\���擾���LIST��߂��܂�(���i�݌Ɉꊇ�o�^�C���p)
        /// </summary>
        /// <param name="retObj">��������</param>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="maxCount">�擾MAX����(���i���)</param>
        /// <param name="targetDiv">�Ώۋ敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        public int Search(ref object retObj, object paraObj, int readMode, int maxCount, int targetDiv,ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = SearchProc(ref retObj, paraObj, readMode, maxCount, targetDiv,logicalMode, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsURelationDataDB.Search");
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        sqlTransaction.Commit();
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̏��i�\���擾���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)(���i�݌Ɉꊇ�o�^�C���p)
        /// </summary>
        /// <param name="retObj">��������</param>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="maxCount">�擾MAX����(���i���)</param>
        /// <param name="targetDiv">�Ώۋ敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�\���擾���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2006.12.06</br>
        /// <br></br>
        /// <br>Update Note: 2007.08.27 ���� DC.NS�p�ɏC��</br>
        public int SearchProc(ref object retObj, object paraObj, int readMode, int maxCount, int targetDiv,ConstantManagement.LogicalMode logicalMode,
            ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return SearchProcP(ref retObj, paraObj, readMode, maxCount, targetDiv, logicalMode, ref sqlConnection, ref sqlTransaction);
        }

        private int SearchProcP(ref object retObj, object paraObj, int readMode, int maxCount, int targetDiv, ConstantManagement.LogicalMode logicalMode,
            ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            GoodsUCndtnWork goodsrelationdataWork = null;

            CustomSerializeArrayList retCSAList = new CustomSerializeArrayList();

            ArrayList goodsrelationdataWorkList = paraObj as ArrayList;
            if (goodsrelationdataWorkList == null)
            {
                goodsrelationdataWork = paraObj as GoodsUCndtnWork;
            }
            else
            {
                if (goodsrelationdataWorkList.Count > 0)
                    goodsrelationdataWork = goodsrelationdataWorkList[0] as GoodsUCndtnWork;
            }

            CustomSerializeArrayList paraList = retObj as CustomSerializeArrayList;
            for (int i = 0; i < paraList.Count; i++)
            {
                Type wktype = paraList[i].GetType();
                switch (wktype.Name)
                {
                    //����S�̐ݒ�
                    case "SalesTtlStWork":
                        {
                            SalesTtlStDB salesTtlStDB = new SalesTtlStDB();
                            ArrayList retal = new ArrayList();
                            SalesTtlStWork salesTtlStWork = paraList[i] as SalesTtlStWork;
                            salesTtlStWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
                            status = salesTtlStDB.SearchSalesTtlStProc(out retal, salesTtlStWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
                            retCSAList.Add(retal);
                        }
                        break;
                    //���i������
                    case "GoodsGroupUWork":
                        {
                            GoodsGroupUDB goodsGroupUDB = new GoodsGroupUDB();
                            ArrayList retal = new ArrayList();
                            GoodsGroupUWork goodsGroupUWork = paraList[i] as GoodsGroupUWork;
                            goodsGroupUWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
                            status = goodsGroupUDB.Search(ref retal, goodsGroupUWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
                            retCSAList.Add(retal);
                        }
                        break;

                    //�D�ǐݒ�
                    case "PrmSettingUWork":
                        {
                            PrmSettingUDB prmSettingUDB = new PrmSettingUDB();
                            ArrayList retal = new ArrayList();
                            PrmSettingUWork prmSettingUWork = paraList[i] as PrmSettingUWork;
                            prmSettingUWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
                            status = prmSettingUDB.Search(ref retal, prmSettingUWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
                            retCSAList.Add(retal);
                        }
                        break;

                    //���[�J�[
                    case "MakerUWork":
                        {
                            MakerUDB makerUDB = new MakerUDB();
                            ArrayList retal = null;
                            MakerUWork makerUWork = new MakerUWork();
                            makerUWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
                            status = makerUDB.SearchMakerProc(out retal, makerUWork, readMode, logicalMode, ref sqlConnection);
                            retCSAList.Add(retal);
                        }
                        break;

                    //BL�O���[�v 
                    case "BLGroupUWork":
                        {
                            BLGroupUDB bLGroupUDB = new BLGroupUDB();
                            ArrayList retal = new ArrayList();
                            BLGroupUWork bLGroupUWork = paraList[i] as BLGroupUWork;
                            bLGroupUWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
                            status = bLGroupUDB.Search(ref retal, bLGroupUWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
                            retCSAList.Add(retal);
                        }
                        break;

                    //BL�R�[�h               
                    case "BLGoodsCdUWork":
                        {
                            BLGoodsCdUDB bLGoodsCdUDB = new BLGoodsCdUDB();
                            ArrayList retal = null;
                            BLGoodsCdUWork bLGoodsCdUWork = paraList[i] as BLGoodsCdUWork;
                            bLGoodsCdUWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
                            status = bLGoodsCdUDB.SearchBLGoodsCdProc(out retal, bLGoodsCdUWork, readMode, logicalMode, ref sqlConnection);
                            retCSAList.Add(retal);
                        }
                        break;

                    //���i�Ǘ�
                    case "GoodsMngWork":
                        {
                            GoodsMngDB goodsMngDB = new GoodsMngDB();
                            ArrayList retal = new ArrayList();
                            GoodsMngWork goodsMngWork = paraList[i] as GoodsMngWork;
                            goodsMngWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
                            status = goodsMngDB.SearchGoodsMngProc(out retal, goodsMngWork, readMode, logicalMode, ref sqlConnection);
                            retCSAList.Add(retal);
                        }
                        break;

                    //���[�U�[�K�C�h
                    case "UserGdBdUWork":
                        {
                            UserGdBdUDB userGdBdUDB = new UserGdBdUDB();
                            //UserGdBdUWork userGdBdUWork = paraList[i] as UserGdBdUWork;
                            UserGdBdUWork[] usrGdBdLst = new UserGdBdUWork[1];
                            usrGdBdLst[0] = paraList[i] as UserGdBdUWork;

                            //���i�啪��(���[�U�[�K�C�h �K�C�h�敪:70)
                            ArrayList retal = null;
                            usrGdBdLst[0].EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
                            usrGdBdLst[0].UserGuideDivCd = 70;
                            status = userGdBdUDB.Search(out retal, usrGdBdLst, 0, logicalMode, ref sqlConnection);
                            retCSAList.Add(retal);

                            //���Е���(���[�U�[�K�C�h �K�C�h�敪:41)
                            retal = null;
                            usrGdBdLst[0].UserGuideDivCd = 41;
                            status = userGdBdUDB.Search(out retal, usrGdBdLst, 0, logicalMode, ref sqlConnection);
                            retCSAList.Add(retal);

                            //�̔��敪(���[�U�[�K�C�h �K�C�h�敪:71)
                            retal = null;
                            usrGdBdLst[0].UserGuideDivCd = 71;
                            status = userGdBdUDB.Search(out retal, usrGdBdLst, 0, logicalMode, ref sqlConnection);
                            retCSAList.Add(retal);
                        }
                        break;

                    // �������i
                    case "IsolIslandPrcWork":
                        {
                            IsolIslandPrcDB isolIslandPrcDB = new IsolIslandPrcDB();
                            ArrayList retal = new ArrayList();
                            IsolIslandPrcWork isolIslandPrcWork = paraList[i] as IsolIslandPrcWork;
                            isolIslandPrcWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
                            status = isolIslandPrcDB.Search(ref retal, isolIslandPrcWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
                            retCSAList.Add(retal);
                        }
                        break;

                    // �d����
                    case "SupplierWork":
                        {
                            SupplierDB supplierDB = new SupplierDB();
                            ArrayList retal = new ArrayList();
                            SupplierWork supplierWork = paraList[i] as SupplierWork;
                            supplierWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
                            status = supplierDB.Search(out retal, supplierWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
                            retCSAList.Add(retal);
                        }
                        break;

                    //���i�A��
                    case "GoodsUnitDataWork":
                        {
                            ArrayList retal = null;
                            status = SearchGoodsURelationDataProc(out retal, wktype, goodsrelationdataWork, null, readMode, maxCount, targetDiv, logicalMode, ref sqlConnection);
                            retCSAList.Add(retal);
                        }
                        break;

                }
            }

            retObj = retCSAList;

            // �� 2008.03.24 980081 c
            //return status;

            // 2011/11/29 Add >>>
            // �R�}���h�^�C���A�E�g�̏ꍇ�A�X�e�[�^�X�����̂܂ܕԂ�
            if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                return status;
            // 2011/11/29 Add <<<
            if (retCSAList.Count == 0)
            {
                return (int)ConstantManagement.DB_Status.ctDB_EOF;
            }
            else
            {
                return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            // �� 2008.03.24 980081 c
        }

        /// <summary>
        /// �w�肳�ꂽ�����̏��i�\���擾���LIST��߂��܂�(�O�������SqlConnection���g�p)(���i�݌Ɉꊇ�o�^�C���p)
        /// </summary>
        /// <param name="goodsrelationdataWorkList">��������</param>
        /// <param name="trgType">�擾�Ώۋ敪</param>
        /// <param name="goodsrelationdataWork">���o����</param>
        /// <param name="paralist">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="maxCount">�擾MAX����(���i���)</param>
        /// <param name="targetDiv">�Ώۋ敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Update Note: 2015/08/17 �c����</br>
        /// <br>�Ǘ��ԍ�   : 11170052-00</br>
        /// <br>           : Redmine#47036 ���i�݌Ɉꊇ�o�^�C�� �Ǘ����_�E�q�ɂ̒ǉ�</br>
        /// </remarks>
        public int SearchGoodsURelationDataProc(out ArrayList goodsrelationdataWorkList, Type trgType, GoodsUCndtnWork goodsrelationdataWork,
            ArrayList paralist, int readMode, int maxCount, int targetDiv,ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return SearchGoodsURelationDataProcP(out goodsrelationdataWorkList, trgType, goodsrelationdataWork, paralist, readMode, maxCount, targetDiv,logicalMode, 0, ref sqlConnection);
        }

        private int SearchGoodsURelationDataProcP(out ArrayList goodsrelationdataWorkList, Type trgType, GoodsUCndtnWork goodsrelationdataWork, ArrayList paralist, int readMode, int maxCount, int targetDiv,ConstantManagement.LogicalMode logicalMode, int stockSearchDiv, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            // 2009.02.19 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            string sMaxCount = string.Empty;
            if (maxCount != 0) sMaxCount = "TOP(" + maxCount.ToString() + ") ";
            // 2009.02.19 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            goodsrelationdataWorkList = new ArrayList();
            ArrayList retList = new ArrayList();
            ArrayList reList = new ArrayList();

            string selectstring = "";
            try
            {
                // 2009.02.19 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //selectstring += "SELECT GOODS.CREATEDATETIMERF" + Environment.NewLine;

                if (targetDiv == 0 || targetDiv == 1)
                {
                    selectstring += "SELECT " + sMaxCount + "GOODS.CREATEDATETIMERF" + Environment.NewLine;
                }
                if (targetDiv == 2 || targetDiv == 3)
                {
                    selectstring += "SELECT GOODS.CREATEDATETIMERF" + Environment.NewLine;
                }
                // 2009.02.19 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                selectstring += "    ,GOODS.UPDATEDATETIMERF" + Environment.NewLine;
                selectstring += "    ,GOODS.ENTERPRISECODERF" + Environment.NewLine;
                selectstring += "    ,GOODS.FILEHEADERGUIDRF" + Environment.NewLine;
                selectstring += "    ,GOODS.UPDEMPLOYEECODERF" + Environment.NewLine;
                selectstring += "    ,GOODS.UPDASSEMBLYID1RF" + Environment.NewLine;
                selectstring += "    ,GOODS.UPDASSEMBLYID2RF" + Environment.NewLine;
                selectstring += "    ,GOODS.LOGICALDELETECODERF" + Environment.NewLine;
                selectstring += "    ,GOODS.GOODSMAKERCDRF" + Environment.NewLine;
                selectstring += "    ,GOODS.GOODSNORF" + Environment.NewLine;
                selectstring += "    ,GOODS.GOODSNAMERF" + Environment.NewLine;
                selectstring += "    ,GOODS.GOODSNAMEKANARF" + Environment.NewLine;
                selectstring += "    ,GOODS.JANRF" + Environment.NewLine;
                selectstring += "    ,GOODS.BLGOODSCODERF" + Environment.NewLine;
                selectstring += "    ,GOODS.DISPLAYORDERRF" + Environment.NewLine;
                selectstring += "    ,GOODS.GOODSRATERANKRF" + Environment.NewLine;
                selectstring += "    ,GOODS.TAXATIONDIVCDRF" + Environment.NewLine;
                selectstring += "    ,GOODS.GOODSNONONEHYPHENRF" + Environment.NewLine;
                selectstring += "    ,GOODS.OFFERDATERF" + Environment.NewLine;
                selectstring += "    ,GOODS.GOODSKINDCODERF" + Environment.NewLine;
                selectstring += "    ,GOODS.GOODSNOTE1RF" + Environment.NewLine;
                selectstring += "    ,GOODS.GOODSNOTE2RF" + Environment.NewLine;
                selectstring += "    ,GOODS.GOODSSPECIALNOTERF" + Environment.NewLine;
                selectstring += "    ,GOODS.ENTERPRISEGANRECODERF" + Environment.NewLine;
                selectstring += "    ,GOODS.UPDATEDATERF" + Environment.NewLine;
                selectstring += "    ,GOODS.OFFERDATADIVRF" + Environment.NewLine;
                selectstring += "FROM GOODSURF AS GOODS" + Environment.NewLine;

                sqlCommand = new SqlCommand(selectstring, sqlConnection);

                if (paralist != null)
                    sqlCommand.CommandText += MakeWhereStringMultiCondition(ref sqlCommand, trgType, paralist, logicalMode);
                else
                    sqlCommand.CommandText += MakeWhereString(ref sqlCommand, trgType, goodsrelationdataWork, logicalMode);

                //sqlCommand.CommandText += "ORDER BY GOODS.GOODSMAKERCDRF ASC, GOODS.GOODSNORF ASC" + Environment.NewLine; //DEL yangyi 2013/04/25 Redmine#35018
                sqlCommand.CommandText += "ORDER BY GOODS.ENTERPRISECODERF ASC, GOODS.GOODSNORF ASC, GOODS.GOODSMAKERCDRF ASC" + Environment.NewLine;//ADD yangyi 2013/04/25 Redmine#35018

                // 2011/11/29 Add >>>
                sqlCommand.CommandTimeout = 60;
                // 2011/11/29 Add <<<

                myReader = sqlCommand.ExecuteReader();


                // --- DEL yangyi 2013/03/18 for Redmine#34962 ------->>>>>>>>>>>
                // ADD gezh 2013/01/24 Redmine#33361 ���C�ćA -------->>>>>
                //ArrayList priceList = new ArrayList();
                //ArrayList usrGoodsPrice;
                // ADD gezh 2013/01/24 Redmine#33361 ���C�ćA --------<<<<<
                // --- DEL yangyi 2013/03/18 for Redmine#34962 -------<<<<<<<<<<<
                // --- ADD yangyi 2013/03/18 for Redmine#34962 ------->>>>>>>>>>>
                Dictionary<string, ArrayList> priceDic = new Dictionary<string, ArrayList>();
                Dictionary<string, ArrayList> stockDic = new Dictionary<string, ArrayList>();

                ArrayList usrGoodsPrice;

                // --- ADD yangyi 2013/03/18 for Redmine#34962 -------<<<<<<<<<<<
                while (myReader.Read())
                {
                    //al.Add(CopyToGoodsUnitDataWorkFromReader(ref myReader));// DEL 2014.02.10 ���z
                    al.Add(CopyToGoodsUnitDataWorkFromReader(ref myReader, false));// ADD 2014.02.10 ���z

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    // --- DEL yangyi 2013/03/18 for Redmine#34962 ------->>>>>>>>>>>
                    // ADD gezh 2013/01/24 Redmine#33361 ���C�ćA -------->>>>>
                    //GoodsUnitDataWork usrGoodsWork = (GoodsUnitDataWork)al[al.Count - 1];
                    //UsrPartsNoSearchCondWork wk = new UsrPartsNoSearchCondWork();
                    //wk.EnterpriseCode = usrGoodsWork.EnterpriseCode;
                    //wk.MakerCode = usrGoodsWork.GoodsMakerCd;
                    //wk.PrtsNo = usrGoodsWork.GoodsNo;
                    //priceList.Add(wk);
                    // ADD gezh 2013/01/24 Redmine#33361 ���C�ćA --------<<<<<
                    // --- DEL yangyi 2013/03/18 for Redmine#34962 -------<<<<<<<<<<<

                }
                /* ---------------- DEL gezh 2013/01/24 Redmine#33361 ���C�ćA -------->>>>>
                ArrayList priceList = new ArrayList();
                ArrayList usrGoodsPrice;
                foreach (GoodsUnitDataWork usrGoodsWork in al)
                {
                    UsrPartsNoSearchCondWork wk = new UsrPartsNoSearchCondWork();
                    wk.EnterpriseCode = usrGoodsWork.EnterpriseCode;
                    wk.MakerCode = usrGoodsWork.GoodsMakerCd;
                    wk.PrtsNo = usrGoodsWork.GoodsNo;
                    priceList.Add(wk);
                }
                <<<<<-------------- DEL gezh 2013/01/24 Redmine#33361 ���C�ćA ---------- */
                myReader.Close();
                //status = SearchUsrGoodsPriceProc(priceList, out usrGoodsPrice, logicalMode, sqlConnection);  //DEL yangyi 2013/03/18 Redmine#34962 
                status = SearchUsrGoodsPriceAllProc(goodsrelationdataWork, out usrGoodsPrice, logicalMode, sqlConnection); //ADD yangyi 2013/03/18 Redmine#34962
                if (status == 0)
                {
                    // --- DEL yangyi 2013/03/18 for Redmine#34962 ------->>>>>>>>>>>
                    //// ADD gezh 2013/01/24 Redmine#33361 ���C�ćB -------->>>>>
                    //Dictionary<string, ArrayList> priceDic = new Dictionary<string, ArrayList>();

                    //foreach (GoodsPriceUWork prc in usrGoodsPrice)
                    //{
                    //    ArrayList priceListNew;

                    //    string key = prc.GoodsMakerCd + prc.GoodsNo;

                    //    if (priceDic.TryGetValue(key, out priceListNew))
                    //    {
                    //        priceListNew.Add(prc);
                    //    }
                    //    else
                    //    {
                    //        priceListNew = new ArrayList();
                    //        priceListNew.Add(prc);
                    //        priceDic.Add(key, priceListNew);
                    //    }
                    //}
                    //// ADD gezh 2013/01/24 Redmine#33361 ���C�ćB --------<<<<<
                    //foreach (GoodsUnitDataWork usrGoodsWork in al)
                    //{
                    //    /* ---------------- DEL gezh 2013/01/24 Redmine#33361 ���C�ćB -------->>>>>
                    //    usrGoodsWork.PriceList = new ArrayList();
                    //    //foreach (UsrGoodsPriceWork prc in usrGoodsPrice)
                    //    foreach (GoodsPriceUWork prc in usrGoodsPrice)
                    //    {
                    //        if (usrGoodsWork.GoodsMakerCd == prc.GoodsMakerCd &&
                    //            usrGoodsWork.GoodsNo == prc.GoodsNo)
                    //        {
                    //            usrGoodsWork.PriceList.Add(prc);
                    //        }
                    //    }
                    //    <<<<<-------------- DEL gezh 2013/01/24 Redmine#33361 ���C�ćB ---------- */
                    //    // ADD gezh 2013/01/24 Redmine#33361 -------->>>>>
                    //    ArrayList priceListNew;
                    //    usrGoodsWork.PriceList = new ArrayList();
                    //    string key = usrGoodsWork.GoodsMakerCd + usrGoodsWork.GoodsNo;
                    //    if (priceDic.TryGetValue(key, out priceListNew))
                    //    {
                    //        usrGoodsWork.PriceList.AddRange(priceListNew);
                    //    }
                    //    // ADD gezh 2013/01/24 Redmine#33361 --------<<<<<
                    //}
                    // --- DEL yangyi 2013/03/18 for Redmine#34962 -------<<<<<<<<<<<
                    // --- ADD yangyi 2013/03/18 for Redmine#34962 ------->>>>>>>>>>>
                    foreach (GoodsPriceUWork prc in usrGoodsPrice)
                    {
                        ArrayList priceListNew;

                        string key = prc.GoodsMakerCd + "," + prc.GoodsNo;

                        if (priceDic.TryGetValue(key, out priceListNew))
                        {
                            priceListNew.Add(prc);
                        }
                        else
                        {
                            priceListNew = new ArrayList();
                            priceListNew.Add(prc);
                            priceDic.Add(key, priceListNew);
                        }
                    }
                    // --- ADD yangyi 2013/03/18 for Redmine#34962 -------<<<<<<<<<<<
                }
                else
                {
                    foreach (GoodsUnitDataWork usrGoodsWork in al)
                    {
                        usrGoodsWork.PriceList = new ArrayList();
                    }
                }

                // -- ADD 2011/03/17 ------------->>>
                if (stockSearchDiv == 0)
                {
                    // -- ADD 2011/03/17 -------------<<<
                    // --- DEL yangyi 2013/03/18 for Redmine#34962 ------->>>>>>>>>>>
                    //foreach (GoodsUnitDataWork usrGoodsWork in al)
                    //{
                    //    ArrayList stockRetList;
                    //    StockDB stockDB = new StockDB();

                    //    StockWork stockWk = new StockWork();
                    //    stockWk.EnterpriseCode = usrGoodsWork.EnterpriseCode;
                    //    stockWk.GoodsMakerCd = usrGoodsWork.GoodsMakerCd;
                    //    stockWk.GoodsNo = usrGoodsWork.GoodsNo;
                    //    status = stockDB.SearchStockProc(out stockRetList, stockWk, 0, logicalMode, ref sqlConnection);
                    //    if (status == 0)
                    //    {
                    //        usrGoodsWork.StockList = stockRetList;
                    //    }
                    //    else
                    //    {
                    //        usrGoodsWork.StockList = new ArrayList();
                    //    }
                    //}
                    // --- DEL yangyi 2013/03/18 for Redmine#34962 -------<<<<<<<<<<<
                    // --- ADD yangyi 2013/03/18 for Redmine#34962 ------->>>>>>>>>>>
                    if (al.Count > 0)
                    {
                        StockDB stockDB = new StockDB();
                        StockWork stockWk = new StockWork();

                        ArrayList stockRetList;
                        stockWk.EnterpriseCode = ((GoodsUnitDataWork)al[0]).EnterpriseCode;
                        stockWk.GoodsMakerCd = goodsrelationdataWork.GoodsMakerCd;
                        stockWk.GoodsNo = goodsrelationdataWork.GoodsNo;

                        //----- ADD 2015/08/17 �c���� Redmine#47036 ---------->>>>>
                        stockWk.SectionCode = goodsrelationdataWork.AddUpSectionCode; // �Ǘ����_�R�[�h
                        stockWk.WarehouseCode = goodsrelationdataWork.WarehouseCode; // �q�ɃR�[�h
                        //----- ADD 2015/08/17 �c���� Redmine#47036 ----------<<<<<

                        status = this.SearchStockProc(out stockRetList, stockWk, 0, logicalMode, ref sqlConnection);

                        if (status == 0)
                        {
                            foreach (StockWork prc in stockRetList)
                            {
                                ArrayList stockListNew;
                                string key = prc.GoodsMakerCd + "," + prc.GoodsNo;

                                if (stockDic.TryGetValue(key, out stockListNew))
                                {
                                    stockListNew.Add(prc);
                                }
                                else
                                {
                                    stockListNew = new ArrayList();
                                    stockListNew.Add(prc);
                                    stockDic.Add(key, stockListNew);
                                }
                            }
                        }
                    }
                    // --- ADD yangyi 2013/03/18 for Redmine#34962 -------<<<<<<<<<<<
                }  // -- ADD 2011/03/17

                // --- ADD yangyi 2013/03/18 for Redmine#34962 ------->>>>>>>>>>>

                if (targetDiv == 0 || targetDiv == 1 || targetDiv == 3)
                {
                    foreach (GoodsUnitDataWork work in al)
                    {
                        ArrayList priceListNew;
                        work.PriceList = new ArrayList();
                        string key = work.GoodsMakerCd + "," + work.GoodsNo;
                        if (priceDic.TryGetValue(key, out priceListNew))
                        {
                            work.PriceList.AddRange(priceListNew);
                        }

                        if (stockSearchDiv == 0)
                        {
                            ArrayList stockListNew;
                            work.StockList = new ArrayList();

                            if (stockDic.TryGetValue(key, out stockListNew))
                            {
                                work.StockList.AddRange(stockListNew);
                            }
                        }
                    }
                    goodsrelationdataWorkList = al;
                }

                if (targetDiv == 2)
                {
                    int num = 0;�@//�݌Ɍ���

                    foreach (GoodsUnitDataWork work in al)
                    {
                        // --- ADD yangyi 2013/04/27 for Redmine#35018 ------->>>>>>>>>>>
                        if (work.LogicalDeleteCode!=0)
                        {
                            continue;
                        }
                        // --- ADD yangyi 2013/04/27 for Redmine#35018 -------<<<<<<<<<<<

                        //�݌ɐ����ő吧������
                        if (num >= maxCount)
                        {
                            break;
                        }

                        ArrayList priceListNew;
                        work.PriceList = new ArrayList();
                        string key = work.GoodsMakerCd + "," + work.GoodsNo;
                        if (priceDic.TryGetValue(key, out priceListNew))
                        {
                            work.PriceList.AddRange(priceListNew);
                        }

                        if (stockSearchDiv == 0)
                        {
                            ArrayList stockListNew;
                            work.StockList = new ArrayList();

                            if (stockDic.TryGetValue(key, out stockListNew))
                            {
                                num = num + stockListNew.Count; //�݌Ɍ����̌v�Z
                                work.StockList.AddRange(stockListNew);
                                retList.Add(work);   //ADD yangyi 2013/04/23 Redmine#35018
                            }
                        }
                        //retList.Add(work);     //DEL yangyi 2013/04/23 Redmine#35018
                    }   

                    goodsrelationdataWorkList = retList;
                    
                }
                // --- ADD yangyi 2013/03/18 for Redmine#34962 -------<<<<<<<<<<<
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }


        /// <summary>
        /// �w�肳�ꂽ�����̍݌ɏ��LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="stockWorkList">��������</param>
        /// <param name="stockWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌ɏ��LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : yangyi</br>
        /// <br>Date       : 2013.04.01</br>
        /// <br>Update Note: 2013/05/11 yangyi</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 20150515�z�M���̑Ή�</br>
        /// <br>           : Redmine#35018 �u���i�݌Ɉꊇ�C���v�̃T�[�o�[���׌y���@���̂Q�Ή�</br>
        private int SearchStockProc(out ArrayList stockWorkList, StockWork stockWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string selectTxt = "";
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "   STOCK.CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "  ,SEC.SECTIONGUIDENMRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "  ,WARE.WAREHOUSENAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.GOODSNORF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKUNITPRICEFLRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SUPPLIERSTOCKRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.ACPODRCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MONTHORDERCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SALESORDERCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKDIVRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MOVINGSUPLISTOCKRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SHIPMENTPOSCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKTOTALPRICERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.LASTSTOCKDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.LASTSALESDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.LASTINVENTORYUPDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MINIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MAXIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.NMLSALODRCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SALESORDERUNITRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKSUPPLIERCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.GOODSNONONEHYPHENRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.WAREHOUSESHELFNORF" + Environment.NewLine;
                selectTxt += "  ,STOCK.DUPLICATIONSHELFNO1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.DUPLICATIONSHELFNO2RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.PARTSMANAGEMENTDIVIDE1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.PARTSMANAGEMENTDIVIDE2RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKNOTE1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKNOTE2RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SHIPMENTCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.ARRIVALCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKCREATEDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDATEDATERF" + Environment.NewLine;
                selectTxt += "FROM STOCKRF AS STOCK WITH (READUNCOMMITTED) " + Environment.NewLine;
                selectTxt += "LEFT JOIN SECINFOSETRF AS SEC WITH (READUNCOMMITTED) " + Environment.NewLine;
                selectTxt += "ON " + Environment.NewLine;
                selectTxt += "     STOCK.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND STOCK.SECTIONCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "LEFT JOIN WAREHOUSERF AS WARE WITH (READUNCOMMITTED) " + Environment.NewLine;
                selectTxt += "ON " + Environment.NewLine;
                selectTxt += "     STOCK.ENTERPRISECODERF=WARE.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND STOCK.WAREHOUSECODERF=WARE.WAREHOUSECODERF" + Environment.NewLine;

                if (!string.IsNullOrEmpty(stockWork.GoodsNo))
                {
                    selectTxt += " LEFT JOIN GOODSURF GOODS ON GOODS.GOODSNORF = STOCK.GOODSNORF " + Environment.NewLine;
                    selectTxt += " AND GOODS.GOODSMAKERCDRF = STOCK.GOODSMAKERCDRF " + Environment.NewLine;
                    selectTxt += " AND GOODS.ENTERPRISECODERF = STOCK.ENTERPRISECODERF " + Environment.NewLine;
                }

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                //��ƃR�[�h
                sqlCommand.CommandText += " WHERE STOCK.ENTERPRISECODERF=@ENTERPRISECODE ";
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockWork.EnterpriseCode);

                //�_���폜�敪
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    sqlCommand.CommandText += "AND STOCK.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    sqlCommand.CommandText += "AND STOCK.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }

                //���_�R�[�h
                if (string.IsNullOrEmpty(stockWork.SectionCode) == false)
                {
                    sqlCommand.CommandText += " AND STOCK.SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    paraSectionCode.Value = SqlDataMediator.SqlSetString(stockWork.SectionCode);
                }

                //�q�ɃR�[�h
                if (string.IsNullOrEmpty(stockWork.WarehouseCode) == false)
                {
                    sqlCommand.CommandText += " AND STOCK.WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine;
                    SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                    paraWarehouseCode.Value = SqlDataMediator.SqlSetString(stockWork.WarehouseCode);
                }

                //--- ADD 2013/05/11 yangyi Redmine#35018��#53-No.8 ----->>>>>
                ////���i�ԍ�
                //if (string.IsNullOrEmpty(stockWork.GoodsNo) == false)
                //{
                //    sqlCommand.CommandText += " AND GOODS.GOODSNONONEHYPHENRF LIKE @FINDGOODSNO " + Environment.NewLine;
                //    SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                //    paraGoodsNo.Value = SqlDataMediator.SqlSetString(stockWork.GoodsNo + "%");
                //}
                //--- ADD 2013/05/11 yangyi Redmine#35018��#53-No.8 -----<<<<<

                //--- ADD 2013/05/11 yangyi Redmine#35018��#53-No.8 ----->>>>>
                //���i�ԍ�
                if (string.IsNullOrEmpty(stockWork.GoodsNo) == false)
                {
                    //�n�C�t�������i�Ԃɕϊ�
                    string goodsNoNoneHyphen = stockWork.GoodsNo.Replace("-", "");

                    //�O����v����
                    goodsNoNoneHyphen = goodsNoNoneHyphen + "%";

                    //�n�C�t�������i�Ԋ��S��v�����̏ꍇ
                    sqlCommand.CommandText += ("AND GOODS.GOODSNONONEHYPHENRF LIKE @GOODSNONONEHYPHEN ");
                
                    SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNONONEHYPHEN", SqlDbType.NChar);
                    paraGoodsNo.Value = SqlDataMediator.SqlSetString(goodsNoNoneHyphen);

                }
                //--- ADD 2013/05/11 yangyi Redmine#35018��#53-No.8 -----<<<<<

                //���i���[�J�[�R�[�h
                if (stockWork.GoodsMakerCd != 0)
                {
                    sqlCommand.CommandText += " AND STOCK.GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                    SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockWork.GoodsMakerCd);
                }

                sqlCommand.CommandTimeout = 60;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToStockWorkFromReader(ref myReader, 0));

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
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            stockWorkList = al;

            return status;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� StockWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="mode">0:�ʃ}�X�^����̎擾���ڂ��Z�b�g</param>
        /// <returns>StockWork</returns>
        /// <remarks>
        /// <br>Programmer : yangyi</br>
        /// <br>Date       : 2013.04.01</br>
        /// </remarks>
        public StockWork CopyToStockWorkFromReader(ref SqlDataReader myReader, int mode)
        {
            StockWork wkStockWork = new StockWork();

            #region �N���X�֊i�[
            wkStockWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkStockWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkStockWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkStockWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkStockWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkStockWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkStockWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkStockWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkStockWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkStockWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
            wkStockWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            wkStockWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            wkStockWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
            wkStockWork.SupplierStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERSTOCKRF"));
            wkStockWork.AcpOdrCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPODRCOUNTRF"));
            wkStockWork.MonthOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MONTHORDERCOUNTRF"));
            wkStockWork.SalesOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESORDERCOUNTRF"));
            wkStockWork.StockDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKDIVRF"));
            wkStockWork.MovingSupliStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MOVINGSUPLISTOCKRF"));
            wkStockWork.ShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTPOSCNTRF"));
            wkStockWork.StockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPRICERF"));
            wkStockWork.LastStockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTSTOCKDATERF"));
            wkStockWork.LastSalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTSALESDATERF"));
            wkStockWork.LastInventoryUpdate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTINVENTORYUPDATERF"));
            wkStockWork.MinimumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MINIMUMSTOCKCNTRF"));
            wkStockWork.MaximumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MAXIMUMSTOCKCNTRF"));
            wkStockWork.NmlSalOdrCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("NMLSALODRCOUNTRF"));
            wkStockWork.SalesOrderUnit = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERUNITRF"));
            wkStockWork.StockSupplierCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSUPPLIERCODERF"));
            wkStockWork.GoodsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNONONEHYPHENRF"));
            wkStockWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
            wkStockWork.DuplicationShelfNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO1RF"));
            wkStockWork.DuplicationShelfNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO2RF"));
            wkStockWork.PartsManagementDivide1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE1RF"));
            wkStockWork.PartsManagementDivide2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE2RF"));
            wkStockWork.StockNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKNOTE1RF"));
            wkStockWork.StockNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKNOTE2RF"));
            wkStockWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
            wkStockWork.ArrivalCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ARRIVALCNTRF"));
            wkStockWork.StockCreateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKCREATEDATERF"));
            wkStockWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));

            if (mode == 0)
            {
                wkStockWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
                wkStockWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
            }
            #endregion

            return wkStockWork;
        }

        /// <summary>
        /// �艿���擾
        /// </summary>
        /// <param name="goodsrelationdataWork">���[�U�[�����������o�����N���X���[�N</param>
        /// <param name="usrGoodsPrice">���i���iList</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <returns></returns>
        private int SearchUsrGoodsPriceAllProc(GoodsUCndtnWork goodsrelationdataWork, out ArrayList usrGoodsPrice, ConstantManagement.LogicalMode logicalMode, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            usrGoodsPrice = new ArrayList();
            try
            {
                status = ExecutePriceQueryAll(goodsrelationdataWork, usrGoodsPrice, logicalMode, sqlConnection);

                if (status != 0) return status;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UsrJoinPartsSearchDB.SearchUsrGoodsPrice�ɂăG���[���� Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// �艿���擾
        /// </summary>
        /// <param name="goodsrelationdataWork">���o�����N���X���[�N</param>
        /// <param name="usrGoodsPrice">���i���iList</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <br>Update Note: K2013/07/23 ������</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 Redmine#38624</br>
        /// <br>           : ���i�݌Ɉꊇ�C���̑Ή��i��34962�̃f�O���j</br>
        /// <br>Update Note: K2013/10/08 gezh</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00</br>
        /// <br>           : Redmine#38624 �@���i�݌Ɉꊇ�C���̏�Q��17�Ή�</br>
        /// <br>Update Note: 2020/06/18 杍^</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br>           : PMKOBETSU-4005 �d�a�d�΍�</br>
        /// <returns></returns>
        private int ExecutePriceQueryAll(GoodsUCndtnWork goodsrelationdataWork, ArrayList usrGoodsPrice, ConstantManagement.LogicalMode logicalMode, SqlConnection sqlConnection)
        {
            int status = 0;
            SqlDataReader myReader = null;
            //�擾�}�X�^����
            string selectstr = "SELECT "
                        + "GOODSPRICEURF.CREATEDATETIMERF, "
                        + "GOODSPRICEURF.UPDATEDATETIMERF, "
                        + "GOODSPRICEURF.ENTERPRISECODERF, "
                        + "GOODSPRICEURF.FILEHEADERGUIDRF, "
                        + "GOODSPRICEURF.UPDEMPLOYEECODERF, "
                        + "GOODSPRICEURF.UPDASSEMBLYID1RF, "
                        + "GOODSPRICEURF.UPDASSEMBLYID2RF, "
                        + "GOODSPRICEURF.LOGICALDELETECODERF, "

                        + "GOODSPRICEURF.GOODSMAKERCDRF, "
                        + "GOODSPRICEURF.GOODSNORF, "
                        + "GOODSPRICEURF.PRICESTARTDATERF, "
                        + "GOODSPRICEURF.LISTPRICERF, "
                        + "GOODSPRICEURF.SALESUNITCOSTRF, "
                        + "GOODSPRICEURF.STOCKRATERF, "
                        + "GOODSPRICEURF.OPENPRICEDIVRF, "
                        + "GOODSPRICEURF.OFFERDATERF, "
                        + "GOODSPRICEURF.UPDATEDATERF "
                        + "FROM GOODSPRICEURF ";

            //if (!string.IsNullOrEmpty(goodsrelationdataWork.GoodsNo))// DEL BY ������ K2013/07/23 for Redmine#38624
            if (!string.IsNullOrEmpty(goodsrelationdataWork.GoodsNo) || goodsrelationdataWork.BLGoodsCode > 0) // ADD BY ������ K2013/07/23 for Redmine#38624
            {
                selectstr += " LEFT JOIN GOODSURF GOODS ON GOODS.GOODSNORF = GOODSPRICEURF.GOODSNORF ";
                selectstr += " AND GOODS.GOODSMAKERCDRF = GOODSPRICEURF.GOODSMAKERCDRF ";
                selectstr += " AND GOODS.ENTERPRISECODERF = GOODSPRICEURF.ENTERPRISECODERF ";
            }

            //----- ADD 2020/06/18 杍^ PMKOBETSU-4005 ---------->>>>>
            // �ϊ����Ăяo��
            ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

            // �ϊ���񏉊���
            convertDoubleRelease.ReleaseInitLib();
            //----- ADD 2020/06/18 杍^ PMKOBETSU-4005 ----------<<<<<

            try
            {
                SqlCommand sqlCommand = new SqlCommand(selectstr, sqlConnection);

                sqlCommand.CommandText += "WHERE GOODSPRICEURF.ENTERPRISECODERF = @FINDENTERPRISECODE";

                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    sqlCommand.CommandText += " AND GOODSPRICEURF.LOGICALDELETECODERF=@FINDLOGICALDELETECODE  ";
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    sqlCommand.CommandText += " AND GOODSPRICEURF.LOGICALDELETECODERF<@FINDLOGICALDELETECODE  ";
                }

                ((SqlParameter)sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar)).Value
                    = SqlDataMediator.SqlSetString(goodsrelationdataWork.EnterpriseCode);

                ((SqlParameter)sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int)).Value
                                    = SqlDataMediator.SqlSetInt32((Int32)logicalMode);

                //���i�R�[�h
                if (SqlDataMediator.SqlSetString(goodsrelationdataWork.GoodsNo) != DBNull.Value)
                {
                    if (goodsrelationdataWork.GoodsNoSrchTyp != 0)
                    {
                        //�n�C�t�������i�Ԃɕϊ�
                        string goodsNoNoneHyphen = goodsrelationdataWork.GoodsNo.Replace("-", "");

                        if (goodsrelationdataWork.GoodsNoSrchTyp != 4)
                        {
                            sqlCommand.CommandText += ("AND GOODS.GOODSNONONEHYPHENRF LIKE @GOODSNONONEHYPHEN ");
                            //�O����v�����̏ꍇ
                            if (goodsrelationdataWork.GoodsNoSrchTyp == 1) goodsNoNoneHyphen = goodsNoNoneHyphen + "%";
                            //�����v�����̏ꍇ
                            if (goodsrelationdataWork.GoodsNoSrchTyp == 2) goodsNoNoneHyphen = "%" + goodsNoNoneHyphen;
                            //�����܂������̏ꍇ
                            if (goodsrelationdataWork.GoodsNoSrchTyp == 3) goodsNoNoneHyphen = "%" + goodsNoNoneHyphen + "%";

                        }
                        else
                        {
                            //�n�C�t�������i�Ԋ��S��v�����̏ꍇ
                            sqlCommand.CommandText += ("AND GOODS.GOODSNONONEHYPHENRF=@GOODSNONONEHYPHEN ");
                        }

                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNONONEHYPHEN", SqlDbType.NChar);
                        paraGoodsNo.Value = SqlDataMediator.SqlSetString(goodsNoNoneHyphen);
                    }
                    else
                    {
                        sqlCommand.CommandText += ("AND GOODS.GOODSNORF=@GOODSNO ");

                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NChar);
                        paraGoodsNo.Value = SqlDataMediator.SqlSetString(goodsrelationdataWork.GoodsNo);
                    }

                }

                //���[�J�[�R�[�h
                if (goodsrelationdataWork.GoodsMakerCd > 0)
                {
                    sqlCommand.CommandText += ("AND GOODSPRICEURF.GOODSMAKERCDRF=@GOODSMAKERCD ");
                    SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                    paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsrelationdataWork.GoodsMakerCd);
                }

                //BL���i�R�[�h
                if (goodsrelationdataWork.BLGoodsCode > 0)
                {
                    sqlCommand.CommandText += ("AND GOODS.BLGOODSCODERF=@BLGOODSCODE ");
                    SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                    paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(goodsrelationdataWork.BLGoodsCode);
                }
                sqlCommand.CommandText += "ORDER BY GOODSPRICEURF.PRICESTARTDATERF DESC";  // ���i�J�n���~���\���@�@// ADD BY gezh K2013/10/08 for Redmine#38624

                sqlCommand.CommandTimeout = 60;

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    GoodsPriceUWork mf = new GoodsPriceUWork();

                    mf.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    mf.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    mf.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    mf.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    mf.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    mf.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    mf.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    mf.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                    mf.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    mf.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    mf.PriceStartDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICESTARTDATERF"));
                    //----- UPD 2020/06/18 杍^ PMKOBETSU-4005 ---------->>>>>
                    //mf.ListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF"));
                    convertDoubleRelease.EnterpriseCode = mf.EnterpriseCode;
                    convertDoubleRelease.GoodsMakerCd = mf.GoodsMakerCd;
                    convertDoubleRelease.GoodsNo = mf.GoodsNo;
                    convertDoubleRelease.ConvertSetParam = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF"));

                    // �ϊ��������s
                    convertDoubleRelease.ReleaseProc();

                    mf.ListPrice = convertDoubleRelease.ConvertInfParam.ConvertGetParam;
                    //----- UPD 2020/06/18 杍^ PMKOBETSU-4005 ----------<<<<<
                    mf.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));
                    mf.StockRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKRATERF"));
                    mf.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
                    mf.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    mf.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));
                    usrGoodsPrice.Add(mf);
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed) myReader.Close();
                //----- ADD 2020/06/18 杍^ PMKOBETSU-4005 ---------->>>>>
                // ���
                convertDoubleRelease.Dispose();
                //----- ADD 2020/06/18 杍^ PMKOBETSU-4005 ----------<<<<<
            }
            return status;
        }
        // --- ADD yangyi 2013/03/18 for Redmine#34962 -------<<<<<<<<<<<

        #endregion
        // --- ADD yangyi 2013/03/18 for Redmine#34962 -------<<<<<<<<<<<
    }
}
