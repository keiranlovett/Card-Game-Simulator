﻿/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/. */

using System;
using System.Net;
using Mirror;
using Mirror.Discovery;

namespace Cgs.Play.Multiplayer
{
    public delegate void OnServerDiscoveredDelegate(DiscoveryResponse response);

    public class DiscoveryRequest : MessageBase
    {
        // Can be used to add filters, client info, etc...
    }

    public class DiscoveryResponse : MessageBase
    {
        public long ServerId;
        public IPEndPoint EndPoint { get; set; }
        public Uri Uri;
        public string GameName;
        public int Players;
        public int Capacity;

        public override string ToString()
        {
            return $"{GameName}\n{Uri.AbsoluteUri} - {Players}/{Capacity}";
        }
    }

    public class CgsNetDiscovery : NetworkDiscoveryBase<DiscoveryRequest, DiscoveryResponse>
    {
        public OnServerDiscoveredDelegate OnServerFound { get; set; }

        private long _serverId;
        private Transport _transport;

        public override void Start()
        {
            base.Start();
            _serverId = RandomLong();
            _transport = GetComponent<Transport>() ?? Transport.activeTransport;
        }

        protected override DiscoveryResponse ProcessRequest(DiscoveryRequest request, IPEndPoint endpoint)
        {
            return new DiscoveryResponse
            {
                ServerId = _serverId,
                // the endpoint is populated by the client
                Uri = _transport.ServerUri(),
                GameName = CgsNetManager.Instance.GameName,
                Players = NetworkServer.connections.Count,
                Capacity = NetworkManager.singleton.maxConnections
            };
        }

        protected override DiscoveryRequest GetRequest() => new DiscoveryRequest();

        protected override void ProcessResponse(DiscoveryResponse response, IPEndPoint endpoint)
        {
            response.EndPoint = endpoint;
            var realUri = new UriBuilder(response.Uri)
            {
                Host = response.EndPoint.Address.ToString()
            };
            response.Uri = realUri.Uri;

            OnServerFound(response);
        }
    }
}
