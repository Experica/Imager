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

        bool getIsAcquisiting();
        bool setIsAcquisiting(bool isacquisiting);

        bool getIsRecording();
        bool setIsRecording(bool isrecording);

        bool StartRecordAndAcquisite();
        bool StopAcquisiteAndRecord();
    }
}