//
// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.
//

// Warning: This code was generated by a tool.
//
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using Microsoft.Azure.Commands.Compute.Automation.Models;
using Microsoft.Azure.Management.Compute.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute.Automation
{
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VmssDataDisk", SupportsShouldProcess = true)]
    [OutputType(typeof(PSVirtualMachineScaleSet))]
    public partial class RemoveAzureRmVmssDataDiskCommand : Microsoft.Azure.Commands.ResourceManager.Common.AzureRMCmdlet
    {
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public PSVirtualMachineScaleSet VirtualMachineScaleSet { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 1,
            ParameterSetName = "NameParameterSet",
            ValueFromPipelineByPropertyName = true)]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 1,
            ParameterSetName = "LunParameterSet",
            ValueFromPipelineByPropertyName = true)]
        public int? Lun { get; set; }

        protected override void ProcessRecord()
        {
            // VirtualMachineProfile
            if (this.VirtualMachineScaleSet.VirtualMachineProfile == null)
            {
                WriteObject(this.VirtualMachineScaleSet);
                return;
            }

            // StorageProfile
            if (this.VirtualMachineScaleSet.VirtualMachineProfile.StorageProfile == null)
            {
                WriteObject(this.VirtualMachineScaleSet);
                return;
            }

            // DataDisks
            if (this.VirtualMachineScaleSet.VirtualMachineProfile.StorageProfile.DataDisks == null)
            {
                WriteObject(this.VirtualMachineScaleSet);
                return;
            }
            var vDataDisks = this.VirtualMachineScaleSet.VirtualMachineProfile.StorageProfile.DataDisks.First
                (e =>
                    (this.Name != null && e.Name == this.Name)
                    || (this.Lun != null && e.Lun == this.Lun)
                );

            if (vDataDisks != null)
            {
                this.VirtualMachineScaleSet.VirtualMachineProfile.StorageProfile.DataDisks.Remove(vDataDisks);
            }

            if (this.VirtualMachineScaleSet.VirtualMachineProfile.StorageProfile.DataDisks.Count == 0)
            {
                this.VirtualMachineScaleSet.VirtualMachineProfile.StorageProfile.DataDisks = null;
            }
            WriteObject(this.VirtualMachineScaleSet);
        }
    }
}
