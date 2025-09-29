using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Broadleaf.Library.Runtime.InteropServices
{
    /// <summary>
    /// felica.dllのラッパークラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : FelicaのアクセスライブラリFelica.dllのラッパクラスです</br>
    /// <br>           : メソッドの詳細についてはSDK for FeliCaユーザーズマニュアルアクセスライブラリ編を</br>
    /// <br>           : 参照してください。</br>
    /// <br>Programmer : 22011 Kashihara</br>
    /// <br>Date       : 2008.10.30</br>
    /// </remarks>
    internal class Wrapper
    {
        private const string FELICADLL_PATH = "felica.dll";

        //DllImport
        [DllImport(FELICADLL_PATH)]
        private static extern bool initialize_library();

        [DllImport(FELICADLL_PATH)]
        private static extern bool open_reader_writer_auto();

        [DllImport(FELICADLL_PATH)]
        private static extern bool close_reader_writer();

        [DllImport(FELICADLL_PATH)]
        private static extern bool dispose_library();

        [DllImport(FELICADLL_PATH)]
        private static extern bool get_last_error_types(
            ref FeliCaErrorType eFeliCaErrorType,
            ref RwErrorType eRwErrorType
            );

        [DllImport(FELICADLL_PATH)]
        private static extern bool polling_and_get_card_information(
            ref StructurePolling udtPolling,
            ref byte bytNumberOfCards,
            ref StructureCardInformation udtCardInformation
            );

        [DllImport(FELICADLL_PATH)]
        private static extern bool get_version_information(
                StringBuilder sbVersionNumber
            );

        [DllImport(FELICADLL_PATH)]
        private static extern bool get_copyright_information(
                StringBuilder sbCopyright
            );

        [DllImport(FELICADLL_PATH)]
        private static extern bool set_reader_writer_control_library(
                string sbLibraryFileName
            );

        [DllImport(FELICADLL_PATH)]
        private static extern bool open_reader_writer_without_encryption(
            ref StructureOpenReaderWriterModeWithoutEncryption
                        udtOpenReaderWriteModeWithoutEncryption
            );

        [DllImport(FELICADLL_PATH)]
        private static extern bool reader_writer_is_alive(
            ref bool bReaderWriterIsAliveFlag);

        [DllImport(FELICADLL_PATH)]
        private static extern bool reader_writer_is_open(
            ref bool bReaderWriterIsOpenFlag);

        [DllImport(FELICADLL_PATH)]
        private static extern bool get_reader_writer_mode
            (ref StructureReaderWriterMode udtReaderWriterMode);

        [DllImport(FELICADLL_PATH)]
        private static extern bool polling_and_request_service(
            ref StructurePolling udtPolling,
            ref StructureInputRequestService udtInputRequestService,
            ref StructureCardInformation udtCardInformation,
            ref StructureOutputRequestService udtOutputRequestService);

        [DllImport(FELICADLL_PATH)]
        private static extern bool write_block_without_encryption(
            ref StructureInputWriteBlockWithoutEncryption udtInputWriteBlockWithoutEncryption,
            ref StructureOutputWriteBlockWithoutEncryption udtOutputWriteBlockWithoutEncryption
            );

        [DllImport(FELICADLL_PATH)]
        private static extern bool read_block_without_encryption(
            ref StructureInputReadBlockWithoutEncryption udtInputReadBlockWithoutEncryption,
            ref StructureOutputReadBlockWithoutEncryption udtOutputReadBlockWithoutEncryption
            );

        [DllImport(FELICADLL_PATH)]
        private static extern bool polling_and_request_system_code(
            ref StructurePolling udtPolling,
            ref StructureInputRequestSystemCode udtInputSystemCode,
            ref StructureCardInformation udtCardInformation,
            ref StructureOutputRequestSystemCode udtOutputSystemCode);

        [DllImport(FELICADLL_PATH)]
        private static extern bool polling_and_search_service_code(
            ref StructurePolling udtPolling,
            ref StructureInputSearchServiceCode udtInputSearchServiceCode,
            ref StructureCardInformation udtCardInformation,
            ref StructureOutputSearchServiceCode udtOutputSearchServiceCode);

        [DllImport(FELICADLL_PATH)]
        private static extern bool dumb(
            ref StructureInputDumb udtInputDumb,
            ref StructureOutputDumb udtOutputDumb
        );

        [DllImport(FELICADLL_PATH)]
        private static extern bool rw_set_plugins_home_directory(
            string plugins_home_directory);

        //Wrapper functions
        internal bool InitializeLibrary()
        {
            return initialize_library();
        }
        internal bool OpenReaderWriterAuto()
        {
            return open_reader_writer_auto();
        }
        internal bool CloseReaderWriter()
        {
            return close_reader_writer();
        }
        internal bool DisposeLibrary()
        {
            return dispose_library();
        }
        internal bool GetLastErrorTypes(
            ref FeliCaErrorType feliCaErrorType,
            ref RwErrorType rwErrorType)
        {
            return get_last_error_types(
                       ref feliCaErrorType,
                       ref rwErrorType
            );
        }
        internal bool PollingAndGetCardInformation(
            ref StructurePolling polling,
            ref byte numberOfCards,
            ref StructureCardInformation cardInformation)
        {
            return polling_and_get_card_information(
                       ref polling,
                       ref numberOfCards,
                       ref cardInformation
            );
        }

        internal bool getVersionInformation(
            StringBuilder sbVersionNumber)
        {
            return get_version_information(
                    sbVersionNumber);
        }

        internal bool getCopyrightInformation(
            StringBuilder sbCopyright)
        {
            return get_copyright_information(
                        sbCopyright);
        }

        internal bool SetReaderWriterControlLibrary(
        string strLibraryFileName)
        {
            return set_reader_writer_control_library(
                    strLibraryFileName);
        }

        internal bool OpenReaderWriterWithoutEncryption(
        ref StructureOpenReaderWriterModeWithoutEncryption
                    udtOpenReaderWriteModeWithoutEncryption)
        {
            return open_reader_writer_without_encryption(
                ref udtOpenReaderWriteModeWithoutEncryption
            );
        }

        internal bool ReaderWriterIsAlive(
        ref bool bReaderWriterIsAliveFlag)
        {
            return reader_writer_is_alive(
                ref bReaderWriterIsAliveFlag);
        }
        internal bool ReaderWriterIsOpen(
            ref bool bReaderWriterIsOpenFlag)
        {
            return reader_writer_is_open(
                ref bReaderWriterIsOpenFlag);
        }

        internal bool GetReaderWriteMode(
            ref StructureReaderWriterMode udtReaderWriterMode)
        {
            return get_reader_writer_mode(
                ref udtReaderWriterMode);
        }

        internal bool PollingAndRequestService(
        ref StructurePolling udtPolling,
        ref StructureInputRequestService udtInputRequestService,
        ref StructureCardInformation udtCardInformation,
        ref StructureOutputRequestService udtOutputRequestService)
        {

            return polling_and_request_service(
                        ref udtPolling,
                        ref udtInputRequestService,
                        ref udtCardInformation,
                        ref udtOutputRequestService);
        }

        internal bool WriteBlockWithoutEncryption(
        ref StructureInputWriteBlockWithoutEncryption udtInputWriteBlockWithoutEncryption,
        ref StructureOutputWriteBlockWithoutEncryption udtOutputWriteBlockWithoutEncryption)
        {
            return write_block_without_encryption(
                       ref udtInputWriteBlockWithoutEncryption,
                       ref udtOutputWriteBlockWithoutEncryption
            );
        }
        internal bool ReadBlockWithoutEncryption(
            ref StructureInputReadBlockWithoutEncryption udtInputReadBlockWithoutEncryption,
            ref StructureOutputReadBlockWithoutEncryption udtOutputReadBlockWithoutEncryption)
        {
            return read_block_without_encryption(
                       ref udtInputReadBlockWithoutEncryption,
                       ref udtOutputReadBlockWithoutEncryption
            );
        }

        internal bool PollingAndRequestSystemCode(
        ref StructurePolling udtPolling,
        ref StructureInputRequestSystemCode udtInputSystemCode,
        ref StructureCardInformation udtCardInformation,
        ref StructureOutputRequestSystemCode udtOutputSystemCode)
        {

            return polling_and_request_system_code(
                        ref udtPolling,
                        ref udtInputSystemCode,
                        ref udtCardInformation,
                        ref udtOutputSystemCode);
        }

       internal bool PollingAndSearchServiceCode(
       ref StructurePolling udtPolling,
       ref StructureInputSearchServiceCode udtInputSearchServiceCode,
       ref StructureCardInformation udtCardInformation,
       ref StructureOutputSearchServiceCode udtOutputSearchServiceCode)
        {
            return polling_and_search_service_code(
                        ref udtPolling,
                        ref udtInputSearchServiceCode,
                        ref udtCardInformation,
                        ref udtOutputSearchServiceCode);
        }

        internal bool Dumb(
        ref StructureInputDumb udtInputDumb,
        ref StructureOutputDumb udtOutputDumb)
        {
            return dumb(
                        ref udtInputDumb,
                        ref udtOutputDumb);
        }

        internal bool RwSetPluginsHomeDirectory
        (string plugins_home_directory)
        {
            return rw_set_plugins_home_directory(plugins_home_directory);
        }
    }
}
