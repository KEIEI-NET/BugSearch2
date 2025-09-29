using System;
using System.Collections;

namespace Broadleaf.Application.Controller
{
    /// public class name:   SearchCntSetWork
    /// <summary>
    ///                      ��������ݒ胏�[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ��������ݒ胏�[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/17</br>
    /// <br>Genarated Date   :   2008/09/29  (CSharp File Generated Date)</br>
    /// <br></br>
    /// <br>Update Note  : �������ςŁA�Z�b�g���\�����ɃG���[�ɂȂ錏�̑Ή�(MANTIS[0015177])</br>
    /// <br>               �E�J�X�^���R���X�g���N�^�A�N���[�����\�b�h�̒ǉ�</br>
    /// <br>Programmer   : 21024�@���X�� ��</br>
    /// <br>Date         : 2010/03/19</br>
    /// </remarks>
    public class SearchCntSetWork
    {
        /// <summary>��֏����敪</summary>
        /// <remarks>0:��ւ��Ȃ� 1:��ւ���(�݌ɖ�) 2:��ւ���i�݌ɖ����j</remarks>
        private Int32 _substCondDivCd;

        /// <summary>�D�Ǒ�֏����敪</summary>
        /// <remarks>0:��ւ��Ȃ� 1:��ւ���(�݌ɖ�) 2:��ւ���i�݌ɖ����j</remarks>
        private Int32 _prmSubstCondDivCd;

        /// <summary>��֓K�p�敪</summary>
        /// <remarks>0:���Ȃ�, 1:����(�����A�Z�b�g), 2:�S�āi�����A�Z�b�g�A�����j</remarks>
        private Int32 _substApplyDivCd;

        /// <summary>���i�����D�揇�敪[���g�p]</summary>
        /// <remarks>0:�����@1:�D��</remarks>
        private Int32 _partsSearchPriDivCd;

        /// <summary>���������\���敪</summary>
        /// <remarks>0:�\���� 1:�݌ɏ�</remarks>
        private Int32 _joinInitDispDiv;

        /// <summary>������ʐ���敪</summary>
        /// <remarks>0:PM7, 1:PM.NS</remarks>
        private Int32 _searchUICntDivCd;

        /// <summary>�G���^�[�L�[�����敪</summary>
        /// <remarks>0:PM7, 1:�I�� 2:����ʁi�����ˌ����A�����˃Z�b�g�A�Z�b�g�ˊm��j</remarks>
        private Int32 _enterProcDivCd;

        ///// <summary>�i�Ԍ����敪</summary>
        ///// <remarks>0:PM7�i�Z�b�g�̂݁j, 1:������Z�b�g���ւ���C</remarks>
        //private Int32 _partsNoSearchDivCd;

        ///// <summary>�i�Ԍ�������敪</summary>
        ///// <remarks>�����l�h.�h</remarks>
        //private string _partsJoinCntDivCd = "";

        /// <summary>�����\���敪�P</summary>
        /// <remarks>0:����@1:�a��i�N���j</remarks>
        private Int32 _eraNameDispCd1;

        /// <summary>���z�\�����@�敪</summary>
        /// <remarks>0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j</remarks>
        private Int32 _totalAmountDispWayCd;

        /// public propaty name  :  SubstCondDivCd
        /// <summary>��֏����敪�v���p�e�B</summary>
        /// <value>0:��ւ��Ȃ� 1:��ւ���(�݌ɖ�) 2:��ւ���i�݌ɖ����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��֏����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SubstCondDivCd
        {
            get { return _substCondDivCd; }
            set { _substCondDivCd = value; }
        }

        /// public propaty name  :  PrmSubstCondDivCd
        /// <summary>�D�Ǒ�֏����敪�v���p�e�B</summary>
        /// <value>0:��ւ��Ȃ� 1:��ւ���(�݌ɖ�) 2:��ւ���i�݌ɖ����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�Ǒ�֏����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrmSubstCondDivCd
        {
            get { return _prmSubstCondDivCd; }
            set { _prmSubstCondDivCd = value; }
        }

        /// public propaty name  :  SubstApplyDivCd
        /// <summary>��֓K�p�敪�v���p�e�B</summary>
        /// <value>0:���Ȃ�, 1:����(�����A�Z�b�g), 2:�S�āi�����A�Z�b�g�A�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��֓K�p�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SubstApplyDivCd
        {
            get { return _substApplyDivCd; }
            set { _substApplyDivCd = value; }
        }

        /// public propaty name  :  PartsSearchPriDivCd
        /// <summary>���i�����D�揇�敪�v���p�e�B[���g�p/SearchFlag���g������]</summary>
        /// <value>0:�����@1:�D��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����D�揇�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PartsSearchPriDivCd
        {
            get { return _partsSearchPriDivCd; }
            set { _partsSearchPriDivCd = value; }
        }

        /// public propaty name  :  JoinInitDispDiv
        /// <summary>���������\���敪�v���p�e�B</summary>
        /// <value>0:�\���� 1:�݌ɏ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������\���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 JoinInitDispDiv
        {
            get { return _joinInitDispDiv; }
            set { _joinInitDispDiv = value; }
        }

