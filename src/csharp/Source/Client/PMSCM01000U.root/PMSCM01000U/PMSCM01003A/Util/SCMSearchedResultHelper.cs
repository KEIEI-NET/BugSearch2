//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : SCM�|�b�v�A�b�v
// �v���O�����T�v   : �|�b�v�A�b�v�����̑�����s���܂��B
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H��
// �� �� ��  2009/09/10  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 21024�@���X�� ��
// �� �� ��  2010/03/02  �C�����e : �V���������ݐς����s��̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 21024�@���X�� ��
// �� �� ��  2010/04/19  �C�����e : �V���ʒm�̎�n�f�[�^�̕ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 21024�@���X�� ��
// �� �� ��  2011/01/27  �C�����e : �V���f�[�^����CMT�A�g�������O����悤�ɏC��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 21024�@���X�� ��
// �� �� ��  2011/02/25  �C�����e : �V�����Ɖ񓚕����擾����悤�ɏC��
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;

using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;
using Broadleaf.Application.UIData; // 2010/03/02 Add
using System.Collections;

namespace Broadleaf.Application.Controller.Util
{
    /// <summary>
    /// SCM I/O Writer::ScmSearch()���\�b�h�̌������ʃw���p�N���X
    /// </summary>
    public sealed class SCMSearchedResultHelper
    {
        #region <�J�E���^>

        /// <summary>�J�E���^</summary>
        private int _count;
        /// <summary>�J�E���^���擾���܂��B</summary>
        public int Count { get { return _count; } }

        // 2010/04/19 >>>
        //// 2010/03/02 Add >>>
        ///// <summary>�f�[�^���X�g</summary>
        //private List<ScmOdrData> _dataList = new List<ScmOdrData>();

        ///// <summary>�f�[�^���X�g</summary>
        //public List<ScmOdrData> DataList
        //{
        //    get { return _dataList; }
        //    set { _dataList = value; }
        //}
        //// 2010/03/02 Add <<<

        /// <summary>�f�[�^���X�g</summary>
        private List<ISCMOrderHeaderRecord> _dataList = new List<ISCMOrderHeaderRecord>();

        /// <summary>�f�[�^���X�g</summary>
        public List<ISCMOrderHeaderRecord> DataList
        {
            get { return _dataList; }
            set { _dataList = value; }
        }
        // 2010/04/19 <<<

        // 2011/02/18 Add >>>
        /// <summary>�f�[�^���X�g</summary>
        private List<ISCMOrderHeaderRecord> _answerdDataList = new List<ISCMOrderHeaderRecord>();

        /// <summary>�f�[�^���X�g</summary>
        public List<ISCMOrderHeaderRecord> AnswerdDataList
        {
            get { return _answerdDataList; }
            set { _answerdDataList = value; }
        }
        // 2011/02/18 Add <<<

        #endregion // </�J�E���^>

        #region <Constructor>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public SCMSearchedResultHelper() { }

        #endregion // </Constructor>

        // 2010/04/19 Add >>>
        /// <summary>�O��擾�X�V��</summary>
        private DateTime _lastUpdateDate;
        /// <summary>�O��擾�X�V����</summary>
        private int _lastUpdateTime;

        public DateTime LastUpdateDate
        {
            get { return _lastUpdateDate; }
            set { _lastUpdateDate = value; }
        }


        public int LastUpdateTime
        {
            get { return _lastUpdateTime; }
            set { _lastUpdateTime = value; }
        }

        // 2010/04/19 Add <<<

        // 2010/03/02 >>>
        #region �폜
        ///// <summary>
        ///// �{�����̍��ڂ𐔂��܂��B
        ///// </summary>
        ///// <param name="scmSearchedResultListItem">SCM I/O Writer::ScmSearch()�̌������ʂ̍���</param>
        //public void CountToday(CustomSerializeArrayList scmSearchedResultListItem)
        //{
        //    #region <Guard Phrase>

        //    if (scmSearchedResultListItem == null || scmSearchedResultListItem.Count.Equals(0)) return;

        //    #endregion // </Guard Phrase>

        //    SCMAcOdrDataWork scmHeaderData = scmSearchedResultListItem[0] as SCMAcOdrDataWork;
        //    if (scmHeaderData == null) return;

        //    int year    = scmHeaderData.UpdateDate.Year;
        //    int month   = scmHeaderData.UpdateDate.Month;
        //    int day     = scmHeaderData.UpdateDate.Day;

        //    DateTime today = DateTime.Today;
        //    if (year.Equals(today.Year) && month.Equals(today.Month) && day.Equals(today.Day))
        //    {
        //        _count++;
        //    }
        //}
        #endregion

