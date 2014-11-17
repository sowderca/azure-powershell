﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.Network.Gateway
{
    using System.Management.Automation;
    using WindowsAzure.Commands.Utilities.Common;

    [Cmdlet(VerbsCommon.Set, "AzureVNetGatewayDefaultSite"), OutputType(typeof(ManagementOperationContext))]
    public class SetAzureVNetGatewayDefaultSite : NetworkCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = "The virtual network name.")]
        [ValidateNotNullOrEmpty]
        public string VNetName
        {
            get;
            set;
        }

        [Parameter(Position = 1, Mandatory = true, HelpMessage = "The local network default site for this virtual network gateway.")]
        [ValidateNotNullOrEmpty]
        public string DefaultSite
        {
            get;
            set;
        }

        public override void ExecuteCmdlet()
        {
            WriteObject(Client.SetDefaultSite(VNetName, DefaultSite));
        }
    }
}
