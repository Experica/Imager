classdef ImagerCommand < handle
    %IMAGERCOMMAND Client Library for Imager Command Server
    
    properties
        communicator=[]
        command=[]
    end
    
    methods
        function obj = ImagerCommand()
        end
        
        function delete(obj)
            obj.Disconnect()
        end
        
        function Connect(obj,host,port)
            if ~libisloaded('ice')
                loadlibrary('ice', @iceproto)
            end
            if isempty(obj.communicator)
                obj.communicator = Ice.initialize();
            end
            base = obj.communicator.stringToProxy(append('Command:default -h ',host,' -p ',num2str(port)));
            obj.command = Imager.CommandPrx.checkedCast(base);
            if isempty(obj.command)
                throw(MException('Client:RuntimeError', append('Invalid Command Proxy from Host: ',host,', Port: ',num2str(port))));
            end
        end
        
        function Disconnect(obj)
            if ~isempty(obj.communicator)
                obj.communicator.destroy();
                obj.communicator=[];
                obj.command=[];
            end
        end
        
        function [r] = setRecordPath(obj,filepath)
            if isempty(obj.command)
                warning('No Command Proxy, Connect First.');
            else
                r = obj.command.setRecordPath(filepath);
            end
        end
        
        function [filepath] = getRecordPath(obj)
            if isempty(obj.command)
                warning('No Command Proxy, Connect First.');
            else
                filepath = obj.command.getRecordPath();
            end
        end
        
        function [r] = setDataFormat(obj,format)
            if isempty(obj.command)
                warning('No Command Proxy, Connect First.');
            else
                r = obj.command.setDataFormat(format);
            end
        end
        
        function [format] = getDataFormat(obj)
            if isempty(obj.command)
                warning('No Command Proxy, Connect First.');
            else
                format = obj.command.getDataFormat();
            end
        end
        
        function [r] = setIsAcquisiting(obj,isacquisiting)
            if isempty(obj.command)
                warning('No Command Proxy, Connect First.');
            else
                r = obj.command.setIsAcquisiting(isacquisiting);
            end
        end
        
        function [isacquisiting] = getIsAcqusiting(obj)
            if isempty(obj.command)
                warning('No Command Proxy, Connect First.');
            else
                isacquisiting = obj.command.getIsAcquisiting();
            end
        end
        
        function [r] = setIsRecording(obj,isrecording)
            if isempty(obj.command)
                warning('No Command Proxy, Connect First.');
            else
                r = obj.command.setIsRecording(isrecording);
            end
        end
        
        function [isrecording] = getIsRecording(obj)
            if isempty(obj.command)
                warning('No Command Proxy, Connect First.');
            else
                isrecording = obj.command.getIsRecording();
            end
        end
        
        function [r] = StartRecordAndAcquisite(obj)
            if isempty(obj.command)
                warning('No Command Proxy, Connect First.');
            else
                r = obj.command.StartRecordAndAcquisite();
            end
        end
        
        function [r] = StopAcquisiteAndRecord(obj)
            if isempty(obj.command)
                warning('No Command Proxy, Connect First.');
            else
                r = obj.command.StopAcquisiteAndRecord();
            end
        end
        
    end
end

