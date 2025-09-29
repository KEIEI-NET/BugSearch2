using System;
using System.Collections;

using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   FrePStockMoveDetailWork
    /// <summary>
    ///                      ���R���[�݌Ɉړ����׃f�[�^���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���R���[�݌Ɉړ����׃f�[�^���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/25</br>
    /// <br>Genarated Date   :   2009/01/22  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class FrePStockMoveDetailWork
    {
        /// <summary>�݌Ɉړ��`��</summary>
        /// <remarks>1:�݌Ɉړ��A2�F�q�Ɉړ�</remarks>
        private Int32 _mOVD_STOCKMOVEFORMALRF;

        /// <summary>�݌Ɉړ��`�[�ԍ�</summary>
        private Int32 _mOVD_STOCKMOVESLIPNORF;

        /// <summary>�݌Ɉړ��s�ԍ�</summary>
        private Int32 _mOVD_STOCKMOVEROWNORF;

        /// <summary>�ړ������_�R�[�h</summary>
        private string _mOVD_BFSECTIONCODERF = "";

        /// <summary>�ړ����q�ɃR�[�h</summary>
        private string _mOVD_BFENTERWAREHCODERF = "";

        /// <summary>�ړ��拒�_�R�[�h</summary>
        private string _mOVD_AFSECTIONCODERF = "";

        /// <summary>�ړ���q�ɃR�[�h</summary>
        private string _mOVD_AFENTERWAREHCODERF = "";

        /// <summary>�d����R�[�h</summary>
        private Int32 _mOVD_SUPPLIERCDRF;

        /// <summary>�d���旪��</summary>
        private string _mOVD_SUPPLIERSNMRF = "";

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _mOVD_GOODSMAKERCDRF;

        /// <summary>���[�J�[����</summary>
        private string _mOVD_MAKERNAMERF = "";

        /// <summary>���i�ԍ�</summary>
        private string _mOVD_GOODSNORF = "";

        /// <summary>���i����</summary>
        private string _mOVD_GOODSNAMERF = "";

        /// <summary>���i���̃J�i</summary>
        private string _mOVD_GOODSNAMEKANARF = "";

        /// <summary>�݌ɋ敪</summary>
        /// <remarks>0:���ЁA1:���</remarks>
        private Int32 _mOVD_STOCKDIVRF;

        /// <summary>�d���P���i�Ŕ�,�����j</summary>
        /// <remarks>�݌Ɉړ�����݌ɂ̎d�����i�����Z�b�g</remarks>
        private Double _mOVD_STOCKUNITPRICEFLRF;

        /// <summary>�ېŋ敪</summary>
        /// <remarks>0:�ې�,1:��ې�,2:�ېŁi���Łj</remarks>
        private Int32 _mOVD_TAXATIONDIVCDRF;

        /// <summary>�ړ���</summary>
        private Double _mOVD_MOVECOUNTRF;

        /// <summary>�ړ����I��</summary>
        private string _mOVD_BFSHELFNORF = "";

        /// <summary>�ړ���I��</summary>
        private string _mOVD_AFSHELFNORF = "";

        /// <summary>BL���i�R�[�h</summary>
        private Int32 _mOVD_BLGOODSCODERF;

        /// <summary>BL���i�R�[�h���́i�S�p�j</summary>
        private string _mOVD_BLGOODSFULLNAMERF = "";

        /// <summary>�艿�i�����j</summary>
        private Double _mOVD_LISTPRICEFLRF;

        /// <summary>�ړ����</summary>
        /// <remarks>0:�ړ��ΏۊO�A1:���o�׏�ԁA2:�ړ����A9:���׍�</remarks>
        private Int32 _mOVD_MOVESTATUSRF;

        /// <summary>BL���i�R�[�h���́i���p�j</summary>
        private string _bLGOODSCDURF_BLGOODSHALFNAMERF = "";

        /// <summary>���[�J�[����</summary>
        private string _mAKERURF_MAKERSHORTNAMERF = "";

        /// <summary>���[�J�[�J�i����</summary>
        private string _mAKERURF_MAKERKANANAMERF = "";

        /// <summary>�d���I�ԂP</summary>
        private string _sTC1_DUPLICATIONSHELFNO1RF = "";

        /// <summary>�d���I�ԂQ</summary>
        private string _sTC1_DUPLICATIONSHELFNO2RF = "";

        /// <summary>���i�Ǘ��敪�P</summary>
        private string _sTC1_PARTSMANAGEMENTDIVIDE1RF = "";

        /// <summary>���i�Ǘ��敪�Q</summary>
        private string _sTC1_PARTSMANAGEMENTDIVIDE2RF = "";

        /// <summary>�݌ɔ��l�P</summary>
        private string _sTC1_STOCKNOTE1RF = "";

        /// <summary>�݌ɔ��l�Q</summary>
        private string _sTC1_STOCKNOTE2RF = "";

        /// <summary>�o�׉\��</summary>
        /// <remarks>�o�׉\�����d���݌ɐ��{����݌ɐ��|�i�d���݌ɕ��ϑ����{������ϑ����j�|�i�ړ����d���݌ɐ��{�ړ�������݌ɐ��j�|�󒍐�</remarks>
        private Double _sTC1_SHIPMENTPOSCNTRF;

        /// <summary>�d���I�ԂP</summary>
        private string _sTC2_DUPLICATIONSHELFNO1RF = "";

        /// <summary>�d���I�ԂQ</summary>
        private string _sTC2_DUPLICATIONSHELFNO2RF = "";

        /// <summary>���i�Ǘ��敪�P</summary>
        private string _sTC2_PARTSMANAGEMENTDIVIDE1RF = "";

        /// <summary>���i�Ǘ��敪�Q</summary>
        private string _sTC2_PARTSMANAGEMENTDIVIDE2RF = "";

        /// <summary>�݌ɔ��l�P</summary>
        private string _sTC2_STOCKNOTE1RF = "";

        /// <summary>�݌ɔ��l�Q</summary>
        private string _sTC2_STOCKNOTE2RF = "";

        /// <summary>�o�׉\��</summary>
        /// <remarks>�o�׉\�����d���݌ɐ��{����݌ɐ��|�i�d���݌ɕ��ϑ����{������ϑ����j�|�i�ړ����d���݌ɐ��{�ړ�������݌ɐ��j�|�󒍐�</remarks>
        private Double _sTC2_SHIPMENTPOSCNTRF;

        /// <summary>�d���於1</summary>
        private string _sUP_SUPPLIERNM1RF = "";

        /// <summary>�d���於2</summary>
        private string _sUP_SUPPLIERNM2RF = "";

        /// <summary>�d����h��</summary>
        private string _sUP_SUPPHONORIFICTITLERF = "";

        /// <summary>�d����J�i</summary>
        private string _sUP_SUPPLIERKANARF = "";

        /// <summary>�����敪</summary>
        /// <remarks>0:�����A1:�D��</remarks>
        private Int32 _sUP_PURECODERF;

        /// <summary>�d������l1</summary>
        private string _sUP_SUPPLIERNOTE1RF = "";

        /// <summary>�d������l2</summary>
        private string _sUP_SUPPLIERNOTE2RF = "";

        /// <summary>�d������l3</summary>
        private string _sUP_SUPPLIERNOTE3RF = "";

        /// <summary>�d������l4</summary>
        private string _sUP_SUPPLIERNOTE4RF = "";

        /// <summary>���i���̃J�i</summary>
        private string _gDS_GOODSNAMEKANARF = "";

        /// <summary>JAN�R�[�h</summary>
        private string _gDS_JANRF = "";

        /// <summary>���i�|�������N</summary>
        /// <remarks>�w��</remarks>
        private string _gDS_GOODSRATERANKRF = "";

        /// <summary>�n�C�t�������i�ԍ�</summary>
        private string _gDS_GOODSNONONEHYPHENRF = "";

        /// <summary>���i���l�P</summary>
        private string _gDS_GOODSNOTE1RF = "";

        /// <summary>���i���l�Q</summary>
        private string _gDS_GOODSNOTE2RF = "";

        /// <summary>���i�K�i�E���L����</summary>
        private string _gDS_GOODSSPECIALNOTERF = "";

        /// <summary>�݌ɋ敪����</summary>
        /// <remarks>0:���ЁA1:���</remarks>
        private string _dADD_STOCKDIVNMRF = "";

        /// <summary>�ېŋ敪����</summary>
        /// <remarks>0:�ې�,1:��ې�,2:�ېŁi���Łj</remarks>
        private string _dADD_TAXATIONDIVCDNMRF = "";

        /// <summary>�����敪����</summary>
        /// <remarks>0:�����A1:�D��</remarks>
        private string _dADD_PURECODENMRF = "";

        /// <summary>�ړ����z</summary>
        /// <remarks>�y�d���P���~�ړ����z</remarks>
        private Int64 _dADD_STOCKMOVEPRICERF;

        /// <summary>�ړ����z(�W�����i)</summary>
        /// <remarks>�y�艿�~�ړ����z</remarks>
        private Int64 _dADD_STOCKMOVELISTPRICERF;

        /// <summary>�ړ����ړ��O��</summary>
        /// <remarks>�ړ����q�ɂ̌��݌ɐ��i�ړ��O�j</remarks>
        private Double _dADD_BFSTOCKCOUNTPREVRF;

        /// <summary>�ړ����ړ��㐔</summary>
        /// <remarks>�ړ����q�ɂ̌��݌ɐ��i�ړ���j</remarks>
        private Double _dADD_BFSTOCKCOUNTRF;

        /// <summary>�ړ���ړ��O��</summary>
        /// <remarks>�ړ���q�ɂ̌��݌ɐ��i�ړ��O�j</remarks>
        private Double _dADD_AFSTOCKCOUNTPREVRF;

        /// <summary>�ړ���ړ��㐔</summary>
        /// <remarks>�ړ���q�ɂ̌��݌ɐ��i�ړ���j</remarks>
        private Double _dADD_AFSTOCKCOUNTRF;

        /// <summary>�ړ����z</summary>
        private Int64 _mOVD_STOCKMOVEPRICERF;


        /// public propaty name  :  MOVD_STOCKMOVEFORMALRF
        /// <summary>�݌Ɉړ��`���v���p�e�B</summary>
        /// <value>1:�݌Ɉړ��A2�F�q�Ɉړ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌Ɉړ��`���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MOVD_STOCKMOVEFORMALRF
        {
            get { return _mOVD_STOCKMOVEFORMALRF; }
            set { _mOVD_STOCKMOVEFORMALRF = value; }
        }

        /// public propaty name  :  MOVD_STOCKMOVESLIPNORF
        /// <summary>�݌Ɉړ��`�[�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌Ɉړ��`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MOVD_STOCKMOVESLIPNORF
        {
            get { return _mOVD_STOCKMOVESLIPNORF; }
            set { _mOVD_STOCKMOVESLIPNORF = value; }
        }

        /// public propaty name  :  MOVD_STOCKMOVEROWNORF
        /// <summary>�݌Ɉړ��s�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌Ɉړ��s�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MOVD_STOCKMOVEROWNORF
        {
            get { return _mOVD_STOCKMOVEROWNORF; }
            set { _mOVD_STOCKMOVEROWNORF = value; }
        }

        /// public propaty name  :  MOVD_BFSECTIONCODERF
        /// <summary>�ړ������_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ������_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MOVD_BFSECTIONCODERF
        {
            get { return _mOVD_BFSECTIONCODERF; }
            set { _mOVD_BFSECTIONCODERF = value; }
        }

        /// public propaty name  :  MOVD_BFENTERWAREHCODERF
        /// <summary>�ړ����q�ɃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ����q�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MOVD_BFENTERWAREHCODERF
        {
            get { return _mOVD_BFENTERWAREHCODERF; }
            set { _mOVD_BFENTERWAREHCODERF = value; }
        }

        /// public propaty name  :  MOVD_AFSECTIONCODERF
        /// <summary>�ړ��拒�_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ��拒�_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MOVD_AFSECTIONCODERF
        {
            get { return _mOVD_AFSECTIONCODERF; }
            set { _mOVD_AFSECTIONCODERF = value; }
        }

        /// public propaty name  :  MOVD_AFENTERWAREHCODERF
        /// <summary>�ړ���q�ɃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ���q�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MOVD_AFENTERWAREHCODERF
        {
            get { return _mOVD_AFENTERWAREHCODERF; }
            set { _mOVD_AFENTERWAREHCODERF = value; }
        }

        /// public propaty name  :  MOVD_SUPPLIERCDRF
        /// <summary>�d����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MOVD_SUPPLIERCDRF
        {
            get { return _mOVD_SUPPLIERCDRF; }
            set { _mOVD_SUPPLIERCDRF = value; }
        }

        /// public propaty name  :  MOVD_SUPPLIERSNMRF
        /// <summary>�d���旪�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MOVD_SUPPLIERSNMRF
        {
            get { return _mOVD_SUPPLIERSNMRF; }
            set { _mOVD_SUPPLIERSNMRF = value; }
        }

        /// public propaty name  :  MOVD_GOODSMAKERCDRF
        /// <summary>���i���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MOVD_GOODSMAKERCDRF
        {
            get { return _mOVD_GOODSMAKERCDRF; }
            set { _mOVD_GOODSMAKERCDRF = value; }
        }

        /// public propaty name  :  MOVD_MAKERNAMERF
        /// <summary>���[�J�[���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MOVD_MAKERNAMERF
        {
            get { return _mOVD_MAKERNAMERF; }
            set { _mOVD_MAKERNAMERF = value; }
        }

        /// public propaty name  :  MOVD_GOODSNORF
        /// <summary>���i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MOVD_GOODSNORF
        {
            get { return _mOVD_GOODSNORF; }
            set { _mOVD_GOODSNORF = value; }
        }

        /// public propaty name  :  MOVD_GOODSNAMERF
        /// <summary>���i���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MOVD_GOODSNAMERF
        {
            get { return _mOVD_GOODSNAMERF; }
            set { _mOVD_GOODSNAMERF = value; }
        }

        /// public propaty name  :  MOVD_GOODSNAMEKANARF
        /// <summary>���i���̃J�i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���̃J�i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MOVD_GOODSNAMEKANARF
        {
            get { return _mOVD_GOODSNAMEKANARF; }
            set { _mOVD_GOODSNAMEKANARF = value; }
        }

        /// public propaty name  :  MOVD_STOCKDIVRF
        /// <summary>�݌ɋ敪�v���p�e�B</summary>
        /// <value>0:���ЁA1:���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MOVD_STOCKDIVRF
        {
            get { return _mOVD_STOCKDIVRF; }
            set { _mOVD_STOCKDIVRF = value; }
        }

        /// public propaty name  :  MOVD_STOCKUNITPRICEFLRF
        /// <summary>�d���P���i�Ŕ�,�����j�v���p�e�B</summary>
        /// <value>�݌Ɉړ�����݌ɂ̎d�����i�����Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���P���i�Ŕ�,�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double MOVD_STOCKUNITPRICEFLRF
        {
            get { return _mOVD_STOCKUNITPRICEFLRF; }
            set { _mOVD_STOCKUNITPRICEFLRF = value; }
        }

        /// public propaty name  :  MOVD_TAXATIONDIVCDRF
        /// <summary>�ېŋ敪�v���p�e�B</summary>
        /// <value>0:�ې�,1:��ې�,2:�ېŁi���Łj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ېŋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MOVD_TAXATIONDIVCDRF
        {
            get { return _mOVD_TAXATIONDIVCDRF; }
            set { _mOVD_TAXATIONDIVCDRF = value; }
        }

        /// public propaty name  :  MOVD_MOVECOUNTRF
        /// <summary>�ړ����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double MOVD_MOVECOUNTRF
        {
            get { return _mOVD_MOVECOUNTRF; }
            set { _mOVD_MOVECOUNTRF = value; }
        }

        /// public propaty name  :  MOVD_BFSHELFNORF
        /// <summary>�ړ����I�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ����I�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MOVD_BFSHELFNORF
        {
            get { return _mOVD_BFSHELFNORF; }
            set { _mOVD_BFSHELFNORF = value; }
        }

        /// public propaty name  :  MOVD_AFSHELFNORF
        /// <summary>�ړ���I�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ���I�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MOVD_AFSHELFNORF
        {
            get { return _mOVD_AFSHELFNORF; }
            set { _mOVD_AFSHELFNORF = value; }
        }

        /// public propaty name  :  MOVD_BLGOODSCODERF
        /// <summary>BL���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MOVD_BLGOODSCODERF
        {
            get { return _mOVD_BLGOODSCODERF; }
            set { _mOVD_BLGOODSCODERF = value; }
        }

        /// public propaty name  :  MOVD_BLGOODSFULLNAMERF
        /// <summary>BL���i�R�[�h���́i�S�p�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h���́i�S�p�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MOVD_BLGOODSFULLNAMERF
        {
            get { return _mOVD_BLGOODSFULLNAMERF; }
            set { _mOVD_BLGOODSFULLNAMERF = value; }
        }

        /// public propaty name  :  MOVD_LISTPRICEFLRF
        /// <summary>�艿�i�����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �艿�i�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double MOVD_LISTPRICEFLRF
        {
            get { return _mOVD_LISTPRICEFLRF; }
            set { _mOVD_LISTPRICEFLRF = value; }
        }

        /// public propaty name  :  MOVD_MOVESTATUSRF
        /// <summary>�ړ���ԃv���p�e�B</summary>
        /// <value>0:�ړ��ΏۊO�A1:���o�׏�ԁA2:�ړ����A9:���׍�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ���ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MOVD_MOVESTATUSRF
        {
            get { return _mOVD_MOVESTATUSRF; }
            set { _mOVD_MOVESTATUSRF = value; }
        }

        /// public propaty name  :  BLGOODSCDURF_BLGOODSHALFNAMERF
        /// <summary>BL���i�R�[�h���́i���p�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h���́i���p�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BLGOODSCDURF_BLGOODSHALFNAMERF
        {
            get { return _bLGOODSCDURF_BLGOODSHALFNAMERF; }
            set { _bLGOODSCDURF_BLGOODSHALFNAMERF = value; }
        }

        /// public propaty name  :  MAKERURF_MAKERSHORTNAMERF
        /// <summary>���[�J�[���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MAKERURF_MAKERSHORTNAMERF
        {
            get { return _mAKERURF_MAKERSHORTNAMERF; }
            set { _mAKERURF_MAKERSHORTNAMERF = value; }
        }

        /// public propaty name  :  MAKERURF_MAKERKANANAMERF
        /// <summary>���[�J�[�J�i���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�J�i���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MAKERURF_MAKERKANANAMERF
        {
            get { return _mAKERURF_MAKERKANANAMERF; }
            set { _mAKERURF_MAKERKANANAMERF = value; }
        }

        /// public propaty name  :  STC1_DUPLICATIONSHELFNO1RF
        /// <summary>�d���I�ԂP�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���I�ԂP�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string STC1_DUPLICATIONSHELFNO1RF
        {
            get { return _sTC1_DUPLICATIONSHELFNO1RF; }
            set { _sTC1_DUPLICATIONSHELFNO1RF = value; }
        }

        /// public propaty name  :  STC1_DUPLICATIONSHELFNO2RF
        /// <summary>�d���I�ԂQ�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���I�ԂQ�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string STC1_DUPLICATIONSHELFNO2RF
        {
            get { return _sTC1_DUPLICATIONSHELFNO2RF; }
            set { _sTC1_DUPLICATIONSHELFNO2RF = value; }
        }

        /// public propaty name  :  STC1_PARTSMANAGEMENTDIVIDE1RF
        /// <summary>���i�Ǘ��敪�P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�Ǘ��敪�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string STC1_PARTSMANAGEMENTDIVIDE1RF
        {
            get { return _sTC1_PARTSMANAGEMENTDIVIDE1RF; }
            set { _sTC1_PARTSMANAGEMENTDIVIDE1RF = value; }
        }

        /// public propaty name  :  STC1_PARTSMANAGEMENTDIVIDE2RF
        /// <summary>���i�Ǘ��敪�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�Ǘ��敪�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string STC1_PARTSMANAGEMENTDIVIDE2RF
        {
            get { return _sTC1_PARTSMANAGEMENTDIVIDE2RF; }
            set { _sTC1_PARTSMANAGEMENTDIVIDE2RF = value; }
        }

        /// public propaty name  :  STC1_STOCKNOTE1RF
        /// <summary>�݌ɔ��l�P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɔ��l�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string STC1_STOCKNOTE1RF
        {
            get { return _sTC1_STOCKNOTE1RF; }
            set { _sTC1_STOCKNOTE1RF = value; }
        }

        /// public propaty name  :  STC1_STOCKNOTE2RF
        /// <summary>�݌ɔ��l�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɔ��l�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string STC1_STOCKNOTE2RF
        {
            get { return _sTC1_STOCKNOTE2RF; }
            set { _sTC1_STOCKNOTE2RF = value; }
        }

        /// public propaty name  :  STC1_SHIPMENTPOSCNTRF
        /// <summary>�o�׉\���v���p�e�B</summary>
        /// <value>�o�׉\�����d���݌ɐ��{����݌ɐ��|�i�d���݌ɕ��ϑ����{������ϑ����j�|�i�ړ����d���݌ɐ��{�ړ�������݌ɐ��j�|�󒍐�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�׉\���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double STC1_SHIPMENTPOSCNTRF
        {
            get { return _sTC1_SHIPMENTPOSCNTRF; }
            set { _sTC1_SHIPMENTPOSCNTRF = value; }
        }

        /// public propaty name  :  STC2_DUPLICATIONSHELFNO1RF
        /// <summary>�d���I�ԂP�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���I�ԂP�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string STC2_DUPLICATIONSHELFNO1RF
        {
            get { return _sTC2_DUPLICATIONSHELFNO1RF; }
            set { _sTC2_DUPLICATIONSHELFNO1RF = value; }
        }

        /// public propaty name  :  STC2_DUPLICATIONSHELFNO2RF
        /// <summary>�d���I�ԂQ�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���I�ԂQ�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string STC2_DUPLICATIONSHELFNO2RF
        {
            get { return _sTC2_DUPLICATIONSHELFNO2RF; }
            set { _sTC2_DUPLICATIONSHELFNO2RF = value; }
        }

        /// public propaty name  :  STC2_PARTSMANAGEMENTDIVIDE1RF
        /// <summary>���i�Ǘ��敪�P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�Ǘ��敪�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string STC2_PARTSMANAGEMENTDIVIDE1RF
        {
            get { return _sTC2_PARTSMANAGEMENTDIVIDE1RF; }
            set { _sTC2_PARTSMANAGEMENTDIVIDE1RF = value; }
        }

        /// public propaty name  :  STC2_PARTSMANAGEMENTDIVIDE2RF
        /// <summary>���i�Ǘ��敪�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�Ǘ��敪�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string STC2_PARTSMANAGEMENTDIVIDE2RF
        {
            get { return _sTC2_PARTSMANAGEMENTDIVIDE2RF; }
            set { _sTC2_PARTSMANAGEMENTDIVIDE2RF = value; }
        }

        /// public propaty name  :  STC2_STOCKNOTE1RF
        /// <summary>�݌ɔ��l�P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɔ��l�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string STC2_STOCKNOTE1RF
        {
            get { return _sTC2_STOCKNOTE1RF; }
            set { _sTC2_STOCKNOTE1RF = value; }
        }

        /// public propaty name  :  STC2_STOCKNOTE2RF
        /// <summary>�݌ɔ��l�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɔ��l�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string STC2_STOCKNOTE2RF
        {
            get { return _sTC2_STOCKNOTE2RF; }
            set { _sTC2_STOCKNOTE2RF = value; }
        }

        /// public propaty name  :  STC2_SHIPMENTPOSCNTRF
        /// <summary>�o�׉\���v���p�e�B</summary>
        /// <value>�o�׉\�����d���݌ɐ��{����݌ɐ��|�i�d���݌ɕ��ϑ����{������ϑ����j�|�i�ړ����d���݌ɐ��{�ړ�������݌ɐ��j�|�󒍐�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�׉\���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double STC2_SHIPMENTPOSCNTRF
        {
            get { return _sTC2_SHIPMENTPOSCNTRF; }
            set { _sTC2_SHIPMENTPOSCNTRF = value; }
        }

        /// public propaty name  :  SUP_SUPPLIERNM1RF
        /// <summary>�d���於1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���於1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SUP_SUPPLIERNM1RF
        {
            get { return _sUP_SUPPLIERNM1RF; }
            set { _sUP_SUPPLIERNM1RF = value; }
        }

        /// public propaty name  :  SUP_SUPPLIERNM2RF
        /// <summary>�d���於2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���於2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SUP_SUPPLIERNM2RF
        {
            get { return _sUP_SUPPLIERNM2RF; }
            set { _sUP_SUPPLIERNM2RF = value; }
        }

        /// public propaty name  :  SUP_SUPPHONORIFICTITLERF
        /// <summary>�d����h�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����h�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SUP_SUPPHONORIFICTITLERF
        {
            get { return _sUP_SUPPHONORIFICTITLERF; }
            set { _sUP_SUPPHONORIFICTITLERF = value; }
        }

        /// public propaty name  :  SUP_SUPPLIERKANARF
        /// <summary>�d����J�i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����J�i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SUP_SUPPLIERKANARF
        {
            get { return _sUP_SUPPLIERKANARF; }
            set { _sUP_SUPPLIERKANARF = value; }
        }

        /// public propaty name  :  SUP_PURECODERF
        /// <summary>�����敪�v���p�e�B</summary>
        /// <value>0:�����A1:�D��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SUP_PURECODERF
        {
            get { return _sUP_PURECODERF; }
            set { _sUP_PURECODERF = value; }
        }

        /// public propaty name  :  SUP_SUPPLIERNOTE1RF
        /// <summary>�d������l1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d������l1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SUP_SUPPLIERNOTE1RF
        {
            get { return _sUP_SUPPLIERNOTE1RF; }
            set { _sUP_SUPPLIERNOTE1RF = value; }
        }

        /// public propaty name  :  SUP_SUPPLIERNOTE2RF
        /// <summary>�d������l2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d������l2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SUP_SUPPLIERNOTE2RF
        {
            get { return _sUP_SUPPLIERNOTE2RF; }
            set { _sUP_SUPPLIERNOTE2RF = value; }
        }

        /// public propaty name  :  SUP_SUPPLIERNOTE3RF
        /// <summary>�d������l3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d������l3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SUP_SUPPLIERNOTE3RF
        {
            get { return _sUP_SUPPLIERNOTE3RF; }
            set { _sUP_SUPPLIERNOTE3RF = value; }
        }

        /// public propaty name  :  SUP_SUPPLIERNOTE4RF
        /// <summary>�d������l4�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d������l4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SUP_SUPPLIERNOTE4RF
        {
            get { return _sUP_SUPPLIERNOTE4RF; }
            set { _sUP_SUPPLIERNOTE4RF = value; }
        }

        /// public propaty name  :  GDS_GOODSNAMEKANARF
        /// <summary>���i���̃J�i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���̃J�i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GDS_GOODSNAMEKANARF
        {
            get { return _gDS_GOODSNAMEKANARF; }
            set { _gDS_GOODSNAMEKANARF = value; }
        }

        /// public propaty name  :  GDS_JANRF
        /// <summary>JAN�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   JAN�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GDS_JANRF
        {
            get { return _gDS_JANRF; }
            set { _gDS_JANRF = value; }
        }

        /// public propaty name  :  GDS_GOODSRATERANKRF
        /// <summary>���i�|�������N�v���p�e�B</summary>
        /// <value>�w��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�|�������N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GDS_GOODSRATERANKRF
        {
            get { return _gDS_GOODSRATERANKRF; }
            set { _gDS_GOODSRATERANKRF = value; }
        }

        /// public propaty name  :  GDS_GOODSNONONEHYPHENRF
        /// <summary>�n�C�t�������i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �n�C�t�������i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GDS_GOODSNONONEHYPHENRF
        {
            get { return _gDS_GOODSNONONEHYPHENRF; }
            set { _gDS_GOODSNONONEHYPHENRF = value; }
        }

        /// public propaty name  :  GDS_GOODSNOTE1RF
        /// <summary>���i���l�P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���l�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GDS_GOODSNOTE1RF
        {
            get { return _gDS_GOODSNOTE1RF; }
            set { _gDS_GOODSNOTE1RF = value; }
        }

        /// public propaty name  :  GDS_GOODSNOTE2RF
        /// <summary>���i���l�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���l�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GDS_GOODSNOTE2RF
        {
            get { return _gDS_GOODSNOTE2RF; }
            set { _gDS_GOODSNOTE2RF = value; }
        }

        /// public propaty name  :  GDS_GOODSSPECIALNOTERF
        /// <summary>���i�K�i�E���L�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�K�i�E���L�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GDS_GOODSSPECIALNOTERF
        {
            get { return _gDS_GOODSSPECIALNOTERF; }
            set { _gDS_GOODSSPECIALNOTERF = value; }
        }

        /// public propaty name  :  DADD_STOCKDIVNMRF
        /// <summary>�݌ɋ敪���̃v���p�e�B</summary>
        /// <value>0:���ЁA1:���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɋ敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_STOCKDIVNMRF
        {
            get { return _dADD_STOCKDIVNMRF; }
            set { _dADD_STOCKDIVNMRF = value; }
        }

        /// public propaty name  :  DADD_TAXATIONDIVCDNMRF
        /// <summary>�ېŋ敪���̃v���p�e�B</summary>
        /// <value>0:�ې�,1:��ې�,2:�ېŁi���Łj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ېŋ敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_TAXATIONDIVCDNMRF
        {
            get { return _dADD_TAXATIONDIVCDNMRF; }
            set { _dADD_TAXATIONDIVCDNMRF = value; }
        }

        /// public propaty name  :  DADD_PURECODENMRF
        /// <summary>�����敪���̃v���p�e�B</summary>
        /// <value>0:�����A1:�D��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_PURECODENMRF
        {
            get { return _dADD_PURECODENMRF; }
            set { _dADD_PURECODENMRF = value; }
        }

        /// public propaty name  :  DADD_STOCKMOVEPRICERF
        /// <summary>�ړ����z�v���p�e�B</summary>
        /// <value>�y�d���P���~�ړ����z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DADD_STOCKMOVEPRICERF
        {
            get { return _dADD_STOCKMOVEPRICERF; }
            set { _dADD_STOCKMOVEPRICERF = value; }
        }

        /// public propaty name  :  DADD_STOCKMOVELISTPRICERF
        /// <summary>�ړ����z(�W�����i)�v���p�e�B</summary>
        /// <value>�y�艿�~�ړ����z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ����z(�W�����i)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DADD_STOCKMOVELISTPRICERF
        {
            get { return _dADD_STOCKMOVELISTPRICERF; }
            set { _dADD_STOCKMOVELISTPRICERF = value; }
        }

        /// public propaty name  :  DADD_BFSTOCKCOUNTPREVRF
        /// <summary>�ړ����ړ��O���v���p�e�B</summary>
        /// <value>�ړ����q�ɂ̌��݌ɐ��i�ړ��O�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ����ړ��O���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double DADD_BFSTOCKCOUNTPREVRF
        {
            get { return _dADD_BFSTOCKCOUNTPREVRF; }
            set { _dADD_BFSTOCKCOUNTPREVRF = value; }
        }

        /// public propaty name  :  DADD_BFSTOCKCOUNTRF
        /// <summary>�ړ����ړ��㐔�v���p�e�B</summary>
        /// <value>�ړ����q�ɂ̌��݌ɐ��i�ړ���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ����ړ��㐔�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double DADD_BFSTOCKCOUNTRF
        {
            get { return _dADD_BFSTOCKCOUNTRF; }
            set { _dADD_BFSTOCKCOUNTRF = value; }
        }

        /// public propaty name  :  DADD_AFSTOCKCOUNTPREVRF
        /// <summary>�ړ���ړ��O���v���p�e�B</summary>
        /// <value>�ړ���q�ɂ̌��݌ɐ��i�ړ��O�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ���ړ��O���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double DADD_AFSTOCKCOUNTPREVRF
        {
            get { return _dADD_AFSTOCKCOUNTPREVRF; }
            set { _dADD_AFSTOCKCOUNTPREVRF = value; }
        }

        /// public propaty name  :  DADD_AFSTOCKCOUNTRF
        /// <summary>�ړ���ړ��㐔�v���p�e�B</summary>
        /// <value>�ړ���q�ɂ̌��݌ɐ��i�ړ���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ���ړ��㐔�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double DADD_AFSTOCKCOUNTRF
        {
            get { return _dADD_AFSTOCKCOUNTRF; }
            set { _dADD_AFSTOCKCOUNTRF = value; }
        }

        /// public propaty name  :  MOVD_STOCKMOVEPRICERF
        /// <summary>�ړ����z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MOVD_STOCKMOVEPRICERF
        {
            get { return _mOVD_STOCKMOVEPRICERF; }
            set { _mOVD_STOCKMOVEPRICERF = value; }
        }


        /// <summary>
        /// ���R���[�݌Ɉړ����׃f�[�^���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>FrePStockMoveDetailWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   FrePStockMoveDetailWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public FrePStockMoveDetailWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>FrePStockMoveDetailWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   FrePStockMoveDetailWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class FrePStockMoveDetailWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   FrePStockMoveDetailWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize( System.IO.BinaryWriter writer, object graph )
        {
            // TODO:  FrePStockMoveDetailWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if ( writer == null )
                throw new ArgumentNullException();

            if ( graph != null && !(graph is FrePStockMoveDetailWork || graph is ArrayList || graph is FrePStockMoveDetailWork[]) )
                throw new ArgumentException( string.Format( "graph��{0}�̃C���X�^���X�ł���܂���", typeof( FrePStockMoveDetailWork ).FullName ) );

            if ( graph != null && graph is FrePStockMoveDetailWork )
            {
                Type t = graph.GetType();
                if ( !CustomFormatterServices.NeedCustomSerialization( t ) )
                    throw new ArgumentException( string.Format( "graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName ) );
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.FrePStockMoveDetailWork" );

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if ( graph is ArrayList )
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if ( graph is FrePStockMoveDetailWork[] )
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((FrePStockMoveDetailWork[])graph).Length;
            }
            else if ( graph is FrePStockMoveDetailWork )
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�݌Ɉړ��`��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //MOVD_STOCKMOVEFORMALRF
            //�݌Ɉړ��`�[�ԍ�
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //MOVD_STOCKMOVESLIPNORF
            //�݌Ɉړ��s�ԍ�
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //MOVD_STOCKMOVEROWNORF
            //�ړ������_�R�[�h
            serInfo.MemberInfo.Add( typeof( string ) ); //MOVD_BFSECTIONCODERF
            //�ړ����q�ɃR�[�h
            serInfo.MemberInfo.Add( typeof( string ) ); //MOVD_BFENTERWAREHCODERF
            //�ړ��拒�_�R�[�h
            serInfo.MemberInfo.Add( typeof( string ) ); //MOVD_AFSECTIONCODERF
            //�ړ���q�ɃR�[�h
            serInfo.MemberInfo.Add( typeof( string ) ); //MOVD_AFENTERWAREHCODERF
            //�d����R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //MOVD_SUPPLIERCDRF
            //�d���旪��
            serInfo.MemberInfo.Add( typeof( string ) ); //MOVD_SUPPLIERSNMRF
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //MOVD_GOODSMAKERCDRF
            //���[�J�[����
            serInfo.MemberInfo.Add( typeof( string ) ); //MOVD_MAKERNAMERF
            //���i�ԍ�
            serInfo.MemberInfo.Add( typeof( string ) ); //MOVD_GOODSNORF
            //���i����
            serInfo.MemberInfo.Add( typeof( string ) ); //MOVD_GOODSNAMERF
            //���i���̃J�i
            serInfo.MemberInfo.Add( typeof( string ) ); //MOVD_GOODSNAMEKANARF
            //�݌ɋ敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //MOVD_STOCKDIVRF
            //�d���P���i�Ŕ�,�����j
            serInfo.MemberInfo.Add( typeof( Double ) ); //MOVD_STOCKUNITPRICEFLRF
            //�ېŋ敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //MOVD_TAXATIONDIVCDRF
            //�ړ���
            serInfo.MemberInfo.Add( typeof( Double ) ); //MOVD_MOVECOUNTRF
            //�ړ����I��
            serInfo.MemberInfo.Add( typeof( string ) ); //MOVD_BFSHELFNORF
            //�ړ���I��
            serInfo.MemberInfo.Add( typeof( string ) ); //MOVD_AFSHELFNORF
            //BL���i�R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //MOVD_BLGOODSCODERF
            //BL���i�R�[�h���́i�S�p�j
            serInfo.MemberInfo.Add( typeof( string ) ); //MOVD_BLGOODSFULLNAMERF
            //�艿�i�����j
            serInfo.MemberInfo.Add( typeof( Double ) ); //MOVD_LISTPRICEFLRF
            //�ړ����
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //MOVD_MOVESTATUSRF
            //BL���i�R�[�h���́i���p�j
            serInfo.MemberInfo.Add( typeof( string ) ); //BLGOODSCDURF_BLGOODSHALFNAMERF
            //���[�J�[����
            serInfo.MemberInfo.Add( typeof( string ) ); //MAKERURF_MAKERSHORTNAMERF
            //���[�J�[�J�i����
            serInfo.MemberInfo.Add( typeof( string ) ); //MAKERURF_MAKERKANANAMERF
            //�d���I�ԂP
            serInfo.MemberInfo.Add( typeof( string ) ); //STC1_DUPLICATIONSHELFNO1RF
            //�d���I�ԂQ
            serInfo.MemberInfo.Add( typeof( string ) ); //STC1_DUPLICATIONSHELFNO2RF
            //���i�Ǘ��敪�P
            serInfo.MemberInfo.Add( typeof( string ) ); //STC1_PARTSMANAGEMENTDIVIDE1RF
            //���i�Ǘ��敪�Q
            serInfo.MemberInfo.Add( typeof( string ) ); //STC1_PARTSMANAGEMENTDIVIDE2RF
            //�݌ɔ��l�P
            serInfo.MemberInfo.Add( typeof( string ) ); //STC1_STOCKNOTE1RF
            //�݌ɔ��l�Q
            serInfo.MemberInfo.Add( typeof( string ) ); //STC1_STOCKNOTE2RF
            //�o�׉\��
            serInfo.MemberInfo.Add( typeof( Double ) ); //STC1_SHIPMENTPOSCNTRF
            //�d���I�ԂP
            serInfo.MemberInfo.Add( typeof( string ) ); //STC2_DUPLICATIONSHELFNO1RF
            //�d���I�ԂQ
            serInfo.MemberInfo.Add( typeof( string ) ); //STC2_DUPLICATIONSHELFNO2RF
            //���i�Ǘ��敪�P
            serInfo.MemberInfo.Add( typeof( string ) ); //STC2_PARTSMANAGEMENTDIVIDE1RF
            //���i�Ǘ��敪�Q
            serInfo.MemberInfo.Add( typeof( string ) ); //STC2_PARTSMANAGEMENTDIVIDE2RF
            //�݌ɔ��l�P
            serInfo.MemberInfo.Add( typeof( string ) ); //STC2_STOCKNOTE1RF
            //�݌ɔ��l�Q
            serInfo.MemberInfo.Add( typeof( string ) ); //STC2_STOCKNOTE2RF
            //�o�׉\��
            serInfo.MemberInfo.Add( typeof( Double ) ); //STC2_SHIPMENTPOSCNTRF
            //�d���於1
            serInfo.MemberInfo.Add( typeof( string ) ); //SUP_SUPPLIERNM1RF
            //�d���於2
            serInfo.MemberInfo.Add( typeof( string ) ); //SUP_SUPPLIERNM2RF
            //�d����h��
            serInfo.MemberInfo.Add( typeof( string ) ); //SUP_SUPPHONORIFICTITLERF
            //�d����J�i
            serInfo.MemberInfo.Add( typeof( string ) ); //SUP_SUPPLIERKANARF
            //�����敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SUP_PURECODERF
            //�d������l1
            serInfo.MemberInfo.Add( typeof( string ) ); //SUP_SUPPLIERNOTE1RF
            //�d������l2
            serInfo.MemberInfo.Add( typeof( string ) ); //SUP_SUPPLIERNOTE2RF
            //�d������l3
            serInfo.MemberInfo.Add( typeof( string ) ); //SUP_SUPPLIERNOTE3RF
            //�d������l4
            serInfo.MemberInfo.Add( typeof( string ) ); //SUP_SUPPLIERNOTE4RF
            //���i���̃J�i
            serInfo.MemberInfo.Add( typeof( string ) ); //GDS_GOODSNAMEKANARF
            //JAN�R�[�h
            serInfo.MemberInfo.Add( typeof( string ) ); //GDS_JANRF
            //���i�|�������N
            serInfo.MemberInfo.Add( typeof( string ) ); //GDS_GOODSRATERANKRF
            //�n�C�t�������i�ԍ�
            serInfo.MemberInfo.Add( typeof( string ) ); //GDS_GOODSNONONEHYPHENRF
            //���i���l�P
            serInfo.MemberInfo.Add( typeof( string ) ); //GDS_GOODSNOTE1RF
            //���i���l�Q
            serInfo.MemberInfo.Add( typeof( string ) ); //GDS_GOODSNOTE2RF
            //���i�K�i�E���L����
            serInfo.MemberInfo.Add( typeof( string ) ); //GDS_GOODSSPECIALNOTERF
            //�݌ɋ敪����
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_STOCKDIVNMRF
            //�ېŋ敪����
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_TAXATIONDIVCDNMRF
            //�����敪����
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_PURECODENMRF
            //�ړ����z
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //DADD_STOCKMOVEPRICERF
            //�ړ����z(�W�����i)
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //DADD_STOCKMOVELISTPRICERF
            //�ړ����ړ��O��
            serInfo.MemberInfo.Add( typeof( Double ) ); //DADD_BFSTOCKCOUNTPREVRF
            //�ړ����ړ��㐔
            serInfo.MemberInfo.Add( typeof( Double ) ); //DADD_BFSTOCKCOUNTRF
            //�ړ���ړ��O��
            serInfo.MemberInfo.Add( typeof( Double ) ); //DADD_AFSTOCKCOUNTPREVRF
            //�ړ���ړ��㐔
            serInfo.MemberInfo.Add( typeof( Double ) ); //DADD_AFSTOCKCOUNTRF
            //�ړ����z
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //MOVD_STOCKMOVEPRICERF


            serInfo.Serialize( writer, serInfo );
            if ( graph is FrePStockMoveDetailWork )
            {
                FrePStockMoveDetailWork temp = (FrePStockMoveDetailWork)graph;

                SetFrePStockMoveDetailWork( writer, temp );
            }
            else
            {
                ArrayList lst = null;
                if ( graph is FrePStockMoveDetailWork[] )
                {
                    lst = new ArrayList();
                    lst.AddRange( (FrePStockMoveDetailWork[])graph );
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach ( FrePStockMoveDetailWork temp in lst )
                {
                    SetFrePStockMoveDetailWork( writer, temp );
                }

            }


        }


        /// <summary>
        /// FrePStockMoveDetailWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 67;

        /// <summary>
        ///  FrePStockMoveDetailWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   FrePStockMoveDetailWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetFrePStockMoveDetailWork( System.IO.BinaryWriter writer, FrePStockMoveDetailWork temp )
        {
            //�݌Ɉړ��`��
            writer.Write( temp.MOVD_STOCKMOVEFORMALRF );
            //�݌Ɉړ��`�[�ԍ�
            writer.Write( temp.MOVD_STOCKMOVESLIPNORF );
            //�݌Ɉړ��s�ԍ�
            writer.Write( temp.MOVD_STOCKMOVEROWNORF );
            //�ړ������_�R�[�h
            writer.Write( temp.MOVD_BFSECTIONCODERF );
            //�ړ����q�ɃR�[�h
            writer.Write( temp.MOVD_BFENTERWAREHCODERF );
            //�ړ��拒�_�R�[�h
            writer.Write( temp.MOVD_AFSECTIONCODERF );
            //�ړ���q�ɃR�[�h
            writer.Write( temp.MOVD_AFENTERWAREHCODERF );
            //�d����R�[�h
            writer.Write( temp.MOVD_SUPPLIERCDRF );
            //�d���旪��
            writer.Write( temp.MOVD_SUPPLIERSNMRF );
            //���i���[�J�[�R�[�h
            writer.Write( temp.MOVD_GOODSMAKERCDRF );
            //���[�J�[����
            writer.Write( temp.MOVD_MAKERNAMERF );
            //���i�ԍ�
            writer.Write( temp.MOVD_GOODSNORF );
            //���i����
            writer.Write( temp.MOVD_GOODSNAMERF );
            //���i���̃J�i
            writer.Write( temp.MOVD_GOODSNAMEKANARF );
            //�݌ɋ敪
            writer.Write( temp.MOVD_STOCKDIVRF );
            //�d���P���i�Ŕ�,�����j
            writer.Write( temp.MOVD_STOCKUNITPRICEFLRF );
            //�ېŋ敪
            writer.Write( temp.MOVD_TAXATIONDIVCDRF );
            //�ړ���
            writer.Write( temp.MOVD_MOVECOUNTRF );
            //�ړ����I��
            writer.Write( temp.MOVD_BFSHELFNORF );
            //�ړ���I��
            writer.Write( temp.MOVD_AFSHELFNORF );
            //BL���i�R�[�h
            writer.Write( temp.MOVD_BLGOODSCODERF );
            //BL���i�R�[�h���́i�S�p�j
            writer.Write( temp.MOVD_BLGOODSFULLNAMERF );
            //�艿�i�����j
            writer.Write( temp.MOVD_LISTPRICEFLRF );
            //�ړ����
            writer.Write( temp.MOVD_MOVESTATUSRF );
            //BL���i�R�[�h���́i���p�j
            writer.Write( temp.BLGOODSCDURF_BLGOODSHALFNAMERF );
            //���[�J�[����
            writer.Write( temp.MAKERURF_MAKERSHORTNAMERF );
            //���[�J�[�J�i����
            writer.Write( temp.MAKERURF_MAKERKANANAMERF );
            //�d���I�ԂP
            writer.Write( temp.STC1_DUPLICATIONSHELFNO1RF );
            //�d���I�ԂQ
            writer.Write( temp.STC1_DUPLICATIONSHELFNO2RF );
            //���i�Ǘ��敪�P
            writer.Write( temp.STC1_PARTSMANAGEMENTDIVIDE1RF );
            //���i�Ǘ��敪�Q
            writer.Write( temp.STC1_PARTSMANAGEMENTDIVIDE2RF );
            //�݌ɔ��l�P
            writer.Write( temp.STC1_STOCKNOTE1RF );
            //�݌ɔ��l�Q
            writer.Write( temp.STC1_STOCKNOTE2RF );
            //�o�׉\��
            writer.Write( temp.STC1_SHIPMENTPOSCNTRF );
            //�d���I�ԂP
            writer.Write( temp.STC2_DUPLICATIONSHELFNO1RF );
            //�d���I�ԂQ
            writer.Write( temp.STC2_DUPLICATIONSHELFNO2RF );
            //���i�Ǘ��敪�P
            writer.Write( temp.STC2_PARTSMANAGEMENTDIVIDE1RF );
            //���i�Ǘ��敪�Q
            writer.Write( temp.STC2_PARTSMANAGEMENTDIVIDE2RF );
            //�݌ɔ��l�P
            writer.Write( temp.STC2_STOCKNOTE1RF );
            //�݌ɔ��l�Q
            writer.Write( temp.STC2_STOCKNOTE2RF );
            //�o�׉\��
            writer.Write( temp.STC2_SHIPMENTPOSCNTRF );
            //�d���於1
            writer.Write( temp.SUP_SUPPLIERNM1RF );
            //�d���於2
            writer.Write( temp.SUP_SUPPLIERNM2RF );
            //�d����h��
            writer.Write( temp.SUP_SUPPHONORIFICTITLERF );
            //�d����J�i
            writer.Write( temp.SUP_SUPPLIERKANARF );
            //�����敪
            writer.Write( temp.SUP_PURECODERF );
            //�d������l1
            writer.Write( temp.SUP_SUPPLIERNOTE1RF );
            //�d������l2
            writer.Write( temp.SUP_SUPPLIERNOTE2RF );
            //�d������l3
            writer.Write( temp.SUP_SUPPLIERNOTE3RF );
            //�d������l4
            writer.Write( temp.SUP_SUPPLIERNOTE4RF );
            //���i���̃J�i
            writer.Write( temp.GDS_GOODSNAMEKANARF );
            //JAN�R�[�h
            writer.Write( temp.GDS_JANRF );
            //���i�|�������N
            writer.Write( temp.GDS_GOODSRATERANKRF );
            //�n�C�t�������i�ԍ�
            writer.Write( temp.GDS_GOODSNONONEHYPHENRF );
            //���i���l�P
            writer.Write( temp.GDS_GOODSNOTE1RF );
            //���i���l�Q
            writer.Write( temp.GDS_GOODSNOTE2RF );
            //���i�K�i�E���L����
            writer.Write( temp.GDS_GOODSSPECIALNOTERF );
            //�݌ɋ敪����
            writer.Write( temp.DADD_STOCKDIVNMRF );
            //�ېŋ敪����
            writer.Write( temp.DADD_TAXATIONDIVCDNMRF );
            //�����敪����
            writer.Write( temp.DADD_PURECODENMRF );
            //�ړ����z
            writer.Write( temp.DADD_STOCKMOVEPRICERF );
            //�ړ����z(�W�����i)
            writer.Write( temp.DADD_STOCKMOVELISTPRICERF );
            //�ړ����ړ��O��
            writer.Write( temp.DADD_BFSTOCKCOUNTPREVRF );
            //�ړ����ړ��㐔
            writer.Write( temp.DADD_BFSTOCKCOUNTRF );
            //�ړ���ړ��O��
            writer.Write( temp.DADD_AFSTOCKCOUNTPREVRF );
            //�ړ���ړ��㐔
            writer.Write( temp.DADD_AFSTOCKCOUNTRF );
            //�ړ����z
            writer.Write( temp.MOVD_STOCKMOVEPRICERF );

        }

        /// <summary>
        ///  FrePStockMoveDetailWork�C���X�^���X�擾
        /// </summary>
        /// <returns>FrePStockMoveDetailWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   FrePStockMoveDetailWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private FrePStockMoveDetailWork GetFrePStockMoveDetailWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            FrePStockMoveDetailWork temp = new FrePStockMoveDetailWork();

            //�݌Ɉړ��`��
            temp.MOVD_STOCKMOVEFORMALRF = reader.ReadInt32();
            //�݌Ɉړ��`�[�ԍ�
            temp.MOVD_STOCKMOVESLIPNORF = reader.ReadInt32();
            //�݌Ɉړ��s�ԍ�
            temp.MOVD_STOCKMOVEROWNORF = reader.ReadInt32();
            //�ړ������_�R�[�h
            temp.MOVD_BFSECTIONCODERF = reader.ReadString();
            //�ړ����q�ɃR�[�h
            temp.MOVD_BFENTERWAREHCODERF = reader.ReadString();
            //�ړ��拒�_�R�[�h
            temp.MOVD_AFSECTIONCODERF = reader.ReadString();
            //�ړ���q�ɃR�[�h
            temp.MOVD_AFENTERWAREHCODERF = reader.ReadString();
            //�d����R�[�h
            temp.MOVD_SUPPLIERCDRF = reader.ReadInt32();
            //�d���旪��
            temp.MOVD_SUPPLIERSNMRF = reader.ReadString();
            //���i���[�J�[�R�[�h
            temp.MOVD_GOODSMAKERCDRF = reader.ReadInt32();
            //���[�J�[����
            temp.MOVD_MAKERNAMERF = reader.ReadString();
            //���i�ԍ�
            temp.MOVD_GOODSNORF = reader.ReadString();
            //���i����
            temp.MOVD_GOODSNAMERF = reader.ReadString();
            //���i���̃J�i
            temp.MOVD_GOODSNAMEKANARF = reader.ReadString();
            //�݌ɋ敪
            temp.MOVD_STOCKDIVRF = reader.ReadInt32();
            //�d���P���i�Ŕ�,�����j
            temp.MOVD_STOCKUNITPRICEFLRF = reader.ReadDouble();
            //�ېŋ敪
            temp.MOVD_TAXATIONDIVCDRF = reader.ReadInt32();
            //�ړ���
            temp.MOVD_MOVECOUNTRF = reader.ReadDouble();
            //�ړ����I��
            temp.MOVD_BFSHELFNORF = reader.ReadString();
            //�ړ���I��
            temp.MOVD_AFSHELFNORF = reader.ReadString();
            //BL���i�R�[�h
            temp.MOVD_BLGOODSCODERF = reader.ReadInt32();
            //BL���i�R�[�h���́i�S�p�j
            temp.MOVD_BLGOODSFULLNAMERF = reader.ReadString();
            //�艿�i�����j
            temp.MOVD_LISTPRICEFLRF = reader.ReadDouble();
            //�ړ����
            temp.MOVD_MOVESTATUSRF = reader.ReadInt32();
            //BL���i�R�[�h���́i���p�j
            temp.BLGOODSCDURF_BLGOODSHALFNAMERF = reader.ReadString();
            //���[�J�[����
            temp.MAKERURF_MAKERSHORTNAMERF = reader.ReadString();
            //���[�J�[�J�i����
            temp.MAKERURF_MAKERKANANAMERF = reader.ReadString();
            //�d���I�ԂP
            temp.STC1_DUPLICATIONSHELFNO1RF = reader.ReadString();
            //�d���I�ԂQ
            temp.STC1_DUPLICATIONSHELFNO2RF = reader.ReadString();
            //���i�Ǘ��敪�P
            temp.STC1_PARTSMANAGEMENTDIVIDE1RF = reader.ReadString();
            //���i�Ǘ��敪�Q
            temp.STC1_PARTSMANAGEMENTDIVIDE2RF = reader.ReadString();
            //�݌ɔ��l�P
            temp.STC1_STOCKNOTE1RF = reader.ReadString();
            //�݌ɔ��l�Q
            temp.STC1_STOCKNOTE2RF = reader.ReadString();
            //�o�׉\��
            temp.STC1_SHIPMENTPOSCNTRF = reader.ReadDouble();
            //�d���I�ԂP
            temp.STC2_DUPLICATIONSHELFNO1RF = reader.ReadString();
            //�d���I�ԂQ
            temp.STC2_DUPLICATIONSHELFNO2RF = reader.ReadString();
            //���i�Ǘ��敪�P
            temp.STC2_PARTSMANAGEMENTDIVIDE1RF = reader.ReadString();
            //���i�Ǘ��敪�Q
            temp.STC2_PARTSMANAGEMENTDIVIDE2RF = reader.ReadString();
            //�݌ɔ��l�P
            temp.STC2_STOCKNOTE1RF = reader.ReadString();
            //�݌ɔ��l�Q
            temp.STC2_STOCKNOTE2RF = reader.ReadString();
            //�o�׉\��
            temp.STC2_SHIPMENTPOSCNTRF = reader.ReadDouble();
            //�d���於1
            temp.SUP_SUPPLIERNM1RF = reader.ReadString();
            //�d���於2
            temp.SUP_SUPPLIERNM2RF = reader.ReadString();
            //�d����h��
            temp.SUP_SUPPHONORIFICTITLERF = reader.ReadString();
            //�d����J�i
            temp.SUP_SUPPLIERKANARF = reader.ReadString();
            //�����敪
            temp.SUP_PURECODERF = reader.ReadInt32();
            //�d������l1
            temp.SUP_SUPPLIERNOTE1RF = reader.ReadString();
            //�d������l2
            temp.SUP_SUPPLIERNOTE2RF = reader.ReadString();
            //�d������l3
            temp.SUP_SUPPLIERNOTE3RF = reader.ReadString();
            //�d������l4
            temp.SUP_SUPPLIERNOTE4RF = reader.ReadString();
            //���i���̃J�i
            temp.GDS_GOODSNAMEKANARF = reader.ReadString();
            //JAN�R�[�h
            temp.GDS_JANRF = reader.ReadString();
            //���i�|�������N
            temp.GDS_GOODSRATERANKRF = reader.ReadString();
            //�n�C�t�������i�ԍ�
            temp.GDS_GOODSNONONEHYPHENRF = reader.ReadString();
            //���i���l�P
            temp.GDS_GOODSNOTE1RF = reader.ReadString();
            //���i���l�Q
            temp.GDS_GOODSNOTE2RF = reader.ReadString();
            //���i�K�i�E���L����
            temp.GDS_GOODSSPECIALNOTERF = reader.ReadString();
            //�݌ɋ敪����
            temp.DADD_STOCKDIVNMRF = reader.ReadString();
            //�ېŋ敪����
            temp.DADD_TAXATIONDIVCDNMRF = reader.ReadString();
            //�����敪����
            temp.DADD_PURECODENMRF = reader.ReadString();
            //�ړ����z
            temp.DADD_STOCKMOVEPRICERF = reader.ReadInt64();
            //�ړ����z(�W�����i)
            temp.DADD_STOCKMOVELISTPRICERF = reader.ReadInt64();
            //�ړ����ړ��O��
            temp.DADD_BFSTOCKCOUNTPREVRF = reader.ReadDouble();
            //�ړ����ړ��㐔
            temp.DADD_BFSTOCKCOUNTRF = reader.ReadDouble();
            //�ړ���ړ��O��
            temp.DADD_AFSTOCKCOUNTPREVRF = reader.ReadDouble();
            //�ړ���ړ��㐔
            temp.DADD_AFSTOCKCOUNTRF = reader.ReadDouble();
            //�ړ����z
            temp.MOVD_STOCKMOVEPRICERF = reader.ReadInt64();


            //�ȉ��͓ǂݔ�΂��ł��B���̃o�[�W�������z�肷�� EmployeeWork�^�ȍ~�̃o�[�W������
            //�f�[�^���f�V���A���C�Y����ꍇ�A�V���A���C�Y�����t�H�[�}�b�^���L�q����
            //�^���ɂ��������āA�X�g���[���������ǂݏo���܂�...�Ƃ����Ă�
            //�ǂݏo���Ď̂Ă邱�ƂɂȂ�܂��B
            for ( int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k )
            {
                //byte[],char[]���f�V���A���C�Y���钼�O�ɁA����length��
                //�f�V���A���C�Y����Ă���P�[�X������Abyte[],char[]��
                //�f�V���A���C�Y�ɂ�length���K�v�Ȃ̂�int�^�̃f�[�^���f
                //�V���A���C�Y�����ꍇ�́A���̒l�����̕ϐ��ɑޔ����܂��B
                int optCount = 0;
                object oMemberType = serInfo.MemberInfo[k];
                if ( oMemberType is Type )
                {
                    Type t = (Type)oMemberType;
                    object oData = TypeDeserializer.DeserializePrimitiveType( reader, t, optCount );
                    if ( t.Equals( typeof( int ) ) )
                    {
                        optCount = Convert.ToInt32( oData );
                    }
                    else
                    {
                        optCount = 0;
                    }
                }
                else if ( oMemberType is string )
                {
                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate( (string)oMemberType );
                    object userData = formatter.Deserialize( reader );  //�ǂݔ�΂�
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���f�V���A���C�U�ł�
        /// </summary>
        /// <returns>FrePStockMoveDetailWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   FrePStockMoveDetailWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize( System.IO.BinaryReader reader )
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
            ArrayList lst = new ArrayList();
            for ( int cnt = 0; cnt < serInfo.Occurrence; ++cnt )
            {
                FrePStockMoveDetailWork temp = GetFrePStockMoveDetailWork( reader, serInfo );
                lst.Add( temp );
            }
            switch ( serInfo.RetTypeInfo )
            {
                case 0:
                    retValue = lst;
                    break;
                case 1:
                    retValue = lst[0];
                    break;
                case 2:
                    retValue = (FrePStockMoveDetailWork[])lst.ToArray( typeof( FrePStockMoveDetailWork ) );
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
