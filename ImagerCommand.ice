module Imager
{
    interface Command
    {
        string getRecordPath();
        void setRecordPath(string path);
        string getRecordEpoch();
        void setRecordEpoch(string epoch);
        bool getIsRecording();
        void setIsRecording(bool isrecording);
    }
}