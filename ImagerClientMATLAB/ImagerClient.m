cmd = ImagerCommand();
cmd.Connect('localhost',10000);

cmd.SetRecordPath('C:\Users\fff00\Pictures\Test');
cmd.SetDataFormat('Raw');
cmd.SetRecordEpoch('3');

cmd.SetIsAcqusiting(true);
cmd.SetIsRecording(true);

cmd.SetIsRecording(false);
cmd.SetIsAcqusiting(false);

cmd.Disconnect();