module Imager
{
    interface Command
    {
        string getRecordPath();
        void setRecordPath(string path);

        string getRecordEpoch();
        void setRecordEpoch(string epoch);

        string getDataFormat();
        void setDataFormat(string format);

        bool getIsAcqusiting();
        void setIsAcqusiting(bool isacqusiting);

        bool getIsRecording();
        void setIsRecording(bool isrecording);

        bool getIsAcqusitingAndRecording();
        void setIsAcqusitingAndRecording(bool isacqusitingandrecording);
    }
}