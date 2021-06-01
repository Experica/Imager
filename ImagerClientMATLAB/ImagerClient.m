cmd = ImagerCommand();
cmd.Connect('localhost',10000);

cmd.SetRecordPath('C:\Users\fff00\Pictures\Test');
cmd.SetIsRecording(true);

cmd.SetIsRecording(false);
cmd.Disconnect();