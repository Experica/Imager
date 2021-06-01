% CommandPrx   Summary of CommandPrx
%
% CommandPrx Methods:
%   getRecordPath
%   getRecordPathAsync
%   setRecordPath
%   setRecordPathAsync
%   getIsRecording
%   getIsRecordingAsync
%   setIsRecording
%   setIsRecordingAsync
%   checkedCast - Contacts the remote server to verify that the object implements this type.
%   uncheckedCast - Downcasts the given proxy to this type without contacting the remote server.

% Copyright (c) ZeroC, Inc. All rights reserved.
% Generated from ImagerCommand.ice by slice2matlab version 3.7.5

classdef CommandPrx < Ice.ObjectPrx
    methods
        function result = getRecordPath(obj, varargin)
            % getRecordPath
            %
            % Parameters:
            %   context (containers.Map) - Optional request context.
            %
            % Returns (char)
            
            is_ = obj.iceInvoke('getRecordPath', 0, true, [], true, {}, varargin{:});
            is_.startEncapsulation();
            result = is_.readString();
            is_.endEncapsulation();
        end
        function r_ = getRecordPathAsync(obj, varargin)
            % getRecordPathAsync
            %
            % Parameters:
            %   context (containers.Map) - Optional request context.
            %
            % Returns (Ice.Future) - A future that will be completed with the results of the invocation.
            
            function varargout = unmarshal(is_)
                is_.startEncapsulation();
                result = is_.readString();
                is_.endEncapsulation();
                varargout{1} = result;
            end
            r_ = obj.iceInvokeAsync('getRecordPath', 0, true, [], 1, @unmarshal, {}, varargin{:});
        end
        function setRecordPath(obj, path, varargin)
            % setRecordPath
            %
            % Parameters:
            %   path (char)
            %   context (containers.Map) - Optional request context.
            
            os_ = obj.iceStartWriteParams([]);
            os_.writeString(path);
            obj.iceEndWriteParams(os_);
            obj.iceInvoke('setRecordPath', 0, false, os_, false, {}, varargin{:});
        end
        function r_ = setRecordPathAsync(obj, path, varargin)
            % setRecordPathAsync
            %
            % Parameters:
            %   path (char)
            %   context (containers.Map) - Optional request context.
            %
            % Returns (Ice.Future) - A future that will be completed with the results of the invocation.
            
            os_ = obj.iceStartWriteParams([]);
            os_.writeString(path);
            obj.iceEndWriteParams(os_);
            r_ = obj.iceInvokeAsync('setRecordPath', 0, false, os_, 0, [], {}, varargin{:});
        end
        function result = getIsRecording(obj, varargin)
            % getIsRecording
            %
            % Parameters:
            %   context (containers.Map) - Optional request context.
            %
            % Returns (logical)
            
            is_ = obj.iceInvoke('getIsRecording', 0, true, [], true, {}, varargin{:});
            is_.startEncapsulation();
            result = is_.readBool();
            is_.endEncapsulation();
        end
        function r_ = getIsRecordingAsync(obj, varargin)
            % getIsRecordingAsync
            %
            % Parameters:
            %   context (containers.Map) - Optional request context.
            %
            % Returns (Ice.Future) - A future that will be completed with the results of the invocation.
            
            function varargout = unmarshal(is_)
                is_.startEncapsulation();
                result = is_.readBool();
                is_.endEncapsulation();
                varargout{1} = result;
            end
            r_ = obj.iceInvokeAsync('getIsRecording', 0, true, [], 1, @unmarshal, {}, varargin{:});
        end
        function setIsRecording(obj, isrecording, varargin)
            % setIsRecording
            %
            % Parameters:
            %   isrecording (logical)
            %   context (containers.Map) - Optional request context.
            
            os_ = obj.iceStartWriteParams([]);
            os_.writeBool(isrecording);
            obj.iceEndWriteParams(os_);
            obj.iceInvoke('setIsRecording', 0, false, os_, false, {}, varargin{:});
        end
        function r_ = setIsRecordingAsync(obj, isrecording, varargin)
            % setIsRecordingAsync
            %
            % Parameters:
            %   isrecording (logical)
            %   context (containers.Map) - Optional request context.
            %
            % Returns (Ice.Future) - A future that will be completed with the results of the invocation.
            
            os_ = obj.iceStartWriteParams([]);
            os_.writeBool(isrecording);
            obj.iceEndWriteParams(os_);
            r_ = obj.iceInvokeAsync('setIsRecording', 0, false, os_, 0, [], {}, varargin{:});
        end
    end
    methods(Static)
        function id = ice_staticId()
            id = '::Imager::Command';
        end
        function r = ice_read(is)
            r = is.readProxy('Imager.CommandPrx');
        end
        function r = checkedCast(p, varargin)
            % checkedCast   Contacts the remote server to verify that the object implements this type.
            %   Raises a local exception if a communication error occurs. You can optionally supply a
            %   facet name and a context map.
            %
            % Parameters:
            %   p - The proxy to be cast.
            %   facet - The optional name of the desired facet.
            %   context - The optional context map to send with the invocation.
            %
            % Returns (Imager.CommandPrx) - A proxy for this type, or an empty array if the object does not support this type.
            r = Ice.ObjectPrx.iceCheckedCast(p, Imager.CommandPrx.ice_staticId(), 'Imager.CommandPrx', varargin{:});
        end
        function r = uncheckedCast(p, varargin)
            % uncheckedCast   Downcasts the given proxy to this type without contacting the remote server.
            %   You can optionally specify a facet name.
            %
            % Parameters:
            %   p - The proxy to be cast.
            %   facet - The optional name of the desired facet.
            %
            % Returns (Imager.CommandPrx) - A proxy for this type.
            r = Ice.ObjectPrx.iceUncheckedCast(p, 'Imager.CommandPrx', varargin{:});
        end
    end
    methods(Hidden=true)
        function obj = CommandPrx(communicator, encoding, impl, bytes)
            obj = obj@Ice.ObjectPrx(communicator, encoding, impl, bytes);
        end
    end
end
