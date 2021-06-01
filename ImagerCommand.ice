module Imager
{
    interface Command
    {
        string getRecordPath();
        void setRecordPath(string path);
        bool getIsRecording();
        void setIsRecording(bool isrecording);
    }
}