cmd = ImagerCommand();
cmd.Connect('localhost',10000);

cmd.SetRecordPath('C:\Users\fff00\Pictures\Test');
cmd.setRecordEpoch('3');
cmd.SetIsRecording(true);

cmd.SetIsRecording(false);
cmd.Disconnect();