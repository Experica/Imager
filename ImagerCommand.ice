module Imager
{
    interface Command
    {
        string getRecordPath();
        bool setRecordPath(string path);

        string getRecordEpoch();
        bool setRecordEpoch(string epoch);

        string getDataFormat();
        bool setDataFormat(string format);

        bool getIsAcqusiting();
        bool setIsAcqusiting(bool isacqusiting);

        bool getIsRecording();
        bool setIsRecording(bool isrecording);

        bool StartRecordAndAcqusite();
        bool StopAcqusiteAndRecord();
    }
}