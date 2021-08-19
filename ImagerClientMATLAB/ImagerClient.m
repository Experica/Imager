cmd = ImagerCommand();
cmd.Connect('localhost',10000);

cmd.setRecordPath('C:\Users\fff00\Pictures\Test');
cmd.setDataFormat('Raw');
cmd.setRecordEpoch('3');

cmd.setIsRecording(true);
cmd.setIsAcqusiting(true);

cmd.setIsAcqusiting(false);
cmd.setIsRecording(false);

cmd.Disconnect();