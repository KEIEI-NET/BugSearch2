using System.Collections;
using System.Data;
using System.Threading;

using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using System.Collections.Generic;

namespace Broadleaf.Application.Common
{
	
	/// <summary>
	/// �Z���K�C�h�p�n��O���[�v�A�N�Z�X�N���X
	/// �L���b�V�����Ǘ�����
	/// </summary>
	/// <remarks>
	/// <br>Note       : </br>
	/// <br>Programmer : 23011�@����@���N</br>
	/// <br>Date       : 2006.01.06</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class AddressInfoAreaGroupCacheAcs
	{
		/// <summary>
		/// �n��O���[�v�A�N�Z�X�N���X(SFTOK09002A)
		/// </summary>
		private static AreaGroupAcs areaGroupAcs = null;
		
		/// <summary>
		/// �ǋ���L���b�V�����Ă������߂�ArrayList
        /// �������`�F�b�N�p�̃��b�N�I�u�W�F�N�g�Ƃ��Ă��g�p����
		/// </summary>
		private static DataTable areaGroupTable = null;

        /// <summary>
        /// �Ǐ������b�N�N���X
        /// </summary>
        private static ReaderWriterLock _readerWriterLock = null;

        /// <summary>
        /// �������t���O
        /// </summary>
        private static bool _initialized = false;

		/// <summary>
		/// �X�^�e�B�b�N�R���X�g���N�^
		/// </summary>
		static AddressInfoAreaGroupCacheAcs()
		{
            _readerWriterLock = new ReaderWriterLock();

			areaGroupAcs = new AreaGroupAcs();
			
			//�L���b�V���p�e�[�u��
			areaGroupTable = new DataTable();
			areaGroupTable.Columns.Add( "AreaGroupCode", typeof( int ) );
			areaGroupTable.Columns.Add( "AreaCode", typeof( int ) );
			areaGroupTable.Columns.Add( "AreaKind", typeof( int ) );
			areaGroupTable.Columns.Add( "AreaGroup", typeof( AreaGroup ) );
		}

		/// <summary>
		/// �������ɒn��O���[�v�f�[�^�����[�h����
		/// �X���b�h�Z�[�t
		/// </summary>
		private static void LoadAreaGroup()
		{
            ArrayList alTmp = null;

            //----------------------- �����݃��b�N�J�n ------------------------
            //�����݃��b�N�擾
            _readerWriterLock.AcquireWriterLock(Timeout.Infinite);
			
			try
			{
                //���łɃ��[�h�ς݂Ȃ烍�[�h���Ȃ��B
                if (_initialized)
                {
                    return;
                }

                //�I�����C���Ȃ烊���[�g����擾�����݂�
				if( LoginInfoAcquisition.OnlineFlag )
				{
					int status;

					try
					{
                        //throw new System.Exception("�ǋ�̃f�[�^�Ƃ�ɂ������Ƃ���");
						status = areaGroupAcs.SearchAll( out alTmp, LoginInfoAcquisition.EnterpriseCode );
						
						//�f�[�^���擾�ł�����I�t���C�����̂��߂ɃL���b�V�����Ƃ�
						if( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
						{
							AddressInfoCacheAcs.SerializeAreaGroup( alTmp );
						}
					}
					catch( System.Net.WebException)
					{
					}

				}
			    
				//�f�[�^�������Ȃ�L���b�V������ǂݍ���
				if( alTmp == null || alTmp.Count <= 0 )
				{
					//�f�B�X�N�L���b�V�������[�h����
					alTmp = AddressInfoCacheAcs.DeSerializeAreaGroup();
				}

                //�X�^�e�B�b�N�������ɓW�J����
                SetAreaGroupStaticMemoryInner(alTmp);
            }
            finally
            {
                //�Ǐ������b�N���J������
                _readerWriterLock.ReleaseWriterLock();
            }
            //----------------------- �����݃��b�N�I�� ------------------------
        }
        /// <summary>
        /// AreaGroup�Z�b�g
        /// </summary>
        /// <param name="areaGroupList"></param>
        public static void SetAreaGroupStaticMemory(ArrayList areaGroupList)
        {
            //----------------------- �����݃��b�N�J�n ------------------------
            //�����݃��b�N�擾
            _readerWriterLock.AcquireWriterLock(Timeout.Infinite);

            try
            {
                SetAreaGroupStaticMemoryInner(areaGroupList);
            }
            finally
            {
                //�����݃��b�N����������
                _readerWriterLock.ReleaseWriterLock();
            }
            //----------------------- �����݃��b�N�I�� ------------------------
        }

        /// <summary>
        /// AreaGroup�̃f�[�^���X�^�e�B�b�N�������ɐݒ肷��
        /// �Ăяo���̓��b�N���ōs���Ă�������
        /// </summary>
        /// <param name="areaGroupList"></param>
        /// <returns></returns>
        private static void SetAreaGroupStaticMemoryInner( ArrayList areaGroupList )
        {
            if (areaGroupList == null)
            {
                return;
            }

            //�f�[�^�N���A
            areaGroupTable.Rows.Clear();

            //ArrayList����DataTable�ɓW�J
            foreach (AreaGroup data in areaGroupList)
            {
                DataRow drData = areaGroupTable.NewRow();

                drData["AreaGroupCode"] = data.AreaGroupCode;
                drData["AreaCode"] = data.AreaCode;
                drData["AreaKind"] = data.AreaKind;
                drData["AreaGroup"] = data;

                areaGroupTable.Rows.Add(drData);
            }

            //�������ς݂̃t���O�𗧂Ă�
            _initialized = true;
        }

		/// <summary>
		/// �w��ǋ�̌����擾����
		/// </summary>
        /// <param name="areaGroupCode"></param>
        /// <param name="areaGroupList"></param>
		/// <returns></returns>
		public static int GetAreaGroupPref( int areaGroupCode, out List<AreaGroup> areaGroupList )
		{
            areaGroupList = new List<AreaGroup>();
            DataRow[] drSelect = null;

            //----------------------- �����݃��b�N�J�n ------------------------
            //�ǋ�f�[�^���������Ƀ��[�h����
			LoadAreaGroup();
            //----------------------- �����݃��b�N�I�� ------------------------

            //----------------------- �Ǎ��݃��b�N�J�n ------------------------
            //�Ǎ����b�N���l��
            _readerWriterLock.AcquireReaderLock(Timeout.Infinite);

            try
            {
                //�R�[�h�w��̏ꍇ�͂��̃R�[�h����
                if (areaGroupCode != 0)
                {
                    drSelect = areaGroupTable.Select(" AreaGroupCode = " + areaGroupCode.ToString() + " AND AreaKind = 1");
                }
                else
                {
                    //���w��Ȃ�ΑS�Ă̌�
                    drSelect = areaGroupTable.Select("AreaKind = 1");
                }

                //DataRow����AreaGroup�����o��
                for (int i = 0; i < drSelect.Length; i++)
                {
                    areaGroupList.Add(drSelect[i]["AreaGroup"] as AreaGroup);
                }
            }
            finally
            {
                //�Ǎ����b�N�J��
                _readerWriterLock.ReleaseReaderLock();
            }
            //----------------------- �Ǎ��݃��b�N�I�� ------------------------

			return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		}
		
		/// <summary>
		/// �n��O���[�v���擾����
		/// </summary>
		/// <param name="areaGroupList"></param>
		/// <returns></returns>
		public static int GetAreaGroup( out List<AreaGroup> areaGroupList )
		{
            areaGroupList = new List<AreaGroup>();

            //----------------------- �����݃��b�N�J�n ------------------------
            //�ǋ�f�[�^���������Ƀ��[�h����
			LoadAreaGroup();
            //----------------------- �����݃��b�N�I�� ------------------------

            //----------------------- �Ǎ��݃��b�N�J�n ------------------------
            //�Ǎ����b�N���l��
            _readerWriterLock.AcquireReaderLock(Timeout.Infinite);

            try
            {
                //�ǋ悾���擾
                DataRow[] drSelect = areaGroupTable.Select(" AreaKind = 0 ");

                if (drSelect.Length <= 0)
                {
                    return (int)ConstantManagement.DB_Status.ctDB_EOF;
                }

                //DataRow����ArrayList�ɓW�J
                for (int i = 0; i < drSelect.Length; i++)
                {
                    areaGroupList.Add(drSelect[i]["AreaGroup"] as AreaGroup);
                }
            }
            finally
            {
                //�Ǎ����b�N�J��
                _readerWriterLock.ReleaseReaderLock();
            }
            //----------------------- �Ǎ��݃��b�N�I�� ------------------------

			return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		}
		
		/// <summary>
		/// �n��R�[�h����n��O���[�v���擾����
		/// </summary>
		/// <param name="areaCode"></param>
        /// <param name="areaGroup"></param>
		/// <returns></returns>
		public static int GetAreaGroupFromAreaCode( int areaCode, out AreaGroup areaGroup )
		{
            areaGroup = null;

            //----------------------- �Ǐ������b�N�J�n ------------------------
            int areaGroupCode = GetAreaGroupCodeFromAreaCode(areaCode);
            //----------------------- �Ǐ������b�N�I�� ------------------------

            //----------------------- �Ǎ��݃��b�N�J�n ------------------------
            //�Ǎ����b�N���l��
            _readerWriterLock.AcquireReaderLock(Timeout.Infinite);

            try
            {
                //�Y�����Ȃ��ꍇ�͖߂�
                if (areaGroupCode == 0)
                {
                    return (int)ConstantManagement.DB_Status.ctDB_EOF;
                }

                DataRow[] drSelect = areaGroupTable.Select("AreaGroupCode = " + areaGroupCode.ToString());

                if (drSelect.Length <= 0)
                {
                    return (int)ConstantManagement.DB_Status.ctDB_EOF;
                }

                areaGroup = drSelect[0]["AreaGroup"] as AreaGroup;
            }
            finally
            {
                //�Ǎ����b�N�J��
                _readerWriterLock.ReleaseReaderLock();
            }
            //----------------------- �Ǎ��݃��b�N�I�� ------------------------

			return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		}
		
		/// <summary>
		/// �n��R�[�h����n��O���[�v�R�[�h���擾����
		/// </summary>
		/// <param name="areaCode"></param>
		/// <returns></returns>
		public static int GetAreaGroupCodeFromAreaCode( int areaCode )
		{
			int areaGroupCode = 0;

            //----------------------- �����݃��b�N�J�n ------------------------
            //�ǋ�f�[�^���������Ƀ��[�h����
			LoadAreaGroup();
            //----------------------- �����݃��b�N�I�� ------------------------

            //----------------------- �Ǎ��݃��b�N�J�n ------------------------
            //�Ǎ����b�N���l��
            _readerWriterLock.AcquireReaderLock(Timeout.Infinite);

            try
            {

                DataRow[] drSelect = areaGroupTable.Select("AreaCode = " + areaCode.ToString());

                if (drSelect.Length <= 0)
                {
                    return (int)ConstantManagement.DB_Status.ctDB_EOF;
                }

                areaGroupCode = (int)drSelect[0]["AreaGroupCode"];
            }
            finally
            {
                //�Ǎ����b�N�J��
                _readerWriterLock.ReleaseReaderLock();
            }
            //----------------------- �Ǎ��݃��b�N�I�� ------------------------

			return areaGroupCode;
		}
		
	}
	
}