% CommandPrx   Summary of CommandPrx
%
% CommandPrx Methods:
%   getRecordPath
%   getRecordPathAsync
%   setRecordPath
%   setRecordPathAsync
%   getRecordEpoch
%   getRecordEpochAsync
%   setRecordEpoch
%   setRecordEpochAsync
%   getDataFormat
%   getDataFormatAsync
%   setDataFormat
%   setDataFormatAsync
%   getIsAcqusiting
%   getIsAcqusitingAsync
%   setIsAcqusiting
%   setIsAcqusitingAsync
%   getIsRecording
%   getIsRecordingAsync
%   setIsRecording
%   setIsRecordingAsync
%   getIsAcqusitingAndRecording
%   getIsAcqusitingAndRecordingAsync
%   setIsAcqusitingAndRecording
%   setIsAcqusitingAndRecordingAsync
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
        function result = getRecordEpoch(obj, varargin)
            % getRecordEpoch
            %
            % Parameters:
            %   context (containers.Map) - Optional request context.
            %
            % Returns (char)
            
            is_ = obj.iceInvoke('getRecordEpoch', 0, true, [], true, {}, varargin{:});
            is_.startEncapsulation();
            result = is_.readString();
            is_.endEncapsulation();
        end
        function r_ = getRecordEpochAsync(obj, varargin)
            % getRecordEpochAsync
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
            r_ = obj.iceInvokeAsync('getRecordEpoch', 0, true, [], 1, @unmarshal, {}, varargin{:});
        end
        function setRecordEpoch(obj, epoch, varargin)
            % setRecordEpoch
            %
            % Parameters:
            %   epoch (char)
            %   context (containers.Map) - Optional request context.
            
            os_ = obj.iceStartWriteParams([]);
            os_.writeString(epoch);
            obj.iceEndWriteParams(os_);
            obj.iceInvoke('setRecordEpoch', 0, false, os_, false, {}, varargin{:});
        end
        function r_ = setRecordEpochAsync(obj, epoch, varargin)
            % setRecordEpochAsync
            %
            % Parameters:
            %   epoch (char)
            %   context (containers.Map) - Optional request context.
            %
            % Returns (Ice.Future) - A future that will be completed with the results of the invocation.
            
            os_ = obj.iceStartWriteParams([]);
            os_.writeString(epoch);
            obj.iceEndWriteParams(os_);
            r_ = obj.iceInvokeAsync('setRecordEpoch', 0, false, os_, 0, [], {}, varargin{:});
        end
        function result = getDataFormat(obj, varargin)
            % getDataFormat
            %
            % Parameters:
            %   context (containers.Map) - Optional request context.
            %
            % Returns (char)
            
            is_ = obj.iceInvoke('getDataFormat', 0, true, [], true, {}, varargin{:});
            is_.startEncapsulation();
            result = is_.readString();
            is_.endEncapsulation();
        end
        function r_ = getDataFormatAsync(obj, varargin)
            % getDataFormatAsync
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
            r_ = obj.iceInvokeAsync('getDataFormat', 0, true, [], 1, @unmarshal, {}, varargin{:});
        end
        function setDataFormat(obj, format, varargin)
            % setDataFormat
            %
            % Parameters:
            %   format (char)
            %   context (containers.Map) - Optional request context.
            
            os_ = obj.iceStartWriteParams([]);
            os_.writeString(format);
            obj.iceEndWriteParams(os_);
            obj.iceInvoke('setDataFormat', 0, false, os_, false, {}, varargin{:});
        end
        function r_ = setDataFormatAsync(obj, format, varargin)
            % setDataFormatAsync
            %
            % Parameters:
            %   format (char)
            %   context (containers.Map) - Optional request context.
            %
            % Returns (Ice.Future) - A future that will be completed with the results of the invocation.
            
            os_ = obj.iceStartWriteParams([]);
            os_.writeString(format);
            obj.iceEndWriteParams(os_);
            r_ = obj.iceInvokeAsync('setDataFormat', 0, false, os_, 0, [], {}, varargin{:});
        end
        function result = getIsAcqusiting(obj, varargin)
            % getIsAcqusiting
            %
            % Parameters:
            %   context (containers.Map) - Optional request context.
            %
            % Returns (logical)
            
            is_ = obj.iceInvoke('getIsAcqusiting', 0, true, [], true, {}, varargin{:});
            is_.startEncapsulation();
            result = is_.readBool();
            is_.endEncapsulation();
        end
        function r_ = getIsAcqusitingAsync(obj, varargin)
            % getIsAcqusitingAsync
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
            r_ = obj.iceInvokeAsync('getIsAcqusiting', 0, true, [], 1, @unmarshal, {}, varargin{:});
        end
        function setIsAcqusiting(obj, isacqusiting, varargin)
            % setIsAcqusiting
            %
            % Parameters:
            %   isacqusiting (logical)
            %   context (containers.Map) - Optional request context.
            
            os_ = obj.iceStartWriteParams([]);
            os_.writeBool(isacqusiting);
            obj.iceEndWriteParams(os_);
            obj.iceInvoke('setIsAcqusiting', 0, false, os_, false, {}, varargin{:});
        end
        function r_ = setIsAcqusitingAsync(obj, isacqusiting, varargin)
            % setIsAcqusitingAsync
            %
            % Parameters:
            %   isacqusiting (logical)
            %   context (containers.Map) - Optional request context.
            %
            % Returns (Ice.Future) - A future that will be completed with the results of the invocation.
            
            os_ = obj.iceStartWriteParams([]);
            os_.writeBool(isacqusiting);
            obj.iceEndWriteParams(os_);
            r_ = obj.iceInvokeAsync('setIsAcqusiting', 0, false, os_, 0, [], {}, varargin{:});
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
        function result = getIsAcqusitingAndRecording(obj, varargin)
            % getIsAcqusitingAndRecording
            %
            % Parameters:
            %   context (containers.Map) - Optional request context.
            %
            % Returns (logical)
            
            is_ = obj.iceInvoke('getIsAcqusitingAndRecording', 0, true, [], true, {}, varargin{:});
            is_.startEncapsulation();
            result = is_.readBool();
            is_.endEncapsulation();
        end
        function r_ = getIsAcqusitingAndRecordingAsync(obj, varargin)
            % getIsAcqusitingAndRecordingAsync
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
            r_ = obj.iceInvokeAsync('getIsAcqusitingAndRecording', 0, true, [], 1, @unmarshal, {}, varargin{:});
        end
        function setIsAcqusitingAndRecording(obj, isacqusitingandrecording, varargin)
            % setIsAcqusitingAndRecording
            %
            % Parameters:
            %   isacqusitingandrecording (logical)
            %   context (containers.Map) - Optional request context.
            
            os_ = obj.iceStartWriteParams([]);
            os_.writeBool(isacqusitingandrecording);
            obj.iceEndWriteParams(os_);
            obj.iceInvoke('setIsAcqusitingAndRecording', 0, false, os_, false, {}, varargin{:});
        end
        function r_ = setIsAcqusitingAndRecordingAsync(obj, isacqusitingandrecording, varargin)
            % setIsAcqusitingAndRecordingAsync
            %
            % Parameters:
            %   isacqusitingandrecording (logical)
            %   context (containers.Map) - Optional request context.
            %
            % Returns (Ice.Future) - A future that will be completed with the results of the invocation.
            
            os_ = obj.iceStartWriteParams([]);
            os_.writeBool(isacqusitingandrecording);
            obj.iceEndWriteParams(os_);
            r_ = obj.iceInvokeAsync('setIsAcqusitingAndRecording', 0, false, os_, 0, [], {}, varargin{:});
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
