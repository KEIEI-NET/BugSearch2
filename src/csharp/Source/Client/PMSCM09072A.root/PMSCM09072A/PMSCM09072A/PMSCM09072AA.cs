//********************************************************************//
// System           :   PM.NS                                         //
// Sub System       :                                                 //
// Program name     :   ����A�g�ݒ�e�[�u���A�N�Z�X�N���X            //
//                  :   PMSCM09072A.DLL                               //
// Name Space       :   Broadleaf.Application.Controller              //
// Programmer       :   gaoy                                          //
// Date             :   2011.07.21                                    //
//--------------------------------------------------------------------//
// Update Note      :                                                 //
//--------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.               //
//********************************************************************//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Xml.Serialization;
using System.Runtime.Remoting;
using System.Collections;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ����A�g�ݒ�e�[�u���A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   ����A�g�ݒ�e�[�u���̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer       :   gaoy</br>
    /// <br>Date             :   2011/7/21</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class PM7RkSettingAcs
    {
        #region << Private Members >>

        //�����[�g�I�u�W�F�N�g�i�[�o�b�t�@
        private IPM7RkSettingDB _iPM7RkSettingDB = null;


        #endregion

        #region << Conductor >>

        public PM7RkSettingAcs()
        {
            try{
                // �����[�g�I�u�W�F�N�g�擾
                this._iPM7RkSettingDB = (IPM7RkSettingDB)MediationPM7RkSettingDB.GetPM7RkSettingDB();
            }
            catch(Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iPM7RkSettingDB = null;
            }
        }

        #endregion

        #region << Read Methods >>

        /// <summary>
        /// ����A�g�ݒ�ǂݍ��ݏ��� (�ʏ�)
        /// </summary>
        /// <param name="pm7RkSetting">����A�g�ݒ�I�u�W�F�N�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ����A�g�ݒ�̓ǂݍ��݂��s���܂��B</br>
        /// <br>Programmer       :   gaoy</br>
        /// <br>Date             :   2011/7/22</br>
        /// <br>Update Note      :   </br>
        /// </remarks>
        public int Read(ref PM7RkSetting pm7RkSetting)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            try
            {
                PM7RkSettingWork pm7RkSettingWork = new PM7RkSettingWork();

                pm7RkSettingWork.EnterpriseCode = pm7RkSetting.EnterpriseCode;
                pm7RkSettingWork.SectionCode = pm7RkSetting.SectionCode;

                ArrayList pm7RkSettingArray = new ArrayList();
                pm7RkSettingArray.Add(pm7RkSettingWork);
                try
                {
                    status = this._iPM7RkSettingDB.Read(ref pm7RkSettingArray, 0);
                }
                catch (RemotingException)
                {
                    status = 10;
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    pm7RkSettingWork = (PM7RkSettingWork)pm7RkSettingArray[0];

                    if (pm7RkSettingWork != null)
                    {
                        pm7RkSetting = this.CopyToPM7RkSettingFromPM7RkSettingWork(pm7RkSettingWork);
                    }
                }
            }
            catch (Exception)
            {
                pm7RkSetting = null;
                this._iPM7RkSettingDB = null;
            }

            return status;
        }

        #endregion

        #region << Write Methods >>

        /// <summary>
        /// ����A�g�ݒ菑�����ݏ��� (�ʏ�)
        /// </summary>
        /// <param name="pm7RkSetting">����A�g�ݒ�I�u�W�F�N�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ����A�g�ݒ�̏������݂��s���܂��B</br>
        /// <br>Programmer       :   gaoy</br>
        /// <br>Date             :   2011/7/22</br>
        /// <br>Update Note      :   </br>
        /// </remarks>
        public int Write(ref PM7RkSetting pm7RkSetting)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            try
            {
                PM7RkSettingWork pm7RkSettingWork = this.CopyToPM7RkSettingWorkFromPM7RkSetting(pm7RkSetting);

                byte[] parabyte = XmlByteSerializer.Serialize(pm7RkSettingWork);
                try
                {
                    status = this._iPM7RkSettingDB.Write(ref parabyte);
                }
                catch(Exception)
                {
                    status = -1;
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    pm7RkSettingWork = (PM7RkSettingWork)XmlByteSerializer.Deserialize(parabyte, typeof(PM7RkSettingWork));
                    pm7RkSetting = this.CopyToPM7RkSettingFromPM7RkSettingWork(pm7RkSettingWork);
                }
            }
            catch (Exception)
            {
                this._iPM7RkSettingDB = null;
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        #endregion

        #region << Class Member Copy Methods >>

        /// <summary>
        /// �N���X�����o�R�s�[�����i����A�g�ݒ�N���X������A�g�ݒ胏�[�N�N���X�j
        /// </summary>
        /// <param name="alItmDspNm">����A�g�ݒ�N���X</param>
        /// <returns>����A�g�ݒ胏�[�N�N���X</returns>
        /// <remarks>
        /// <br>Note       : ����A�g�ݒ�N���X���甄��A�g�ݒ胏�[�N�N���X�փ����o�R�s�[���s���܂��B</br>
        /// <br>Programmer : gaoy</br>
        /// <br>Date       : 2011.07.23</br>
        /// </remarks>
        private PM7RkSettingWork CopyToPM7RkSettingWorkFromPM7RkSetting(PM7RkSetting pm7RkSetting)
        {
            PM7RkSettingWork pm7RkSettingWork = new PM7RkSettingWork();

            pm7RkSettingWork.CreateDateTime = pm7RkSetting.CreateDateTime;           //�쐬����
            pm7RkSettingWork.UpdateDateTime = pm7RkSetting.UpdateDateTime;           //�X�V����
            pm7RkSettingWork.EnterpriseCode = pm7RkSetting.EnterpriseCode;           //��ƃR�[�h
            pm7RkSettingWork.FileHeaderGuid = pm7RkSetting.FileHeaderGuid;           //GUID
            pm7RkSettingWork.UpdEmployeeCode = pm7RkSetting.UpdEmployeeCode;         //�X�V�]�ƈ��R�[�h
            pm7RkSettingWork.UpdAssemblyId1 = pm7RkSetting.UpdAssemblyId1;           //�X�V�A�Z���u��ID1
            pm7RkSettingWork.UpdAssemblyId2 = pm7RkSetting.UpdAssemblyId2;           //�X�V�A�Z���u��ID2
            pm7RkSettingWork.LogicalDeleteCode = pm7RkSetting.LogicalDeleteCode;     //�_���폜�敪
            pm7RkSettingWork.SectionCode = pm7RkSetting.SectionCode;                 //���_�R�[�h

            pm7RkSettingWork.SalesRkAutoCode = pm7RkSetting.SalesRkAutoCode;         //����A�g�����敪
            pm7RkSettingWork.SalesRkAutoSndTime = pm7RkSetting.SalesRkAutoSndTime;   //����A�g�������M�Ԋu
            pm7RkSettingWork.MasterRkAutoCode = pm7RkSetting.MasterRkAutoCode;       //�}�X�^�A�g�����敪
            pm7RkSettingWork.MasterRkAutoRcvTime = pm7RkSetting.MasterRkAutoRcvTime; //�}�X�^�A�g������M�Ԋu
            pm7RkSettingWork.TextSaveFolder = pm7RkSetting.TextSaveFolder;                   //�e�L�X�g�i�[�t�H���_

            return pm7RkSettingWork;
        }

        /// <summary>
        /// �N���X�����o�R�s�[�����i����A�g�ݒ胏�[�N�N���X������A�g�ݒ�N���X�j
        /// </summary>
        /// <param name="alItmDspNm">����A�g�ݒ胏�[�N�N���X</param>
        /// <returns>����A�g�ݒ�N���X</returns>
        /// <remarks>
        /// <br>Note       : ����A�g�ݒ胏�[�N�N���X���甄��A�g�ݒ�N���X�փ����o�R�s�[���s���܂��B</br>
        /// <br>Programmer : gaoy</br>
        /// <br>Date       : 2011.07.23</br>
        /// </remarks>
        private PM7RkSetting CopyToPM7RkSettingFromPM7RkSettingWork(PM7RkSettingWork pm7RkSettingWork)
        {
            PM7RkSetting pm7RkSetting = new PM7RkSetting();

            pm7RkSetting.CreateDateTime = pm7RkSettingWork.CreateDateTime;           //�쐬����
            pm7RkSetting.UpdateDateTime = pm7RkSettingWork.UpdateDateTime;           //�X�V����
            pm7RkSetting.EnterpriseCode = pm7RkSettingWork.EnterpriseCode;           //��ƃR�[�h
            pm7RkSetting.FileHeaderGuid = pm7RkSettingWork.FileHeaderGuid;           //GUID
            pm7RkSetting.UpdEmployeeCode = pm7RkSettingWork.UpdEmployeeCode;         //�X�V�]�ƈ��R�[�h
            pm7RkSetting.UpdAssemblyId1 = pm7RkSettingWork.UpdAssemblyId1;           //�X�V�A�Z���u��ID1
            pm7RkSetting.UpdAssemblyId2 = pm7RkSettingWork.UpdAssemblyId2;           //�X�V�A�Z���u��ID2
            pm7RkSetting.LogicalDeleteCode = pm7RkSettingWork.LogicalDeleteCode;     //�_���폜�敪
            pm7RkSetting.SectionCode = pm7RkSettingWork.SectionCode;                 //���_�R�[�h

            pm7RkSetting.SalesRkAutoCode = pm7RkSettingWork.SalesRkAutoCode;         //����A�g�����敪
            pm7RkSetting.SalesRkAutoSndTime = pm7RkSettingWork.SalesRkAutoSndTime;   //����A�g�������M�Ԋu
            pm7RkSetting.MasterRkAutoCode = pm7RkSettingWork.MasterRkAutoCode;       //�}�X�^�A�g�����敪
            pm7RkSetting.MasterRkAutoRcvTime = pm7RkSettingWork.MasterRkAutoRcvTime; //�}�X�^�A�g������M�Ԋu
            pm7RkSetting.TextSaveFolder = pm7RkSettingWork.TextSaveFolder;                   //�e�L�X�g�i�[�t�H���_
            
            return pm7RkSetting;
        }

        #endregion

    }
}
