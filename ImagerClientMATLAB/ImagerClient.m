cmd = ImagerCommand();
cmd.Connect('10.1.51.93',10000);

cmd.setRecordPath('D:\ImagerData\Test\testing');
cmd.setDataFormat('Raw');

cmd.setIsRecording(true);
cmd.setIsAcquisiting(true);

cmd.setIsAcquisiting(false);
cmd.setIsRecording(false);

cmd.Disconnect();