        /// <summary>
        /// �{�����̍��ڂ𐔂��܂��B
        /// </summary>
        /// <param name="scmHeaderData">SCM I/O Writer::GetOrderNewCount()�̌������ʂ̍���</param>
        // 2010/04/19 >>>
        //public void CountToday(SCMAcOdrDataWork scmHeaderData)
        public void GetNewData(SCMAcOdrDataWork scmHeaderData)
        // 2010/04/19 <<<
        {
            if (scmHeaderData == null) return;

            // 2011/02/25 Del >>>
            //if (scmHeaderData.CMTCooprtDiv == 1) return;    // 2011/01/27 Add
            // 2011/02/25 Del <<<

            // 2010/04/19 >>>
            //int year = scmHeaderData.UpdateDate.Year;
            //int month = scmHeaderData.UpdateDate.Month;
            //int day = scmHeaderData.UpdateDate.Day;

            //DateTime today = DateTime.Today;
            //if (year.Equals(today.Year) && month.Equals(today.Month) && day.Equals(today.Day))

            if (( scmHeaderData.UpdateDate > _lastUpdateDate ) ||
                ( scmHeaderData.UpdateDate == _lastUpdateDate && scmHeaderData.UpdateTime > _lastUpdateTime ))
            // 2010/04/19 <<<
            {
                _count++;

                // 2010/04/19 >>>
                //// 2010/03/02 Add >>>
                //_dataList.Add(new ScmOdrData(
                //    scmHeaderData.CreateDateTime, 
                //    scmHeaderData.UpdateDateTime, 
                //    scmHeaderData.LogicalDeleteCode, 
                //    scmHeaderData.InqOriginalEpCd, 
                //    scmHeaderData.InqOriginalSecCd, 
                //    scmHeaderData.InqOtherEpCd, 
                //    scmHeaderData.InqOtherSecCd, 
                //    scmHeaderData.InquiryNumber, 
                //    scmHeaderData.UpdateDate,
                //    scmHeaderData.UpdateTime, 
                //    scmHeaderData.AnswerDivCd, 
                //    scmHeaderData.JudgementDate, 
                //    scmHeaderData.InqOrdNote, 
                //    scmHeaderData.InqEmployeeCd, 
                //    scmHeaderData.InqEmployeeNm, 
                //    scmHeaderData.AnsEmployeeCd, 
                //    scmHeaderData.AnsEmployeeNm, 
                //    scmHeaderData.InquiryDate, 
                //    scmHeaderData.InqOrdDivCd, 
                //    scmHeaderData.InqOrdAnsDivCd, 
                //    scmHeaderData.ReceiveDateTime, 
                //    0
                //    ));
                //// 2010/03/02 Add <<<

                // 2011/02/25 >>>
                //_dataList.Add(new UserSCMOrderHeaderRecord(scmHeaderData));
                if (scmHeaderData.AnswerDivCd == 20 || scmHeaderData.AnswerCreateDiv == 2) 
                {
                    // �񓚍ς݃f�[�^���X�g�ɒǉ�
                    _answerdDataList.Add(new UserSCMOrderHeaderRecord(scmHeaderData));
                }
                else
                {
                    // CMT�A�g�f�[�^�͑ΏۊO
                    if (scmHeaderData.CMTCooprtDiv == 1) return;

                    // �񓚊����f�[�^�͑ΏۊO
                    //if (scmHeaderData.AnswerDivCd == 20) return;

                    // �񓚊����f�[�^�͑ΏۊO
                    //if (scmHeaderData.AnswerCreateDiv == 0 && scmHeaderData.AnswerDivCd == 10) return;


                    // �V���f�[�^���X�g�ɒǉ�
                    _dataList.Add(new UserSCMOrderHeaderRecord(scmHeaderData));
                }
            
                // 2011/02/25 <<<
                // 2010/04/19 <<<
            }
        }

        // 2010/03/02 <<<

        // 2010/04/19 >>>
        #region �폜

        ///// <summary>
        ///// �{���̌������擾���܂��B
        ///// </summary>
        ///// <param name="scmSearchedResult">SCM I/O Writer::ScmSearch()�̌�������</param>
        ///// <returns>�������ʂ���SCM�󒍃f�[�^.�X�V�N�������{���ł�����̂̌�����Ԃ��܂��B</returns>
        //public static int GetCountOfToday(object scmSearchedResult)
        //{
        //    #region <Guard Phrase>

        //    if (scmSearchedResult == null) return 0;

        //    #endregion // </Guard Phrase>

