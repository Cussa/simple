﻿using System;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Serialization.Formatters;

namespace Simple.Services.Remoting.Channels
{
    public class HttpChannelHandler : IChannelHandler
    {
        #region IChannelHandler Members

        public IChannelReceiver CreateServerChannel(Uri uri)
        {
            return CreateServerChannel(DefaultName, uri);
        }

        public IChannelReceiver CreateServerChannel(string name, Uri uri)
        {
            var sink = new BinaryServerFormatterSinkProvider();
            sink.TypeFilterLevel = TypeFilterLevel.Full;

            return new HttpServerChannel(name, uri.Port, sink);
        }

        public IChannelSender CreateClientChannel()
        {
            return CreateClientChannel(DefaultName);
        }

        public IChannelSender CreateClientChannel(string name)
        {
            return new HttpClientChannel(name, new BinaryClientFormatterSinkProvider());
        }

        public string DefaultName
        {
            get { return "http"; }
        }

        public string Scheme
        {
            get { return "http"; }
        }

        #endregion
    }
}
