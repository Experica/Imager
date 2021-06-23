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
            obj.Disconnect();
            obj.communicator = Ice.initialize();
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
        
        function SetRecordPath(obj,filepath)
            if isempty(obj.command)
                warning('No Command Proxy, Connect First.');
            else
                obj.command.setRecordPath(filepath);
            end
        end
        
        function [filepath] = GetRecordPath(obj)
            if isempty(obj.command)
                warning('No Command Proxy, Connect First.');
            else
                filepath = obj.command.getRecordPath();
            end
        end
        
        function SetRecordEpoch(obj,epoch)
            if isempty(obj.command)
                warning('No Command Proxy, Connect First.');
            else
                obj.command.setRecordEpoch(epoch);
            end
        end
        
        function [epoch] = GetRecordEpoch(obj)
            if isempty(obj.command)
                warning('No Command Proxy, Connect First.');
            else
                epoch = obj.command.getRecordEpoch();
            end
        end
        
        function SetIsRecording(obj,isrecording)
            if isempty(obj.command)
                warning('No Command Proxy, Connect First.');
            else
                obj.command.setIsRecording(isrecording);
            end
        end
        
        function [isrecording] = GetIsRecording(obj)
            if isempty(obj.command)
                warning('No Command Proxy, Connect First.');
            else
                isrecording = obj.command.getIsRecording();
            end
        end
    end
end