        //    CustomSerializeArrayList scmSearchedResultListSource = scmSearchedResult as CustomSerializeArrayList;
        //    if (scmSearchedResultListSource == null || scmSearchedResultListSource.Count.Equals(0)) return 0;

        //    // 2010/03/02 >>>
        //    //List<CustomSerializeArrayList> scmSearchedResultList = new List<CustomSerializeArrayList>(
        //    //    (CustomSerializeArrayList[])scmSearchedResultListSource.ToArray(typeof(CustomSerializeArrayList))
        //    //);
        //    List<SCMAcOdrDataWork> scmSearchedResultList = new List<SCMAcOdrDataWork>(
        //        (SCMAcOdrDataWork[])scmSearchedResultListSource.ToArray(typeof(SCMAcOdrDataWork))
        //    );
        //    // 2010/03/02 <<<

        //    SCMSearchedResultHelper helper = new SCMSearchedResultHelper();
        //    scmSearchedResultList.ForEach(helper.CountToday);

        //    return helper.Count;
        //}

        //// 2010/03/02 Add >>>
        ///// <summary>
        ///// �{���̌������擾���܂��B
        ///// </summary>
        ///// <param name="scmSearchedResult">SCM I/O Writer::ScmSearch()�̌�������</param>
        ///// <returns>�������ʂ���SCM�󒍃f�[�^.�X�V�N�������{���ł�����̂̌�����Ԃ��܂��B</returns>
        //public static List<ScmOdrData> GetListOfToday(object scmSearchedResult)
        //{
        //    #region <Guard Phrase>

        //    if (scmSearchedResult == null) return null;

        //    #endregion // </Guard Phrase>

        //    CustomSerializeArrayList scmSearchedResultListSource = scmSearchedResult as CustomSerializeArrayList;
        //    if (scmSearchedResultListSource == null || scmSearchedResultListSource.Count.Equals(0)) return null;

        //    // 2010/03/02 >>>
        //    //List<CustomSerializeArrayList> scmSearchedResultList = new List<CustomSerializeArrayList>(
        //    //    (CustomSerializeArrayList[])scmSearchedResultListSource.ToArray(typeof(CustomSerializeArrayList))
        //    //);
        //    List<SCMAcOdrDataWork> scmSearchedResultList = new List<SCMAcOdrDataWork>(
        //        (SCMAcOdrDataWork[])scmSearchedResultListSource.ToArray(typeof(SCMAcOdrDataWork))
        //    );
        //    // 2010/03/02 <<<

            
        //    SCMSearchedResultHelper helper = new SCMSearchedResultHelper();
        //    scmSearchedResultList.ForEach(helper.CountToday);

        //    return helper.DataList;
        //}
        //// 2010/03/02 Add <<<
        #endregion

        /// <summary>
        /// �{���̌������擾���܂��B
        /// </summary>
        /// <param name="scmSearchedResult">SCM I/O Writer::ScmSearch()�̌�������</param>
        /// <returns>�������ʂ���SCM�󒍃f�[�^.�X�V�N�������{���ł�����̂̌�����Ԃ��܂��B</returns>
        // 2011/02/25 >>>
        //public static List<ISCMOrderHeaderRecord> GetNewList(object scmSearchedResult, DateTime lastUpdateDate, int lastUpdateTime)
        public static ArrayList GetNewList(object scmSearchedResult, DateTime lastUpdateDate, int lastUpdateTime)
        // 2011/02/25 <<<
        {
            #region <Guard Phrase>

            if (scmSearchedResult == null) return null;

            #endregion // </Guard Phrase>

            CustomSerializeArrayList scmSearchedResultListSource = scmSearchedResult as CustomSerializeArrayList;
            if (scmSearchedResultListSource == null || scmSearchedResultListSource.Count.Equals(0)) return null;

            List<SCMAcOdrDataWork> scmSearchedResultList = new List<SCMAcOdrDataWork>(
                (SCMAcOdrDataWork[])scmSearchedResultListSource.ToArray(typeof(SCMAcOdrDataWork))
            );

            SCMSearchedResultHelper helper = new SCMSearchedResultHelper();
            helper.LastUpdateDate = lastUpdateDate;
            helper.LastUpdateTime = lastUpdateTime;
            scmSearchedResultList.ForEach(helper.GetNewData);

            // 2011/02/25 Add >>>
            //return helper.DataList;

            ArrayList retList = new ArrayList();
            retList.Add(helper.DataList);
            retList.Add(helper.AnswerdDataList);
            return retList;
            // 2011/02/25 Add <<<
        }
        // 2010/04/19 <<<
    }
}
