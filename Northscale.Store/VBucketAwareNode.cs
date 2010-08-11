﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enyim.Caching.Memcached.Protocol.Binary;
using System.Net;
using Enyim.Caching.Configuration;
using Enyim.Caching.Memcached;

namespace NorthScale.Store
{
	internal class VBucketAwareNode : BinaryNode
	{
		public VBucketAwareNode(IPEndPoint endpoint, ISocketPoolConfiguration config, ISaslAuthenticationProvider authenticationProvider)
			: base(endpoint, config, authenticationProvider) { }

		public ushort BucketIndex { get; set; }

		public override bool Execute(IOperation op)
		{
			var ivbop = op as IVBucketAwareOperation;

			if (ivbop != null)
				ivbop.Index = this.BucketIndex;

			return base.Execute(op);
		}
	}
}

#region [ License information          ]
/* ************************************************************
 * 
 *    Copyright (c) 2010 Attila Kiskó, enyim.com
 *    
 *    Licensed under the Apache License, Version 2.0 (the "License");
 *    you may not use this file except in compliance with the License.
 *    You may obtain a copy of the License at
 *    
 *        http://www.apache.org/licenses/LICENSE-2.0
 *    
 *    Unless required by applicable law or agreed to in writing, software
 *    distributed under the License is distributed on an "AS IS" BASIS,
 *    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *    See the License for the specific language governing permissions and
 *    limitations under the License.
 *    
 * ************************************************************/
#endregion