        /// public propaty name  :  SearchUICntDivCd
        /// <summary>������ʐ���敪�v���p�e�B</summary>
        /// <value>0:PM7, 1:PM.NS</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������ʐ���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SearchUICntDivCd
        {
            get { return _searchUICntDivCd; }
            set { _searchUICntDivCd = value; }
        }

        /// public propaty name  :  EnterProcDivCd
        /// <summary>�G���^�[�L�[�����敪�v���p�e�B</summary>
        /// <value>0:PM7, 1:�I�� 2:����ʁi�����ˌ����A�����˃Z�b�g�A�Z�b�g�ˊm��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �G���^�[�L�[�����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EnterProcDivCd
        {
            get { return _enterProcDivCd; }
            set { _enterProcDivCd = value; }
        }

        ///// public propaty name  :  PartsNoSearchDivCd
        ///// <summary>�i�Ԍ����敪�v���p�e�B</summary>
        ///// <value>0:PM7�i�Z�b�g�̂݁j, 1:������Z�b�g���ւ���C</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   �i�Ԍ����敪�v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public Int32 PartsNoSearchDivCd
        //{
        //    get { return _partsNoSearchDivCd; }
        //    set { _partsNoSearchDivCd = value; }
        //}

        ///// public propaty name  :  PartsJoinCntDivCd
        ///// <summary>�i�Ԍ�������敪�v���p�e�B</summary>
        ///// <value>�����l�h.�h</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   �i�Ԍ�������敪�v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public string PartsJoinCntDivCd
        //{
        //    get { return _partsJoinCntDivCd; }
        //    set { _partsJoinCntDivCd = value; }
        //}

        /// public propaty name  :  EraNameDispCd1
        /// <summary>�����\���敪�P�v���p�e�B</summary>
        /// <value>0:����@1:�a��i�N���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����\���敪�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EraNameDispCd1
        {
            get { return _eraNameDispCd1; }
            set { _eraNameDispCd1 = value; }
        }

        /// <summary>���z�\�����@�敪</summary>
        /// <remarks>0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j</remarks>
        public Int32 TotalAmountDispWayCd
        {
            get { return _totalAmountDispWayCd; }
            set { _totalAmountDispWayCd = value; }
        }

        /// <summary>
        /// ��������ݒ胏�[�N�R���X�g���N�^
        /// </summary>
        /// <returns>SearchCntSetWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SearchCntSetWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SearchCntSetWork()
        {
            _substCondDivCd = 0; // �f�t�H���g�@0:��ւ��Ȃ�
            _prmSubstCondDivCd = 0; // �f�t�H���g�@0:��ւ��Ȃ�
            _substApplyDivCd = 0; // �f�t�H���g�@0:���Ȃ�
            _searchUICntDivCd = 1; // �f�t�H���g�@1:PM.NS 
            _enterProcDivCd = 1; // �f�t�H���g�@1:�I��
            //_partsNoSearchDivCd = 0; // �f�t�H���g�@0:PM7�i�Z�b�g�̂݁j
            //_partsJoinCntDivCd = "."; // �f�t�H���g�@"."
            _eraNameDispCd1 = 0; // �f�t�H���g�@0:����
        }

        // 2010/03/19 Add >>>
        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="substCondDivCd"></param>
        /// <param name="prmSubstCondDivCd"></param>
        /// <param name="substApplyDivCd"></param>
        /// <param name="partsSearchPriDivCd"></param>
        /// <param name="joinInitDispDiv"></param>
        /// <param name="searchUICntDivCd"></param>
        /// <param name="enterProcDivCd"></param>
        /// <param name="eraNameDispCd1"></param>
        /// <param name="totalAmountDispWayCd"></param>
        public SearchCntSetWork(int substCondDivCd, int prmSubstCondDivCd, int substApplyDivCd, int partsSearchPriDivCd, int joinInitDispDiv, int searchUICntDivCd, int enterProcDivCd, int eraNameDispCd1, int totalAmountDispWayCd)
        {
            _substCondDivCd = substCondDivCd;

            _prmSubstCondDivCd = prmSubstCondDivCd;

            _substApplyDivCd = substApplyDivCd;

            _partsSearchPriDivCd = partsSearchPriDivCd;

            _joinInitDispDiv = joinInitDispDiv;

            _searchUICntDivCd = searchUICntDivCd;

            _enterProcDivCd = enterProcDivCd;

            _eraNameDispCd1 = eraNameDispCd1;

            _totalAmountDispWayCd = totalAmountDispWayCd;
        }

        /// <summary>
        /// �N���[������
        /// </summary>
        /// <returns></returns>
        public SearchCntSetWork Clone()
        {
            return new SearchCntSetWork(
                _substCondDivCd,
                _prmSubstCondDivCd,
                _substApplyDivCd,
                _partsSearchPriDivCd,
                _joinInitDispDiv,
                _searchUICntDivCd,
                _enterProcDivCd,
                _eraNameDispCd1,
                _totalAmountDispWayCd
                );
        }
        // 2010/03/19 Add <<<
    }
}
